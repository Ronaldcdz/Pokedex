using System;
using Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Database
{
    public class ApplicationContext : DbContext
    {

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<Pokemon> Pokemons { get; set; }

        public DbSet<PokemonRegion> Regions { get; set; }

        public DbSet<PokemonType> Types { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            #region tables
            modelBuilder.Entity<Pokemon>().ToTable("Pokemons");
            modelBuilder.Entity<PokemonRegion>().ToTable("Regions");
            modelBuilder.Entity<PokemonType>().ToTable("Types");
            #endregion


            #region "primary keys"
            modelBuilder.Entity<Pokemon>().HasKey(pokemon => pokemon.Id);
            modelBuilder.Entity<PokemonRegion>().HasKey(region => region.Id);
            modelBuilder.Entity<PokemonType>().HasKey(type => type.Id);
            #endregion

            #region relationships
            modelBuilder.Entity<PokemonRegion>()
                .HasMany<Pokemon>(region => region.Pokemons)
                .WithOne(pokemon => pokemon.Region)
                .HasForeignKey(pokemon => pokemon.RegionId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Pokemon>()
                .HasMany<PokemonType>(pokemon => pokemon.Type)
                .WithMany(type => type.Pokemons);
            #endregion

            #region "property configurations"


            #region pokemons
            modelBuilder.Entity<Pokemon>()
                .Property(pokemon => pokemon.Name)
                .IsRequired();

            modelBuilder.Entity<Pokemon>()
                .Property(pokemon => pokemon.ImagePath)
                .IsRequired();

            modelBuilder.Entity<Pokemon>()
                .Property(pokemon => pokemon.RegionId)
                .IsRequired();

            modelBuilder.Entity<Pokemon>()
                .Property(pokemon => pokemon.TypePrimaryId)
                .IsRequired();



            #endregion

            #region regions
            modelBuilder.Entity<PokemonRegion>()
                .Property(region => region.Name)
                .IsRequired()
                .HasMaxLength(120);


            #endregion


            #region types
            modelBuilder.Entity<PokemonType>()
                .Property(type => type.Name)
                .IsRequired()
                .HasMaxLength(120);
                
            #endregion


            #endregion
        }


    }
}

