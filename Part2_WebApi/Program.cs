
using CaseStudyPart2.Models;
using CaseStudyPart2.ViewRepository;
using Microsoft.EntityFrameworkCore;

namespace Part2_WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddTransient<IView, ViewOperations>();
            var connStr = "Data Source = 192.168.0.13\\sqlexpress,49753; Initial Catalog = IVP_O_S_CS; user Id = sa; Password = sa@12345678; TrustServerCertificate = True";
            builder.Services.AddDbContext<ApplicationDBContext>(
                options => options.UseSqlServer(connStr)
                );

            // Add services to the container.

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

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());


            app.MapControllers();

            app.Run();
        }
    }
}
