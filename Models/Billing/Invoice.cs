using VRMS.Enums;

namespace VRMS.Models.Billing;

public class Invoice
{
    public int Id { get; set; }
    public int RentalId { get; set; }
    public decimal TotalAmount { get; set; }
    public DateTime GeneratedDate { get; set; }

    public InvoiceStatus Status { get; set; }
}