namespace MidStore.Data.Models
{
    public class Purchase
    {
        public Guid Id { get; set; }
        public Guid? MediaId { get; set; }
        public string? UserId { get; set; }
        public DateTime? PurchaseDateTime { get; set; }
    }
}