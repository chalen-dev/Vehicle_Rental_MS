using VRMS.Database.StoredProcedures.Customers.EmergencyContact;

namespace VRMS.Database.Migrations;

public static class M_1018_CreateEmergencyContactProcedures
{
    public static string Create() => $"""
                                      {SP_EmergencyContacts_Create.Sql()}
                                      {SP_EmergencyContacts_Update.Sql()}
                                      {SP_EmergencyContacts_Delete.Sql()}
                                      {SP_EmergencyContacts_GetByCustomerId.Sql()}
                                      """;

    public static string Drop() => """
                                   DROP PROCEDURE IF EXISTS sp_emergency_contacts_create;
                                   DROP PROCEDURE IF EXISTS sp_emergency_contacts_update;
                                   DROP PROCEDURE IF EXISTS sp_emergency_contacts_delete;
                                   DROP PROCEDURE IF EXISTS sp_emergency_contacts_get_by_customer_id;
                                   """;
}