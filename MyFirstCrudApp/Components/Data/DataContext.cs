using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyFirstCrudApp.Components.Models;

namespace MyFirstCrudApp.Components.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<VideoGame>().HasData(
                new VideoGame { Id = 1, Title = "Cyberpunk 2077", Publisher = "CD Project", ReleaseYear = 2020 },
                new VideoGame { Id = 2, Title = "Elden Ring", Publisher = "FromSoftware", ReleaseYear = 2022 },
                new VideoGame { Id = 3, Title = "Legend of Zelda", Publisher = "Nintendo", ReleaseYear = 2017 }
            );
        }
        public DbSet<VideoGame> VideoGames {get; set; }
    }
}