using System.Data;
using VRMS.Database;
using VRMS.Enums;
using VRMS.Models.Billing;

namespace VRMS.Repositories.Billing;

public class PaymentRepository
{
    public int Create(
        int invoiceId,
        decimal amount,
        PaymentMethod method,
        PaymentType paymentType,
        DateTime date)
    {
        var table = DB.Query(
            "CALL sp_payments_create(@iid,@amount,@method,@ptype,@date);",
            ("@iid", invoiceId),
            ("@amount", amount),
            ("@method", method.ToString()),
            ("@ptype", paymentType.ToString()),
            ("@date", date)
        );

        return Convert.ToInt32(
            table.Rows[0]["payment_id"]);
    }


    public Payment GetById(int id)
    {
        var table = DB.Query(
            "CALL sp_payments_get_by_id(@id);",
            ("@id", id)
        );

        if (table.Rows.Count == 0)
            throw new InvalidOperationException(
                "Payment not found.");

        return Map(table.Rows[0]);
    }

    public List<Payment> GetByInvoice(int invoiceId)
    {
        var table = DB.Query(
            "CALL sp_payments_get_by_invoice(@iid);",
            ("@iid", invoiceId)
        );

        var list = new List<Payment>();
        foreach (DataRow row in table.Rows)
            list.Add(Map(row));

        return list;
    }

    // ---------------- MAPPING ----------------

    private static Payment Map(DataRow row)
    {
        return new Payment
        {
            Id = Convert.ToInt32(row["id"]),
            InvoiceId = Convert.ToInt32(row["invoice_id"]),
            Amount = Convert.ToDecimal(row["amount"]),
            PaymentMethod = Enum.Parse<PaymentMethod>(row["payment_method"].ToString()!, true),
            PaymentType = Enum.Parse<PaymentType>(row["payment_type"].ToString()!, true),
            PaymentDate = Convert.ToDateTime(row["payment_date"])
        };
    }

}