using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VRMS.Database.SPImplementations.Damages.DamageReport;


public static class SP_DamageReports_Delete
{
    public static string Sql() => """
        DROP PROCEDURE IF EXISTS sp_damage_reports_delete;

        CREATE PROCEDURE sp_damage_reports_delete (
            IN p_damage_report_id INT
        )
        BEGIN
            DELETE FROM damage_reports
            WHERE id = p_damage_report_id;
        END;
        """;
}
