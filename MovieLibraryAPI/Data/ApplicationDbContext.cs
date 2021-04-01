using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieLibraryAPI.Data;
using MovieLibraryAPI.Models;

namespace MovieLibraryAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) 
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            builder.Entity<Movie>()
             .HasData(
                new Movie { Id = 1, Title = "The Departed", Genre = "Drama", DirectorName = "Martin Scorsese" },
                new Movie { Id = 2, Title = "The Dark Knight", Genre = "Drama", DirectorName = "Christopher Nolan" },
                new Movie { Id = 3, Title = "Inception", Genre = "Drama", DirectorName = "Christopher Nolan" }
                );

        }

        public DbSet<Movie> Movies { get; set; }

    }
}
