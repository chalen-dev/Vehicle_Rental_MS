using VRMS.Database.StoredProcedures.Customers.EmergencyContactPhoneNumber;

namespace VRMS.Database.Migrations;

public static class M_1019_CreateEmergencyContactPhoneNumberProcedures
{
    public static string Create() => $"""
                                      {SP_EmergencyContactPhoneNumbers_Create.Sql()}
                                      {SP_EmergencyContactPhoneNumbers_Update.Sql()}
                                      {SP_EmergencyContactPhoneNumbers_Delete.Sql()}
                                      {SP_EmergencyContactPhoneNumbers_GetByEmergencyContactId.Sql()}
                                      """;

    public static string Drop() => """
                                   DROP PROCEDURE IF EXISTS sp_emergency_contact_phone_numbers_create;
                                   DROP PROCEDURE IF EXISTS sp_emergency_contact_phone_numbers_update;
                                   DROP PROCEDURE IF EXISTS sp_emergency_contact_phone_numbers_delete;
                                   DROP PROCEDURE IF EXISTS sp_emergency_contact_phone_numbers_get_by_contact_id;
                                   """;
}