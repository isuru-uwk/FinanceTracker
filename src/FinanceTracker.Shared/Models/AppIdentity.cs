namespace FinanceTracker.Shared.Models
{
    public partial class AppIdentity
    {
        public int UserId { get; set; }
        public string Name { get; set; } = default!;
        public string Email { get; set; } = default!;
        //public Roles Roles { get; set; }
    }
}
