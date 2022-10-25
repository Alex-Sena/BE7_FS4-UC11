using Microsoft.EntityFrameworkCore;
using ExoApi.Models;
using System.Security.Cryptography.X509Certificates;

namespace ExoApi.Contexts
{
    public class dbExoAPIContext : DbContext
    {
        public dbExoAPIContext()
        {
        }
        public dbExoAPIContext(DbContextOptions<dbExoAPIContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source = DESKTOP-NHJ4IH5\\SQLEXPRESS; initial catalog = dbExoApi; User Id = sa1; Password = vip12345");

            }            
        }
        public DbSet<Projeto> Projetos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
