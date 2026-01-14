using System;
using System.Data;
using VRMS.Database;
using VRMS.Enums;
using VRMS.Models.Damages;
using VRMS.Models.Rentals;

namespace VRMS.Repositories.Inspections
{
    public class VehicleInspectionRepository
    {
        public int Create(
            int rentalId,
            InspectionType inspectionType,
            string notes = "",
            string fuelLevel = "",
            string cleanliness = "")
        {
            var table = DB.Query(
                "CALL sp_vehicle_inspections_create(@rid, @type, @notes, @fuel, @clean);",
                ("@rid", rentalId),
                ("@type", inspectionType.ToString()),
                ("@notes", notes),
                ("@fuel", fuelLevel),
                ("@clean", cleanliness)
            );

            return Convert.ToInt32(table.Rows[0]["id"]);
            
        }

        /// <summary>
        /// Retrieves an inspection of a specific type for a rental.
        /// Stored procedure only accepts rentalId, so filtering
        /// by inspection type is done in C#.
        /// </summary>
        public VehicleInspection? GetByRental(
            int rentalId,
            InspectionType inspectionType)
        {
            var table = DB.Query(
                "CALL sp_vehicle_inspections_get_by_rental(@rid);",
                ("@rid", rentalId)
            );

            foreach (DataRow row in table.Rows)
            {
                var inspection = Map(row);

                if (inspection.InspectionType == inspectionType)
                    return inspection;
            }

            return null;
        }

        private static VehicleInspection Map(DataRow row)
        {
            return new VehicleInspection
            {
                Id = Convert.ToInt32(row["id"]),
                RentalId = Convert.ToInt32(row["rental_id"]),
                InspectionType = Enum.Parse<InspectionType>(
                    row["inspection_type"].ToString()!,
                    true),
                Notes = row["notes"]?.ToString() ?? "",
                FuelLevel = row["fuel_level"]?.ToString() ?? "",
                Cleanliness = row["cleanliness"]?.ToString() ?? ""
            };
        }
    }
}
