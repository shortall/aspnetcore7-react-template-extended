using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TemplateApp.Domain.Model;

namespace TemplateApp.Data.EF.EntityConfig
{
    public class WeatherForecastConfig : IEntityTypeConfiguration<WeatherForecast>
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public void Configure(EntityTypeBuilder<WeatherForecast> builder)
        {
            builder.ToTable("WeatherForecast");
            builder.HasKey(x => x.Id);

            builder.Property(p => p.Id).HasColumnName("Id");
            builder.Property(p => p.Date).HasColumnName("Date");
            builder.Property(p => p.TemperatureC).HasColumnName("TemperatureC");
            builder.Property(p => p.Summary).HasColumnName("Summary");

            var seedData = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Id = index,
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            }).ToArray();

            builder.HasData(seedData);
        }
    }
}
