using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MB.Domain.ArticleCategory;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MB.Infrastructure.EfCore.Mappings
{
    public class ArticleCategoryMapping:IEntityTypeConfiguration<ArticleCategory>
    {
        public void Configure(EntityTypeBuilder<ArticleCategory> builder)
        {
            builder.ToTable("ArticleCategories");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title)
                .HasMaxLength(200);
            builder.Property(x => x.CreationDate);
            builder.Property(x=>x.IsDeleted);

            builder.HasMany(c => c.Articles)
                .WithOne(a => a.ArticleCategory)
                .HasForeignKey(a => a.ArticleCategoryId);
        }
    }
}
