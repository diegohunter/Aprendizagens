using Angular.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace Angular.Data
{
    public class ContasContext : DbContext
    {
        IConfiguration Configuration { get; set; }

        public ContasContext() : base()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (Configuration != null)
                optionsBuilder.UseSqlServer("Data Source=RJ-TI02A-DSK;Database=Contas;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        public ContasContext(DbContextOptions<ContasContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transacao>().HasKey(x => x.TransacaoID);
            modelBuilder.Entity<TransacaoDetalhamento>().HasKey(x => x.TransacaoDetalhamentoID);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Transacao> Transacoes { get; set; }
        public DbSet<TransacaoDetalhamento> TransacoesDetalhamento { get; set; }
    

    }
}
