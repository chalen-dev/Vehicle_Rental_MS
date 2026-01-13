using VRMS.Database.SPImplementations.Rentals.Rental;

namespace VRMS.Database.Migrations;

public static class M_1009_CreateRentalProcedures
{
    public static string Create() => $"""
                                      {SP_Rentals_Create.Sql()}
                                      {SP_Rentals_GetById.Sql()}
                                      {SP_Rentals_GetByReservation.Sql()}
                                      {SP_Rentals_Start.Sql()}
                                      {SP_Rentals_Complete.Sql()}
                                      {SP_Rentals_UpdateStatus.Sql()}
                                      {SP_Rentals_GetAll.Sql()}
                                      {SP_Rentals_GetByCustomer.Sql()}
                                      """;

    public static string Drop() => """
                                   DROP PROCEDURE IF EXISTS sp_rentals_create;
                                   DROP PROCEDURE IF EXISTS sp_rentals_get_by_id;
                                   DROP PROCEDURE IF EXISTS sp_rentals_get_by_reservation;
                                   DROP PROCEDURE IF EXISTS sp_rentals_start;
                                   DROP PROCEDURE IF EXISTS sp_rentals_complete;
                                   DROP PROCEDURE IF EXISTS sp_rentals_update_status;
                                   DROP PROCEDURE IF EXISTS sp_rentals_get_all;
                                   DROP PROCEDURE IF EXISTS sp_rentals_get_by_customer;
                                   """;
}