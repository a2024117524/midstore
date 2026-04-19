namespace MidStore.Data.Models
{
    public class MediaGenre
    {
        public Guid Id { get; set; }
        public Guid? GenreId { get; set; }
        public Guid? MediaId { get; set; }
    }
}