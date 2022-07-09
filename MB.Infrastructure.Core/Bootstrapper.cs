using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MB.Application;
using MB.Application.Contract.Article;
using MB.Application.Contract.ArticleCategory;
using MB.Domain.Article;
using MB.Domain.ArticleCategory;
using MB.Domain.ArticleCategory.Services;
using MB.Infrastructure.EfCore;
using MB.Infrastructure.EfCore.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MB.Infrastructure.Core
{
    public class Bootstrapper
    {
        public static void Config(IServiceCollection services, string connectionString)
        {
            services.AddScoped<IArticleCategoryApplication,ArticleCategoryApplication>();
            services.AddScoped<IArticleApplication,ArticleApplication>();
            services.AddScoped<IArticleCategoryRepository,ArticleCategoryRepository>();
            services.AddScoped<IArticleCategoryValidatorService,ArticleCategoryValidatorService>();
            services.AddScoped<IArticleApplication,ArticleApplication>();
            services.AddScoped<IArticleRepository,ArticleRepository>();
            services.AddDbContext<MasterBloggerContext>(options =>
                options.UseSqlServer(connectionString));
        }
    }
}
