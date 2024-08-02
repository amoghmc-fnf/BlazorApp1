
using Microsoft.EntityFrameworkCore;
using ProductApi.Models;

namespace ProductApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<ProductDbContext>(options =>
            {
                var connString = builder.Configuration.GetConnectionString("FnfTrainingDb");
                options.UseSqlServer(connString);
            });

            builder.Services.AddCors(corsOptions =>
            {
                corsOptions.AddPolicy("cors", policy =>
                {
                    policy.AllowAnyHeader();
                    policy.AllowAnyMethod();
                    policy.AllowAnyOrigin();
                });
            });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("cors");
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
