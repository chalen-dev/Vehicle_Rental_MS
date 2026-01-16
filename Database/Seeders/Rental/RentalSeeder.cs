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
            var vehicle = _vehicleService.GetVehicleById(vehicleId);
            var baseOdo = vehicle.Odometer;

            int PickCustomer(int i) =>
                customers[i % customers.Count].Id;

            // -----------------------------
            // HARD LIMIT WINDOW
            // -----------------------------
            DateTime windowStart = new DateTime(2025, 8, 1, 8, 0, 0);
            DateTime windowEnd   = new DateTime(2026, 2, 28, 20, 0, 0);

            // -----------------------------
            // PATTERNS PER VEHICLE
            // rentalDays, gapDays
            // -----------------------------
            var patterns = new List<(int rent, int gap)[]>
            {
                new[] { (2,1), (5,2) },          // Vehicle pattern A
                new[] { (3,0), (3,1) },          // Pattern B
                new[] { (7,2) },                 // Pattern C
                new[] { (1,0), (1,0), (4,2) },   // Pattern D
                new[] { (5,3) }                  // Pattern E
            };

            var pattern = patterns[vehicleId % patterns.Count];

            // -----------------------------
            // SEED SEQUENTIALLY
            // -----------------------------
            DateTime cursor = windowStart;
            int customerCursor = 0;

            while (cursor < windowEnd)
            {
                foreach (var (rentDays, gapDays) in pattern)
                {
                    if (cursor >= windowEnd)
                        break;

                    DateTime pickup = cursor;
                    DateTime expected = pickup.AddDays(rentDays);
                    DateTime actual = expected; // NO SAME-DAY FUCKERY

                    if (expected > windowEnd)
                        return;

                    try
                    {
                        CreateCompletedRental(
                            PickCustomer(customerCursor++),
                            vehicleId,
                            pickup,
                            expected,
                            actual,
                            baseOdo
                        );
                    }
                    catch
                    {
                        // Seeder must NEVER stop
                    }

                    // -----------------------------
                    // MOVE FORWARD — THIS IS THE KEY
                    // +1 DAY GUARANTEE
                    // -----------------------------
                    cursor = actual
                        .Date
                        .AddDays(1 + gapDays)
                        .AddHours(8);
                }
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

                // Finalize invoice (creates totals)
                SafeFinalizeInvoice(rentalId);

                //  NEW: Seed payment AFTER finalization
                SeedFinalPayment(
                    rentalId,
                    actual.AddDays(_rand.Next(0, 3)) // payment same day or within 2 days
                );

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
        
        private void SeedFinalPayment(int rentalId, DateTime paymentDate)
        {
            try
            {
                // Get the invoice tied to this rental
                var invoice = _billingService.GetInvoiceByRental(rentalId);
                if (invoice == null)
                    return;

                // Skip if already paid or nothing to pay
                if (invoice.Status == InvoiceStatus.Paid)
                    return;

                if (invoice.TotalAmount <= 0m)
                    return;

                // Deterministic but varied payment method
                var methods = new[]
                {
                    PaymentMethod.Cash,
                    PaymentMethod.CreditCard,
                    PaymentMethod.DebitCard,
                    PaymentMethod.Online
                };

                var method =
                    methods[_rand.Next(methods.Length)];

                // ONE final payment = full amount
                _billingService.AddPayment(
                    invoiceId: invoice.Id,
                    amount: invoice.TotalAmount,
                    method: method,
                    paymentType: PaymentType.Final,
                    date: paymentDate
                );
            }
            catch
            {
                // Seeder must never stop
            }
        }

    }
}
