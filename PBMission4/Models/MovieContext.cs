using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PBMission4.Models
{
    public class MovieContext : DbContext
    {
        //Constructor
        public MovieContext (DbContextOptions<MovieContext> options) : base (options)
        {
            //Leave blank for now
        }

        public DbSet<MovieSubmitModel> MovieSubmissions { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<MovieSubmitModel>().HasData(
                
                new MovieSubmitModel
                {
                    MovieId = 1,
                    Category = "Comedy",
                    Title = "Anchorman",
                    Year = 2004,
                    Director = "Adam McKay",
                    Rating = "PG-13"
                },
                new MovieSubmitModel
                {
                    MovieId = 2,
                    Category = "Comedy",
                    Title = "Scott Pilgrim Vs. The World",
                    Year = 2010,
                    Director = "Edgar Wright",
                    Rating = "PG-13"
                },
                new MovieSubmitModel
                {
                    MovieId = 3,
                    Category = "Horror/Suspense",
                    Title = "The Thing",
                    Year = 1982,
                    Director = "John Carpenter",
                    Rating = "PG-13"
                }
                );
        }
    }
}
