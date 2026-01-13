using VRMS.Database.DBHelpers.EnumHelper;
using VRMS.Enums;

namespace VRMS.Database.Migrations.Tables;

public static class M_0015_CreatePaymentsTable
{
    public static string Create() => $"""
                                      CREATE TABLE IF NOT EXISTS payments (
                                          id INT AUTO_INCREMENT PRIMARY KEY,
                                          invoice_id INT NOT NULL,
                                          amount DECIMAL(10,2) NOT NULL,
                                          payment_method {Tbl.ToEnum<PaymentMethod>()} NOT NULL,
                                          payment_type {Tbl.ToEnum<PaymentType>()} NOT NULL,
                                          payment_date DATETIME NOT NULL,

                                          CONSTRAINT fk_payments_invoice
                                              FOREIGN KEY (invoice_id)
                                              REFERENCES invoices(id)
                                              ON DELETE CASCADE
                                      ) ENGINE=InnoDB;
                                      """;

    
    public static string Drop() => """
                                   DROP TABLE IF EXISTS payments;
                                   """;

}