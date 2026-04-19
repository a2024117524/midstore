namespace MidStore.Data.Models
{
    public class Profile
    {
        public Guid Id { get; set; }
        public string? UserId { get; set; }
        public string? Avatar { get; set; }
        public bool? Private { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}