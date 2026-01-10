using System;
using System.Collections.Generic;
using System.Data;
using VRMS.Database;
using VRMS.Models.Damages;

namespace VRMS.Repositories.Damages;

public class DamageRepository
{
    // ----------------------------
    // DAMAGE CATALOG (CRUD)
    // ----------------------------

    public int Create(string description, decimal estimatedCost)
    {
        var table = DB.Query(
            "CALL sp_damages_create(@desc, @cost);",
            ("@desc", description),
            ("@cost", estimatedCost)
        );

        return Convert.ToInt32(table.Rows[0]["damage_id"]);
    }

    public void Update(int damageId, string description, decimal estimatedCost)
    {
        DB.Execute(
            "CALL sp_damages_update(@id, @desc, @cost);",
            ("@id", damageId),
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

    public List<Damage> GetAll()
    {
        var table = DB.Query("CALL sp_damages_get_all();");

        var list = new List<Damage>();
        foreach (DataRow row in table.Rows)
            list.Add(Map(row));

        return list;
    }

    private static Damage Map(DataRow row)
    {
        return new Damage
        {
            Id = Convert.ToInt32(row["id"]),
            Description = row["description"].ToString()!,
            EstimatedCost = Convert.ToDecimal(row["estimated_cost"])
        };
    }
    
    
}