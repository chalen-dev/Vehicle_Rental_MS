using System;
using System.Collections.Generic;
using System.Linq;
using VRMS.Database.Seeders;
using VRMS.Enums;
using VRMS.Models.Rentals;
using VRMS.Repositories.Rentals;
using VRMS.Services.Billing;
using VRMS.Services.Customer;
using VRMS.Services.Fleet;

namespace VRMS.Database.Seeders.Rentals
{
    public class RentalSeeder : ISeeder
    {
        public string Name => nameof(RentalSeeder);

        private readonly RentalRepository _rentalRepo;
        private readonly VehicleService _vehicleService;
        private readonly CustomerService _customerService;
        private readonly BillingService _billingService;

        // deterministic random
        private readonly Random _rand = new(12345);

        public RentalSeeder(
            RentalRepository rentalRepo,
            VehicleService vehicleService,
            CustomerService customerService,
            BillingService billingService)
        {
            _rentalRepo = rentalRepo;
            _vehicleService = vehicleService;
            _customerService = customerService;
            _billingService = billingService;
        }

        public void Run()
        {
            Console.WriteLine("  Running rental seeder...");

            var vehicles = _vehicleService.GetAllVehicles();
            var customers = _customerService.GetAllCustomers();

            if (vehicles.Count == 0 || customers.Count == 0)
            {
                Console.WriteLine("    [SKIP] Vehicles or customers missing.");
                return;
            }

            // IMPORTANT:
            // This automatically links ALL rentals to ALL customers (including newly seeded ones)
            foreach (var vehicle in vehicles)
            {
                SeedForVehicle(vehicle.Id, customers);
            }

            Console.WriteLine("  Rental seeder finished.");
        }

        private void SeedForVehicle(
            int vehicleId,
            List<Models.Customers.Customer> customers)
        {
            var now = DateTime.UtcNow;

            var pastStart = new DateTime(2018, 1, 1);
            var pastEnd = now.AddDays(-1);

            var futureStart = now.AddDays(1);
            var futureEnd = now.AddDays(180);

            var vehicle = _vehicleService.GetVehicleById(vehicleId);
            var baseOdo = vehicle.Odometer;

            int PickCustomer() =>
                customers[_rand.Next(customers.Count)].Id;

            // -------------------------
            // PAST COMPLETED RENTALS
            // -------------------------
            for (int i = 0; i < 4; i++)
            {
                var pickup = RandomDate(pastStart, pastEnd);
                var days = _rand.Next(1, 21);
                var expected = pickup.AddDays(days);
                var actual = expected.AddDays(_rand.Next(-1, 5));
                if (actual <= pickup)
                    actual = pickup.AddDays(1);

                CreateCompletedRental(
                    PickCustomer(),
                    vehicleId,
                    pickup,
                    expected,
                    actual,
                    baseOdo);
            }

            // -------------------------
            // ACTIVE RENTAL
            // -------------------------
            var activePickup = RandomDate(now.AddDays(-3), now);
            var activeExpected = activePickup.AddDays(_rand.Next(1, 14));

            CreateActiveRental(
                PickCustomer(),
                vehicleId,
                activePickup,
                activeExpected,
                baseOdo);

            // -------------------------
            // FUTURE RESERVED RENTALS
            // -------------------------
            for (int i = 0; i < 2; i++)
            {
                var pickup = RandomDate(futureStart, futureEnd);
                var expected = pickup.AddDays(_rand.Next(1, 14));

                CreateReservedRental(
                    PickCustomer(),
                    vehicleId,
                    pickup,
                    expected,
                    baseOdo);
            }
        }

        private void CreateCompletedRental(
            int customerId,
            int vehicleId,
            DateTime pickup,
            DateTime expected,
            DateTime actual,
            int baseOdo)
        {
            try
            {
                if (!_vehicleService.AreRentalDatesAvailable(vehicleId, pickup, actual))
                    return;

                var startOdo = baseOdo + _rand.Next(0, 5000);
                var days = Math.Max(1, (int)Math.Ceiling((actual - pickup).TotalDays));
                var endOdo = startOdo + days * _rand.Next(20, 200);

                var rentalId = _rentalRepo.Create(
                    customerId,
                    vehicleId,
                    pickup,
                    expected,
                    startOdo,
                    RandomFuel(),
                    RentalStatus.Active);

                _rentalRepo.MarkStarted(rentalId);

                _billingService.GetOrCreateInvoice(rentalId);

                _rentalRepo.Complete(
                    rentalId,
                    actual,
                    endOdo,
                    RandomFuel());

                var status =
                    actual > expected
                        ? RentalStatus.Late
                        : RentalStatus.Completed;

                _rentalRepo.UpdateStatus(rentalId, status);

                SafeFinalizeInvoice(rentalId);

                Console.WriteLine($"    [OK] Completed rental #{rentalId} (cust:{customerId})");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"    [ERR] Completed rental failed: {ex.Message}");
            }
        }

        private void CreateActiveRental(
            int customerId,
            int vehicleId,
            DateTime pickup,
            DateTime expected,
            int baseOdo)
        {
            try
            {
                if (!_vehicleService.AreRentalDatesAvailable(vehicleId, pickup, expected))
                    return;

                var startOdo = baseOdo + _rand.Next(0, 5000);

                var rentalId = _rentalRepo.Create(
                    customerId,
                    vehicleId,
                    pickup,
                    expected,
                    startOdo,
                    RandomFuel(),
                    RentalStatus.Active);

                _rentalRepo.MarkStarted(rentalId);

                _billingService.GetOrCreateInvoice(rentalId);

                Console.WriteLine($"    [OK] Active rental #{rentalId} (cust:{customerId})");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"    [ERR] Active rental failed: {ex.Message}");
            }
        }

        private void CreateReservedRental(
            int customerId,
            int vehicleId,
            DateTime pickup,
            DateTime expected,
            int baseOdo)
        {
            try
            {
                if (!_vehicleService.AreRentalDatesAvailable(vehicleId, pickup, expected))
                    return;

                var startOdo = baseOdo + _rand.Next(0, 5000);

                var rentalId = _rentalRepo.Create(
                    customerId,
                    vehicleId,
                    pickup,
                    expected,
                    startOdo,
                    RandomFuel(),
                    RentalStatus.Reserved);

                Console.WriteLine($"    [OK] Reserved rental #{rentalId} (cust:{customerId})");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"    [ERR] Reserved rental failed: {ex.Message}");
            }
        }

        // -------------------------
        // HELPERS
        // -------------------------

        private DateTime RandomDate(DateTime start, DateTime end)
        {
            var range = Math.Max(1, (end - start).Days);
            return start
                .AddDays(_rand.Next(range))
                .AddHours(_rand.Next(8, 18))
                .AddMinutes(_rand.Next(0, 60));
        }

        private FuelLevel RandomFuel()
        {
            var values = Enum.GetValues(typeof(FuelLevel))
                .Cast<FuelLevel>()
                .ToArray();
            return values[_rand.Next(values.Length)];
        }

        private void SafeFinalizeInvoice(int rentalId)
        {
            try
            {
                _billingService.FinalizeInvoice(rentalId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"      [WARN] FinalizeInvoice failed for {rentalId}: {ex.Message}");
            }
        }
    }
}
