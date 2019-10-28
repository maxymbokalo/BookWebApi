using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using BookWebApi.DataAccess.Interfaces;
using BookWebApi.DataAccess.Mapping;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using BookWebApi.EntityFrameworkCore;
using BookWebApi.EntityFrameworkCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using BookWebApi.DataAccess.Services;
using BookWebApi.DataAccess.Validation;
using BookWebApi.EntityFrameworkCore.Models;
using BookWebApi.EntityFrameworkCore.Repository;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace BookWebApi
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddDbContext<WebApiBookDbContext>(options =>
                    options.UseMySql(Configuration.GetConnectionString("DefaultConnection")));
            
            services.AddMvc(opt => opt.Filters.Add(typeof(TranssactionRunner))).AddFluentValidation();
            //FluentValidation
            services.AddScoped<IAuthorValidator, AuthorValidator>();
            services.AddScoped<IBookValidator, BookValidator>();
            services.AddTransient<IValidator<Book>, BookValidationRules>();
            services.AddTransient<IValidator<Author>, AuthorValidationRules>();
            services.AddTransient<IBookValidationRules, BookValidationRules>();
            services.AddTransient<IAuthorValidationRules, AuthorValidationRules>();
            //Db
            services.AddScoped<IDbInitializer, DbInitializer>();
            services.AddScoped<DbContext, WebApiBookDbContext>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddTransient<IAuthorService, AuthorService>();
            services.AddTransient<IBookService, BookService>();
            //AutoMapper
            services.AddAutoMapper(typeof(Startup));

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            var mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            //Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Books Web Api", Version = "v1" });
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default1",
                    template: "{controller}/{action}/{id?}");
                routes.MapRoute(
                    name: "default2",
                    template: "{controller}/{id?}/{action}");
            });
        }
    }
}
