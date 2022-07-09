using MB.Domain.Article;
using MB.Domain.ArticleCategory;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MB.Infrastructure.EfCore.Mappings
{
    public class ArticleMapping:IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.ToTable("Articles");
            builder.HasKey(a => a.ArticleId);

            builder.Property(a => a.Title)
                .HasMaxLength(500);

            builder.Property(a => a.ShortDescription)
                .HasMaxLength(500);

            builder.Property(a => a.Content)
                .IsRequired(false);

            builder.Property(a => a.Image)
                .HasMaxLength(500);

            builder.Property(a => a.IsDeleted);

            builder.Property(a => a.CreationDate);

            builder.HasOne<ArticleCategory>(a => a.ArticleCategory)
                .WithMany(c => c.Articles)
                .HasForeignKey(a => a.ArticleCategoryId);
        }
    }
}
