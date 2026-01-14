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

            return Convert.ToInt32(table.Rows[0]["inspection_id"]);
            
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

        public VehicleInspection GetById(int inspectionId)
        {
            var table = DB.Query(
                "CALL sp_vehicle_inspections_get_by_id(@id);",
                ("@id", inspectionId)
            );

            if (table.Rows.Count == 0)
                throw new InvalidOperationException("Vehicle inspection not found.");

            return Map(table.Rows[0]);
        }

        public void Update(
            int inspectionId,
            string notes,
            string fuelLevel,
            string cleanliness)
        {
            DB.Execute(
                "CALL sp_vehicle_inspections_update(@id,@notes,@fuel,@clean);",
                ("@id", inspectionId),
                ("@notes", notes),
                ("@fuel", fuelLevel),
                ("@clean", cleanliness)
            );
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
