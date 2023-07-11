using Microsoft.EntityFrameworkCore;
using TemplateApp.Domain.Model;
//using System.ComponentModel;
using System.Reflection;
using TemplateApp.Data.EF.Converters;

namespace TemplateApp.Data.EF.Context
{
    /// <summary>
    /// Used to define Entity Framework DBContext configuration
    /// </summary>
    public class DashboardDBContext : DbContext
    {
        public DashboardDBContext(DbContextOptions options) : base(options) { }

        public DbSet<WeatherForecast> Requests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder builder)
        {
            builder.Properties<DateOnly>()
                .HaveConversion<DateOnlyConverter, DateOnlyComparer>()
                .HaveColumnType("date");

            base.ConfigureConventions(builder);
        }
    }
}