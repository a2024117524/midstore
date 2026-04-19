namespace MidStore.Data.Models
{
    public class Media
    {
        public Guid Id { get; set; }
        public string? UserId { get; set; }
        public string? UserName { get; set; }
        public DateTime? UploadDateTime { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public bool? Explicit { get; set; }
        public bool? Private { get; set; }
        public string? Cover { get; set; }
        public string? File { get; set; }
    }
}