using VRMS.Database.DBHelpers.EnumHelper;
using VRMS.Enums;

namespace VRMS.Database.Migrations.Tables;

public static class M_0014_CreateInvoicesTable
{
    public static string Create() => $"""
                                     CREATE TABLE IF NOT EXISTS invoices (
                                         id INT AUTO_INCREMENT PRIMARY KEY,
                                         rental_id INT NOT NULL,
                                         total_amount DECIMAL(10,2) NOT NULL DEFAULT 0,
                                         generated_date DATETIME NOT NULL,
                                         status {Tbl.ToEnum<InvoiceStatus>()} NOT NULL DEFAULT {InvoiceStatus.Unpaid}, 

                                         CONSTRAINT uq_invoices_rental
                                             UNIQUE (rental_id),

                                         CONSTRAINT fk_invoices_rental
                                             FOREIGN KEY (rental_id)
                                             REFERENCES rentals(id)
                                             ON DELETE RESTRICT
                                     ) ENGINE=InnoDB;
                                     """;

    public static string Drop() => """
                                   DROP TABLE IF EXISTS invoices;
                                   """;
}