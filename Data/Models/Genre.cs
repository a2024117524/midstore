namespace MidStore.Data.Models
{
    public class Genre
    {
        public Guid Id { get; set; }
        public Guid? IndustryId { get; set; }
        public string? Tag { get; set; }
    }
}