using Microsoft.EntityFrameworkCore;
using TwitterClone.DatabaseAccessLayer.Contexts;
using TwitterClone.Business;
using TwitterClone.Business.ExternalServices.Interfaces;
using TwitterClone.Business.ExternalServices.Implements;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Identity;
using TwitterClone.Core.Entities;
using TwitterClone.Core;
using System.Text;
using System.Data;
using System.IO;
using TwitterClone.Business.Exceptions.Role;
using TwitterClone.Business.Exceptions.AppUser;
using TwitterClone.API.Helpers;

namespace TwitterClone.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "MyAPI", Version = "v1" });

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "bearer"
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type=ReferenceType.SecurityScheme,
                                Id="Bearer"
                            }
                        },
                        new string[]{}
                    }
                });
            });

            // Custom settings
            var jwt = builder.Configuration.GetSection("Jwt").Get<Jwt>();

            // Database Context
            builder.Services.AddDbContext<TwitterCloneDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Business Service Registration
            builder.Services.AddRepositories();
            builder.Services.AddServices();
            builder.Services.AddBusinessLayer();

            // Api Service Registration
            builder.Services.AddUserIdentity();

            // Auth
            builder.Services.AddAuth(jwt);

            // Http Context Accessor
            builder.Services.AddHttpContextAccessor();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSeedData();

                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.ConfigObject.AdditionalItems.Add("persistAuthorization", "true");
                });
            }

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}