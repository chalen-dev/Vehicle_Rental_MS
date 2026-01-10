using System.Data;
using VRMS.Database;
using VRMS.Models.Customers;

namespace VRMS.Services.Customer;

public class EmergencyContactService
{
    // ----------------------------
    // EMERGENCY CONTACTS
    // ----------------------------

    public int CreateEmergencyContact(
        int customerId,
        string firstName,
        string lastName,
        string relationship
    )
    {
        var table = DB.Query(
            "CALL sp_emergency_contacts_create(@customerId, @first, @last, @relationship);",
            ("@customerId", customerId),
            ("@first", firstName),
            ("@last", lastName),
            ("@relationship", relationship)
        );

        return Convert.ToInt32(table.Rows[0]["emergency_contact_id"]);
    }

    public void UpdateEmergencyContact(
        int emergencyContactId,
        string firstName,
        string lastName,
        string relationship
    )
    {
        DB.Execute(
            "CALL sp_emergency_contacts_update(@id, @first, @last, @relationship);",
            ("@id", emergencyContactId),
            ("@first", firstName),
            ("@last", lastName),
            ("@relationship", relationship)
        );
    }

    public void DeleteEmergencyContact(int emergencyContactId)
    {
        DB.Execute(
            "CALL sp_emergency_contacts_delete(@id);",
            ("@id", emergencyContactId)
        );
    }

    public List<EmergencyContact> GetEmergencyContactsByCustomerId(int customerId)
    {
        var table = DB.Query(
            "CALL sp_emergency_contacts_get_by_customer_id(@customerId);",
            ("@customerId", customerId)
        );

        var list = new List<EmergencyContact>();
        foreach (DataRow row in table.Rows)
            list.Add(MapEmergencyContact(row));

        return list;
    }

    // ----------------------------
    // EMERGENCY CONTACT PHONE NUMBERS
    // ----------------------------

    public int AddEmergencyContactPhoneNumber(
        int emergencyContactId,
        string phoneNumber
    )
    {
        var table = DB.Query(
            "CALL sp_emergency_contact_phone_numbers_create(@contactId, @phone);",
            ("@contactId", emergencyContactId),
            ("@phone", phoneNumber)
        );

        return Convert.ToInt32(table.Rows[0]["phone_number_id"]);
    }

    public void UpdateEmergencyContactPhoneNumber(
        int phoneNumberId,
        string phoneNumber
    )
    {
        DB.Execute(
            "CALL sp_emergency_contact_phone_numbers_update(@id, @phone);",
            ("@id", phoneNumberId),
            ("@phone", phoneNumber)
        );
    }

    public void DeleteEmergencyContactPhoneNumber(int phoneNumberId)
    {
        DB.Execute(
            "CALL sp_emergency_contact_phone_numbers_delete(@id);",
            ("@id", phoneNumberId)
        );
    }

    public List<string> GetEmergencyContactPhoneNumbers(int emergencyContactId)
    {
        var table = DB.Query(
            "CALL sp_emergency_contact_phone_numbers_get_by_contact_id(@contactId);",
            ("@contactId", emergencyContactId)
        );

        var list = new List<string>();
        foreach (DataRow row in table.Rows)
            list.Add(row["phone_number"].ToString()!);

        return list;
    }

    // ----------------------------
    // MAPPING
    // ----------------------------

    private static EmergencyContact MapEmergencyContact(DataRow row)
    {
        return new EmergencyContact
        {
            Id = Convert.ToInt32(row["id"]),
            CustomerId = Convert.ToInt32(row["customer_id"]),
            FirstName = row["first_name"].ToString()!,
            LastName = row["last_name"].ToString()!,
            Relationship = row["relationship"].ToString()!
        };
    }
}
