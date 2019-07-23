using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RESTSqLite.BLL.Implementation;
using RESTSqLite.DAL.Models;
using RESTSqlLite.BLL.Interface.Services;
using AutoMapper;
using RESTSqLite.BLL.Interface.MapperProfiles;

namespace RESTSqLite.DependencyResolver
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddExternalServices(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<PostsContext>(options =>
               options.UseSqlite(connectionString));
            services.AddScoped<IPostService, PostService>();
            services.AddMapper();
            return services;
        }           

        private static void AddMapper(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new PostMappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
