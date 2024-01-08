using Microsoft.EntityFrameworkCore;
using TwitterClone.DatabaseAccessLayer.Contexts;
using TwitterClone.Business;
using TwitterClone.Business.ExternalServices.Interfaces;
using TwitterClone.Business.ExternalServices.Implements;

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
            builder.Services.AddSwaggerGen();

            // Custom Services
            builder.Services.AddDbContext<TwitterCloneDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddRepositories();
            builder.Services.AddServices();
            builder.Services.AddBusinessLayer();
            builder.Services.AddUserIdentity();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}