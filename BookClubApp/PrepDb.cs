
using BookClub.Memory;
using BookClub.Models.Entities;
using System;

namespace BookClubApp
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<MainContext>());
            }
        }

        private static void SeedData(MainContext context)
        {
            if (!context.Users.Any())
            {
                Console.WriteLine("--> Seeding Data...");
                context.Users.AddRange(
                    new User() { Name = "test1"},
                    new User() { Name = "test2"},
                    new User() { Name = "test3" }
                    );
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> We already have data");
            }

            if (!context.Books.Any())
            {
                Console.WriteLine("--> Seeding Data...");
                context.Books.AddRange(
                    new Book() { Title = "book 1" },
                    new Book() { Title = "book 2"},
                    new Book() { Title = "book 3" }
                    );
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> We already have data");
            }

        }
    }
}
