using VRMS.Repositories.Accounts;
using VRMS.Repositories.Billing;
using VRMS.Repositories.Customers;
using VRMS.Repositories.Damages;
using VRMS.Repositories.Fleet;
using VRMS.Repositories.Inspections;
using VRMS.Repositories.Rentals;

using VRMS.Services.Account;
using VRMS.Services.Billing;
using VRMS.Services.Customer;
using VRMS.Services.Fleet;
using VRMS.Services.Rental;

namespace VRMS.UI.Services;

public static class ApplicationServices
{
    // =====================================================
    // REPOSITORIES (SINGLETON)
    // =====================================================

    private static readonly CustomerRepository _customerRepo =
        new CustomerRepository();

    private static readonly CustomerAccountRepository _customerAccountRepo =
        new CustomerAccountRepository();

    private static readonly ReservationRepository _reservationRepo =
        new ReservationRepository();

    private static readonly RentalRepository _rentalRepo =
        new RentalRepository();

    private static readonly VehicleRepository _vehicleRepo =
        new VehicleRepository();

    private static readonly VehicleCategoryRepository _vehicleCategoryRepo =
        new VehicleCategoryRepository();

    private static readonly VehicleFeatureRepository _vehicleFeatureRepo =
        new VehicleFeatureRepository();

    private static readonly VehicleFeatureMappingRepository _vehicleFeatureMapRepo =
        new VehicleFeatureMappingRepository();

    private static readonly VehicleImageRepository _vehicleImageRepo =
        new VehicleImageRepository();

    private static readonly MaintenanceRepository _maintenanceRepo =
        new MaintenanceRepository();

    private static readonly RateConfigurationRepository _rateConfigRepo =
        new RateConfigurationRepository();

    private static readonly InvoiceRepository _invoiceRepo =
        new InvoiceRepository();

    private static readonly InvoiceLineItemRepository _invoiceLineItemRepo =
        new InvoiceLineItemRepository();

    private static readonly PaymentRepository _paymentRepo =
        new PaymentRepository();

    private static readonly DamageRepository _damageRepo =
        new DamageRepository();

    private static readonly DamageReportRepository _damageReportRepo =
        new DamageReportRepository();

    private static readonly VehicleInspectionRepository _inspectionRepo =
        new VehicleInspectionRepository();

    // =====================================================
    // SERVICES (SINGLETON)
    // =====================================================

    public static DriversLicenseService DriversLicenseService { get; } =
        new DriversLicenseService();

    public static CustomerAccountService CustomerAccountService { get; } =
        new CustomerAccountService(_customerAccountRepo);

    public static CustomerService CustomerService { get; } =
        new CustomerService(
            DriversLicenseService,
            CustomerAccountService
        );

    public static VehicleService VehicleService { get; } =
        new VehicleService(
            _vehicleRepo,
            _vehicleCategoryRepo,
            _vehicleFeatureRepo,
            _vehicleFeatureMapRepo,
            _vehicleImageRepo,
            _maintenanceRepo,
            _rateConfigRepo
        );

    public static ReservationService ReservationService { get; } =
        new ReservationService(
            CustomerService,
            VehicleService,
            _reservationRepo
        );

    public static RateService RateService { get; } =
        new RateService(_rateConfigRepo);

    public static BillingService BillingService { get; } =
        new BillingService(
            _rentalRepo,
            ReservationService,
            VehicleService,
            RateService,
            _invoiceRepo,
            _invoiceLineItemRepo,
            _paymentRepo,
            _damageReportRepo
        );

    public static RentalService RentalService { get; } =
        new RentalService(
            ReservationService,
            VehicleService,
            _rentalRepo,
            BillingService,
            _inspectionRepo,
            _damageRepo,
            _damageReportRepo
        );
}
