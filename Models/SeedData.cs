using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LibApp.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                //Create DB if not exists
                context.Database.EnsureCreated();

                if (!context.Genres.Any())
                {
                    Console.WriteLine("Genres added to database");

                    context.Genres.AddRange(
                    new Genre
                    {
                        Id = 1,
                        Name = "Horror",
                    },
                    new Genre
                    {
                        Id = 2,
                        Name = "Fantasy",
                    },
                    new Genre
                    {
                        Id = 3,
                        Name = "Thriller",
                    }
                    );
                }

                if (!context.Books.Any())
                {
                    Console.WriteLine("Books added to database");

                    context.Books.AddRange(
                    new Book
                    {
                        Name = "Potop",
                        AuthorName = "H. Sienkiewicz",
                        GenreId = 1,
                        DataAdded = DateTime.Parse("19/02/2001"),
                        ReleaseDate = DateTime.Parse("06/05/1950"),
                        NumberInStock = 3,
                    },
                    new Book
                    {
                        Name = "Nowy wspanialy swiat",
                        AuthorName = "A. Huxley",
                        GenreId = 2,
                        DataAdded = DateTime.Parse("16/12/2000"),
                        ReleaseDate = DateTime.Parse("01/06/1962"),
                        NumberInStock = 5,
                    },
                    new Book
                    {
                        Name = "Diuna",
                        AuthorName = "F. Herbert",
                        GenreId = 3,
                        DataAdded = DateTime.Parse("21/11/2003"),
                        ReleaseDate = DateTime.Parse("05/06/1969"),
                        NumberInStock = 15,
                    }
                    );
                }

                if (!context.MembershipTypes.Any())
                {
                    Console.WriteLine("MembershipTypes added to database");
                    
                    context.MembershipTypes.AddRange(
                    new MembershipType
                    {
                        Id = 1,
                        Name="Pay as You go",
                        SignUpFee = 0,
                        DurationInMonths = 0,
                        DiscountRate = 0,
                    },
                    new MembershipType
                    {
                        Id = 2,
                        Name="Monthly",
                        SignUpFee = 30,
                        DurationInMonths = 1,
                        DiscountRate = 10,
                    },
                    new MembershipType
                    {
                        Id = 3,
                        Name="Quaterly",
                        SignUpFee = 90,
                        DurationInMonths = 3,
                        DiscountRate = 15,
                    },
                    new MembershipType
                    {
                        Id = 4,
                        Name="Yearly",
                        SignUpFee = 300,
                        DurationInMonths = 12,
                        DiscountRate = 20,
                    });
                }

                if (!context.Customers.Any())
                {
                    Console.WriteLine("Customers added to database");

                    context.Customers.AddRange(
                    new Customer
                    {
                        Name = "Jan Dzban",
                        HasNewsletterSubscribed = true,
                        MembershipTypeId = 3,
                        Birthdate = DateTime.Parse("05/05/1995")
                    },
                    new Customer
                    {
                        Name = "Janusz Tracz",
                        HasNewsletterSubscribed = false,
                        MembershipTypeId = 2,
                        Birthdate = DateTime.Parse("11/11/1998")
                    },
                    new Customer
                    {
                        Name = "Wojciech Świrpaleta",
                        HasNewsletterSubscribed = true,
                        MembershipTypeId = 4,
                        Birthdate = DateTime.Parse("05/10/2002")
                    }
                    );
                }

                context.SaveChanges();
            }
        }
    }
}
