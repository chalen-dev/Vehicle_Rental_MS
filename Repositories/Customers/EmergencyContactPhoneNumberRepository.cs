using System;
using System.Collections.Generic;
using System.Data;
using VRMS.Database;
using VRMS.Models.Customers;

namespace VRMS.Repositories.Customers;

public class EmergencyContactPhoneNumberRepository
{
    public int Create(int emergencyContactId, string phoneNumber, bool isPrimary)
    {
        var table = DB.Query(
            "CALL sp_emergency_contact_phone_numbers_create(@contactId, @phone, @isPrimary);",
            ("@contactId", emergencyContactId),
            ("@phone", phoneNumber),
            ("@isPrimary", isPrimary)
        );

        return Convert.ToInt32(table.Rows[0]["phone_number_id"]);
    }

    public void Update(int phoneNumberId, string phoneNumber, bool isPrimary)
    {
        DB.Execute(
            "CALL sp_emergency_contact_phone_numbers_update(@id, @phone, @isPrimary);",
            ("@id", phoneNumberId),
            ("@phone", phoneNumber),
            ("@isPrimary", isPrimary)
        );
    }

    public void Delete(int phoneNumberId)
    {
        DB.Execute(
            "CALL sp_emergency_contact_phone_numbers_delete(@id);",
            ("@id", phoneNumberId)
        );
    }

    public List<EmergencyContactPhoneNumber> GetByEmergencyContactId(int emergencyContactId)
    {
        var table = DB.Query(
            "CALL sp_emergency_contact_phone_numbers_get_by_contact_id(@contactId);",
            ("@contactId", emergencyContactId)
        );

        var list = new List<EmergencyContactPhoneNumber>();
        foreach (DataRow row in table.Rows)
        {
            list.Add(new EmergencyContactPhoneNumber
            {
                Id = Convert.ToInt32(row["id"]),
                EmergencyContactId = Convert.ToInt32(row["emergency_contact_id"]),
                PhoneNumber = row["phone_number"].ToString()!,
                IsPrimary = Convert.ToBoolean(row["is_primary"])
            });
        }

        return list;
    }
}
