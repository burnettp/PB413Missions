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

        public DbSet<MovieSubmitModel> MovieSubmissions { get; set; } //One instance of MovieSubmitModel is a MovieSubmission
        public DbSet<Category> Categories { get; set; }


        //Seeding Data
        protected override void OnModelCreating(ModelBuilder mb)
        {
            //List of Categories
            mb.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Comedy" },
                new Category { CategoryId = 2, CategoryName = "Horror/Suspense" },
                new Category { CategoryId = 3, CategoryName = "Drama" },
                new Category { CategoryId = 4, CategoryName = "Family" },
                new Category { CategoryId = 5, CategoryName = "Miscellaneous" },
                new Category { CategoryId = 6, CategoryName = "Television" },
                new Category { CategoryId = 7, CategoryName = "VHS" },
                new Category { CategoryId = 8, CategoryName = "Action/Adventure" }
            );

            mb.Entity<MovieSubmitModel>().HasData(
                
                new MovieSubmitModel
                {
                    MovieId = 1,
                    CategoryId = 1,
                    Title = "Anchorman",
                    Year = 2004,
                    Director = "Adam McKay",
                    Rating = "PG-13"
                },
                new MovieSubmitModel
                {
                    MovieId = 2,
                    CategoryId = 1,
                    Title = "Scott Pilgrim Vs. The World",
                    Year = 2010,
                    Director = "Edgar Wright",
                    Rating = "PG-13"
                },
                new MovieSubmitModel
                {
                    MovieId = 3,
                    CategoryId = 2,
                    Title = "The Thing",
                    Year = 1982,
                    Director = "John Carpenter",
                    Rating = "PG-13"
                }
                );
        }
    }
}
