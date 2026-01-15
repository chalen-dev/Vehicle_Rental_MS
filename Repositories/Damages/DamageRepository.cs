using System;
using System.Collections.Generic;
using System.Data;
using VRMS.Database;
using VRMS.DTOs.Damage;
using VRMS.Enums;
using VRMS.Models.Damages;

namespace VRMS.Repositories.Damages
{
    public class DamageRepository
    {
        // ----------------------------
        // DAMAGE CATALOG (CRUD)
        // ----------------------------

        public int Create(
            int rentalId,
            DamageType damageType,
            string description,
            decimal estimatedCost)
        {
            var table = DB.Query(
                "CALL sp_damages_create(@rentalId, @type, @desc, @cost);",
                ("@rentalId", rentalId),
                ("@type", damageType.ToString()),
                ("@desc", description),
                ("@cost", estimatedCost)
            );

            return Convert.ToInt32(table.Rows[0]["damage_id"]);
        }

        public void Update(
            int damageId,
            DamageType damageType,
            string description,
            decimal estimatedCost)
        {
            DB.Execute(
                "CALL sp_damages_update(@id, @type, @desc, @cost);",
                ("@id", damageId),
                ("@type", damageType.ToString()),
                ("@desc", description),
                ("@cost", estimatedCost)
            );
        }

        public void Delete(int damageId)
        {
            DB.Execute(
                "CALL sp_damages_delete(@id);",
                ("@id", damageId)
            );
        }

        public Damage GetById(int damageId)
        {
            var table = DB.Query(
                "CALL sp_damages_get_by_id(@id);",
                ("@id", damageId)
            );

            if (table.Rows.Count == 0)
                throw new InvalidOperationException("Damage not found.");

            return Map(table.Rows[0]);
        }
        
        // ----------------------------
        // READ-ONLY VEHICLE INFO (VIA RENTAL)
        // ----------------------------
        public InspectionVehicleInfoDto GetVehicleInfoByDamage(int damageId)
        {
            var table = DB.Query(
                """
                SELECT
                    r.id            AS rental_number,
                    CONCAT(v.make, ' ', v.model) AS vehicle_model,
                    v.license_plate AS plate_number
                FROM damages d
                JOIN rentals r  ON r.id = d.rental_id
                JOIN vehicles v ON v.id = r.vehicle_id
                WHERE d.id = @damageId;
                """,
                ("@damageId", damageId)
            );

            if (table.Rows.Count == 0)
                throw new InvalidOperationException(
                    "Vehicle information not found for this damage.");

            var row = table.Rows[0];

            return new InspectionVehicleInfoDto
            {
                RentalNumber = Convert.ToInt32(row["rental_number"]),
                VehicleModel = row["vehicle_model"].ToString()!,
                PlateNumber  = row["plate_number"].ToString()!
            };
        }

        public List<Damage> GetAll()
        {
            var table = DB.Query(
                "CALL sp_damages_get_all();"
            );

            var list = new List<Damage>();
            foreach (DataRow row in table.Rows)
                list.Add(Map(row));

            return list;
        }
        

        // ----------------------------
        // MAPPING
        // ----------------------------

        private static Damage Map(DataRow row)
        {
            return new Damage
            {
                Id = Convert.ToInt32(row["id"]),
                RentalId = Convert.ToInt32(row["rental_id"]), // ✅ THIS WAS MISSING
                DamageType = Enum.Parse<DamageType>(
                    row["damage_type"].ToString()!,
                    ignoreCase: true),
                Description = row["description"].ToString()!,
                EstimatedCost = Convert.ToDecimal(row["estimated_cost"])
            };
        }
    }
}
