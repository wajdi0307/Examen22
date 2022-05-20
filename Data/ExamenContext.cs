using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
   public class ExamenContext:DbContext
    {
        public DbSet<Contrat> Contrats { get; set; }
        public DbSet<Equipe> Equipes { get; set; }
        public DbSet<Membre> Membres { get; set; }
        public DbSet<Trophee> Trophees { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
                                        Initial Catalog=RevEx;
                                        Integrated Security=true;
                                        MultipleActiveResultSets=true");
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);


        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contrat>().HasKey(c => new { c.DateContrat, c.EquipeFK, c.MembreFK  });
            modelBuilder.Entity<Membre>()
                .HasDiscriminator<String>("Type")
                .HasValue<Entraineur>("E")
                .HasValue<Joueur>("J");

        }
    }
}
