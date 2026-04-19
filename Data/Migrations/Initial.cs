using FluentMigrator;
using MidStore.Data.Models;

namespace MidStore.Data.Migrations
{
    [Migration(2)]
    public class Initial : Migration
    {
        public override void Up()
        {
            Create.Table(nameof(Profile))
                .WithColumn(nameof(Profile.Id)).AsGuid().PrimaryKey()
                .WithColumn(nameof(Profile.UserId)).AsString().Nullable()
                .WithColumn(nameof(Profile.Avatar)).AsString().Nullable()
                .WithColumn(nameof(Profile.Private)).AsString().Nullable()
                .WithColumn(nameof(Profile.BirthDate)).AsDateTime().Nullable();

            Create.Table(nameof(Industry))
                .WithColumn(nameof(Industry.Id)).AsGuid().PrimaryKey()
                .WithColumn(nameof(Industry.Label)).AsString().Nullable();

            Create.Table(nameof(Genre))
                .WithColumn(nameof(Genre.Id)).AsGuid().PrimaryKey()
                .WithColumn(nameof(Genre.IndustryId)).AsGuid().Nullable()
                .WithColumn(nameof(Genre.Tag)).AsString().Nullable();

            Create.Table(nameof(Media))
                .WithColumn(nameof(Media.Id)).AsGuid().PrimaryKey()
                .WithColumn(nameof(Media.UserId)).AsString().Nullable()
                .WithColumn(nameof(Media.UserName)).AsString().Nullable()
                .WithColumn(nameof(Media.UploadDateTime)).AsDateTime().Nullable()
                .WithColumn(nameof(Media.Title)).AsString().Nullable()
                .WithColumn(nameof(Media.Description)).AsString().Nullable()
                .WithColumn(nameof(Media.Price)).AsDecimal().Nullable()
                .WithColumn(nameof(Media.Explicit)).AsBoolean().Nullable()
                .WithColumn(nameof(Media.Private)).AsBoolean().Nullable()
                .WithColumn(nameof(Media.Cover)).AsString().Nullable()
                .WithColumn(nameof(Media.File)).AsString().Nullable();

            Create.Table(nameof(Purchase))
               .WithColumn(nameof(Purchase.Id)).AsGuid().PrimaryKey()
               .WithColumn(nameof(Purchase.UserId)).AsString().Nullable()
               .WithColumn(nameof(Purchase.MediaId)).AsGuid().Nullable()
               .WithColumn(nameof(Purchase.PurchaseDateTime)).AsDateTime().Nullable();

            Create.Table(nameof(MediaGenre))
                .WithColumn(nameof(MediaGenre.Id)).AsGuid().PrimaryKey()
                .WithColumn(nameof(MediaGenre.GenreId)).AsGuid().Nullable()
                .WithColumn(nameof(MediaGenre.MediaId)).AsGuid().Nullable();
        }

        public override void Down()
        {
            Delete.Table(nameof(MediaGenre));
            Delete.Table(nameof(Purchase));
            Delete.Table(nameof(Media));
            Delete.Table(nameof(Genre));
            Delete.Table(nameof(Industry));
            Delete.Table(nameof(Profile));
        }
    }
}