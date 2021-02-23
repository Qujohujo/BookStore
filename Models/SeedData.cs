﻿using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder application)
        {
            BookStoreDbContext context = application.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<BookStoreDbContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.Books.Any())
            {
                context.Books.AddRange(

                    new Book
                    {
                        Title = "Les Miserables",
                        Author = "Victor Hugo",
                        Publisher = "Signet",
                        ISBN = "978-0451419439",
                        Category = "Fiction, Classic",
                        Price = 9.95M,
                        Pages = 1488,
                    },

                    new Book
                    {
                        Title = "Team of Rivals",
                        Author = "Doris Kearns Goodwin",
                        Publisher = "Simon & Schuster",
                        ISBN = "978-0743270755",
                        Category = "Non-Fiction, Biography",
                        Price = 14.58M,
                        Pages = 944,
                    },

                    new Book
                    {
                        Title = "The Snowball",
                        Author = "Alice Schroeder",
                        Publisher = "Bantam",
                        ISBN = "978-0553384611",
                        Category = "Non-Fiction, Biography",
                        Price = 21.54M,
                        Pages = 832,
                    },

                    new Book
                    {
                        Title = "American Ulysses",
                        Author = "Ronald C. White",
                        Publisher = "Random House",
                        ISBN = "978-0812981254",
                        Category = "Non-Fiction, Biography",
                        Price = 11.61M,
                        Pages = 864,
                    },

                    new Book
                    {
                        Title = "Unbroken",
                        Author = "Laura Hillenbrand",
                        Publisher = "Random House",
                        ISBN = "978-0812974492",
                        Category = "Non-Fiction, Historical",
                        Price = 13.33M,
                        Pages = 528,
                    },

                    new Book
                    {
                        Title = "The Great Train Robbery",
                        Author = "Michael Crichton",
                        Publisher = "Vintage",
                        ISBN = "978-0804171281",
                        Category = "Fiction, Historical Fiction",
                        Price = 15.95M,
                        Pages = 288,
                    },

                    new Book
                    {
                        Title = "Deep Work",
                        Author = "Cal Newport",
                        Publisher = "Grand Publishing Central",
                        ISBN = "978-1455586691",
                        Category = "Non-Fiction, Self-Help",
                        Price = 14.99M,
                        Pages = 304,
                    },

                    new Book
                    {
                        Title = "It's Your Ship",
                        Author = "Michael Abrashoff",
                        Publisher = "Grand Publishing Central",
                        ISBN = "978-1455523023",
                        Category = "Non-Fiction, Self-Help",
                        Price = 21.66M,
                        Pages = 240,
                    },

                    new Book
                    {
                        Title = "The Virgin Way",
                        Author = "Richard Branson",
                        Publisher = "Portfolio",
                        ISBN = "978-1591847984",
                        Category = "Non-Fiction, Business",
                        Price = 29.16M,
                        Pages = 400,
                    },

                    new Book
                    {
                        Title = "Sycamore Row",
                        Author = "John Grisham",
                        Publisher = "Bantam",
                        ISBN = "978-0553393613",
                        Category = "Fiction, Thrillers",
                        Price = 15.03M,
                        Pages = 642,
                    },

                    new Book
                    {
                        Title = "Mistborn",
                        Author = "Brandon Sanderson",
                        Publisher = "Tor Books",
                        ISBN = "978-0575089914",
                        Category = "Fiction, Fantasy",
                        Price = 12.56M,
                        Pages = 541,
                    },

                    new Book
                    {
                        Title = "How to Win Friends and Influence People",
                        Author = "Dale Carnegie",
                        Publisher = "Simon and Schuster",
                        ISBN = "978-0671027032",
                        Category = "Non-Fiction, Self-Help",
                        Price = 17.99M,
                        Pages = 291,
                    },

                    new Book
                    {
                        Title = "The Way of Kings",
                        Author = "Brandon Sanderson",
                        Publisher = "Tor Books",
                        ISBN = "978-0575102484",
                        Category = "Fiction, Epic Fantasy",
                        Price = 9.59M,
                        Pages = 1007,
                    }

                );

                context.SaveChanges();
            }
        }
    }
}
