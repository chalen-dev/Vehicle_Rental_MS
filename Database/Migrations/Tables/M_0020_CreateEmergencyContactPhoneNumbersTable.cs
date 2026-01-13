namespace VRMS.Database.Migrations.Tables;

public static class M_0020_CreateEmergencyContactPhoneNumbersTable
{
    public static string Create() => """
                                     CREATE TABLE IF NOT EXISTS emergency_contact_phone_numbers (
                                         id INT AUTO_INCREMENT PRIMARY KEY,

                                         emergency_contact_id INT NOT NULL,

                                         phone_number VARCHAR(30) NOT NULL,

                                         is_primary BOOLEAN NOT NULL DEFAULT FALSE,

                                         CONSTRAINT fk_ec_phone_numbers_contact
                                             FOREIGN KEY (emergency_contact_id)
                                             REFERENCES emergency_contacts(id)
                                             ON DELETE CASCADE
                                     ) ENGINE=InnoDB;
                                     """;

    public static string Drop() => """
                                   DROP TABLE IF EXISTS emergency_contact_phone_numbers;
                                   """;
}
