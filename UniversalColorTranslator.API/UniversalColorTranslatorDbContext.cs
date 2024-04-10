using UniversalColorTranslator.API.Model;
using UniversalColorTranslator.API.Interface;

using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace UniversalColorTranslator.API
{
    public class UniversalColorTranslatorDbContext : DbContext, IUniversalColorTranslatorDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
            var rootbuilder = builder.Build().AsEnumerable().ToList();
            string connectionString = (rootbuilder.Where(c => c.Key == "ConnectionString").Select(c => c.Value).FirstOrDefault()).ToString();
            optionsBuilder.UseNpgsql(connectionString);
        }

        public DbSet<Colors> Colors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Colors>(en => {
                en.ToTable("colors", "public");

                en.HasKey(e => e.ColorId)
                .HasName("colors_pkey");

                en.Property(e => e.ColorId)
                .HasColumnType("integer").
                HasColumnName("color_id");

                en.Property(e => e.ColorName)
                .HasColumnType("character varying").
                HasColumnName("color_name");

                en.Property(e => e.HexValue)
                .HasColumnType("character varying").
                HasColumnName("hex_value");
            });
        }

        void IDisposable.Dispose()
        {
            base.Dispose();
        }
    }
}
