using FluentMigrator;
using MidStore.Data.Models;

namespace MidStore.Data.Migrations
{
    [Migration(3)]
    public class Seed : Migration
    {
        public override void Up()
        {
            var BooksId = Guid.NewGuid();
            var MoviesId = Guid.NewGuid();
            var MusicId = Guid.NewGuid();
            var ShowsId = Guid.NewGuid();

            Insert.IntoTable(nameof(Industry)).Row(new { Id = BooksId, Label = "Books" });
            Insert.IntoTable(nameof(Industry)).Row(new { Id = MoviesId, Label = "Movies" });
            Insert.IntoTable(nameof(Industry)).Row(new { Id = MusicId, Label = "Music" });
            Insert.IntoTable(nameof(Industry)).Row(new { Id = ShowsId, Label = "Shows" });

            Insert.IntoTable(nameof(Genre)).Row(new { Id = Guid.NewGuid(), IndustryId = BooksId, Tag = "Biographies" });
            Insert.IntoTable(nameof(Genre)).Row(new { Id = Guid.NewGuid(), IndustryId = BooksId, Tag = "Comics/Manga" });
            Insert.IntoTable(nameof(Genre)).Row(new { Id = Guid.NewGuid(), IndustryId = BooksId, Tag = "Erotica" });
            Insert.IntoTable(nameof(Genre)).Row(new { Id = Guid.NewGuid(), IndustryId = BooksId, Tag = "Fantasy/Sci-Fi" });
            Insert.IntoTable(nameof(Genre)).Row(new { Id = Guid.NewGuid(), IndustryId = BooksId, Tag = "History" });
            Insert.IntoTable(nameof(Genre)).Row(new { Id = Guid.NewGuid(), IndustryId = BooksId, Tag = "Poetry" });
            Insert.IntoTable(nameof(Genre)).Row(new { Id = Guid.NewGuid(), IndustryId = BooksId, Tag = "Romance" });
            Insert.IntoTable(nameof(Genre)).Row(new { Id = Guid.NewGuid(), IndustryId = BooksId, Tag = "Thriller" });

            Insert.IntoTable(nameof(Genre)).Row(new { Id = Guid.NewGuid(), IndustryId = MoviesId, Tag = "Action" });
            Insert.IntoTable(nameof(Genre)).Row(new { Id = Guid.NewGuid(), IndustryId = MoviesId, Tag = "Animated" });
            Insert.IntoTable(nameof(Genre)).Row(new { Id = Guid.NewGuid(), IndustryId = MoviesId, Tag = "Comedy" });
            Insert.IntoTable(nameof(Genre)).Row(new { Id = Guid.NewGuid(), IndustryId = MoviesId, Tag = "Documentaries" });
            Insert.IntoTable(nameof(Genre)).Row(new { Id = Guid.NewGuid(), IndustryId = MoviesId, Tag = "Fantasy/Sci-Fi" });
            Insert.IntoTable(nameof(Genre)).Row(new { Id = Guid.NewGuid(), IndustryId = MoviesId, Tag = "Musical" });
            Insert.IntoTable(nameof(Genre)).Row(new { Id = Guid.NewGuid(), IndustryId = MoviesId, Tag = "Romantic" });
            Insert.IntoTable(nameof(Genre)).Row(new { Id = Guid.NewGuid(), IndustryId = MoviesId, Tag = "Thriller" });

            Insert.IntoTable(nameof(Genre)).Row(new { Id = Guid.NewGuid(), IndustryId = MusicId, Tag = "African" });
            Insert.IntoTable(nameof(Genre)).Row(new { Id = Guid.NewGuid(), IndustryId = MusicId, Tag = "Classical" });
            Insert.IntoTable(nameof(Genre)).Row(new { Id = Guid.NewGuid(), IndustryId = MusicId, Tag = "Country" });
            Insert.IntoTable(nameof(Genre)).Row(new { Id = Guid.NewGuid(), IndustryId = MusicId, Tag = "Hip-Hop/Rap" });
            Insert.IntoTable(nameof(Genre)).Row(new { Id = Guid.NewGuid(), IndustryId = MusicId, Tag = "Pop" });
            Insert.IntoTable(nameof(Genre)).Row(new { Id = Guid.NewGuid(), IndustryId = MusicId, Tag = "R&B" });
            Insert.IntoTable(nameof(Genre)).Row(new { Id = Guid.NewGuid(), IndustryId = MusicId, Tag = "Reggae" });
            Insert.IntoTable(nameof(Genre)).Row(new { Id = Guid.NewGuid(), IndustryId = MusicId, Tag = "Rock" });

            Insert.IntoTable(nameof(Genre)).Row(new { Id = Guid.NewGuid(), IndustryId = ShowsId, Tag = "Action" });
            Insert.IntoTable(nameof(Genre)).Row(new { Id = Guid.NewGuid(), IndustryId = ShowsId, Tag = "Animated" });
            Insert.IntoTable(nameof(Genre)).Row(new { Id = Guid.NewGuid(), IndustryId = ShowsId, Tag = "Comedy" });
            Insert.IntoTable(nameof(Genre)).Row(new { Id = Guid.NewGuid(), IndustryId = ShowsId, Tag = "Drama" });
            Insert.IntoTable(nameof(Genre)).Row(new { Id = Guid.NewGuid(), IndustryId = ShowsId, Tag = "Documentaries" });
            Insert.IntoTable(nameof(Genre)).Row(new { Id = Guid.NewGuid(), IndustryId = ShowsId, Tag = "Fantasy/Sci-Fi" });
            Insert.IntoTable(nameof(Genre)).Row(new { Id = Guid.NewGuid(), IndustryId = ShowsId, Tag = "Musical" });
            Insert.IntoTable(nameof(Genre)).Row(new { Id = Guid.NewGuid(), IndustryId = ShowsId, Tag = "Lifestyle" });
            Insert.IntoTable(nameof(Genre)).Row(new { Id = Guid.NewGuid(), IndustryId = ShowsId, Tag = "Reality" });
        }

        public override void Down()
        {
            Delete.FromTable(nameof(Genre)).AllRows();
            Delete.FromTable(nameof(Industry)).AllRows();
        }
    }
}