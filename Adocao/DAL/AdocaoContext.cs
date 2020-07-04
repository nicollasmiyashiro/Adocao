using Adocao.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Adocao.DAL
{
    public class AdocaoContext : DbContext
    {
        public AdocaoContext() : base("AdocaoContext")
        {
        }

        public DbSet<ContratoAdocao> ContratosAdocao { get; set; }
        public DbSet<ONG> ONGs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}