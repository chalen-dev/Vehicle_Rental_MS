using VRMS.Models.Accounts;

namespace VRMS.UI.Config.Support
{
    public static class Session
    {
        public static User? CurrentUser { get; set; }
        public static CustomerAccount? CurrentCustomer { get; set; }
    }
}