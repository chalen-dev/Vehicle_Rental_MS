using VRMS.Enums;

namespace VRMS.Models.Billing;

public class Payment
{
    public int Id { get; set; }
    public int InvoiceId { get; set; }
    public decimal Amount { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public DateTime PaymentDate { get; set; }
}