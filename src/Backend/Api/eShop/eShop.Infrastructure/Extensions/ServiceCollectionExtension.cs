using eShop.Core.Interfaces.Repositories;
using eShop.Core.Interfaces.Services;
using eShop.Core.Services;
using eShop.Infrastructure.Data;
using eShop.Infrastructure.Repositories;
using eShop.SharedKernel.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDbContexts(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppShopDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
            );

            return services;
        }
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IUserRepository, MockUserRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserService, UserService>();
            //services.AddSingleton<IUriService>(provider =>
            //{
            //    var accesor = provider.GetRequiredService<IHttpContextAccessor>();
            //    var request = accesor.HttpContext.Request;
            //    var absoluteUri = string.Concat(request.Scheme, "://", request.Host.ToUriComponent());
            //    return new UriService(absoluteUri);
            //});

            return services;
        }
        public static IServiceCollection AddSwagger(this IServiceCollection services, string xmlFileName)
        {
            services.AddSwaggerGen(doc =>
            {
                doc.SwaggerDoc("v1", new OpenApiInfo { Title = "Social Media API", Version = "v1" });

                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFileName);
                doc.IncludeXmlComments(xmlPath);
            });

            return services;
        }

        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            return services;
        }
    }
}
