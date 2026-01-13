using System.Collections.Generic;
using VRMS.Models.Customers;
using VRMS.Repositories.Customers;

namespace VRMS.Services.Customer;

/// <summary>
/// Provides business logic for managing customer emergency contacts.
///
/// This service is responsible for:
/// - Creating, updating, and deleting emergency contacts
/// - Managing phone numbers associated with emergency contacts
///
/// All operations are delegated to repositories without
/// altering or inferring business rules.
/// </summary>
public class EmergencyContactService
{
    /// <summary>
    /// Repository for emergency contact records.
    /// </summary>
    private readonly EmergencyContactRepository _contactRepo;

    /// <summary>
    /// Repository for emergency contact phone numbers.
    /// </summary>
    private readonly EmergencyContactPhoneNumberRepository _phoneRepo;

    /// <summary>
    /// Initializes the emergency contact service.
    /// </summary>
    public EmergencyContactService()
    {
        _contactRepo = new EmergencyContactRepository();
        _phoneRepo   = new EmergencyContactPhoneNumberRepository();
    }

    // ----------------------------
    // EMERGENCY CONTACTS
    // ----------------------------

    /// <summary>
    /// Creates a new emergency contact for a customer.
    /// </summary>
    /// <param name="customerId">Customer ID</param>
    /// <param name="firstName">Contact first name</param>
    /// <param name="lastName">Contact last name</param>
    /// <param name="relationship">Relationship to the customer</param>
    /// <returns>Newly created emergency contact ID</returns>
    public int CreateEmergencyContact(
        int customerId,
        string firstName,
        string lastName,
        string relationship
    )
    {
        return _contactRepo.Create(
            customerId,
            firstName,
            lastName,
            relationship
        );
    }

    /// <summary>
    /// Updates an existing emergency contact.
    /// </summary>
    /// <param name="emergencyContactId">Emergency contact ID</param>
    /// <param name="firstName">Updated first name</param>
    /// <param name="lastName">Updated last name</param>
    /// <param name="relationship">Updated relationship</param>
    public void UpdateEmergencyContact(
        int emergencyContactId,
        string firstName,
        string lastName,
        string relationship
    )
    {
        _contactRepo.Update(
            emergencyContactId,
            firstName,
            lastName,
            relationship
        );
    }

    /// <summary>
    /// Deletes an emergency contact.
    /// </summary>
    /// <param name="emergencyContactId">Emergency contact ID</param>
    public void DeleteEmergencyContact(int emergencyContactId)
    {
        _contactRepo.Delete(emergencyContactId);
    }

    /// <summary>
    /// Retrieves all emergency contacts associated with a customer.
    /// </summary>
    /// <param name="customerId">Customer ID</param>
    /// <returns>List of emergency contacts</returns>
    public List<EmergencyContact> GetEmergencyContactsByCustomerId(int customerId)
    {
        return _contactRepo.GetByCustomerId(customerId);
    }

    // ----------------------------
    // EMERGENCY CONTACT PHONE NUMBERS
    // ----------------------------

    /// <summary>
    /// Adds a phone number to an emergency contact.
    /// </summary>
    /// <param name="emergencyContactId">Emergency contact ID</param>
    /// <param name="phoneNumber">Phone number</param>
    /// <param name="isPrimary"></param>
    /// <returns>Newly created phone number ID</returns>
    public int AddEmergencyContactPhoneNumber(
        int emergencyContactId,
        string phoneNumber,
        bool isPrimary
    )
    {
        return _phoneRepo.Create(
            emergencyContactId,
            phoneNumber,
            isPrimary
        );
    }

    /// <summary>
    /// Updates an emergency contact phone number.
    /// </summary>
    /// <param name="phoneNumberId">Phone number ID</param>
    /// <param name="phoneNumber">Updated phone number</param>
    /// <param name="isPrimary"></param>
    public void UpdateEmergencyContactPhoneNumber(
        int phoneNumberId,
        string phoneNumber,
        bool isPrimary
    )
    {
        _phoneRepo.Update(
            phoneNumberId,
            phoneNumber,
            isPrimary
        );
    }

    /// <summary>
    /// Deletes an emergency contact phone number.
    /// </summary>
    /// <param name="phoneNumberId">Phone number ID</param>
    public void DeleteEmergencyContactPhoneNumber(int phoneNumberId)
    {
        _phoneRepo.Delete(phoneNumberId);
    }

    /// <summary>
    /// Retrieves all phone numbers for a given emergency contact.
    /// </summary>
    /// <param name="emergencyContactId">Emergency contact ID</param>
    /// <returns>List of phone numbers</returns>
    public List<EmergencyContactPhoneNumber> GetEmergencyContactPhoneNumbers(
        int emergencyContactId
    )
    {
        return _phoneRepo.GetByEmergencyContactId(emergencyContactId);
    }
}
