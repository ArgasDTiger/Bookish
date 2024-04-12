using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class BookContextSeed
{
    public static async Task SeedData(DbContext context)
        {
            // context.RemoveRange(context.Set<Book>());
            // context.RemoveRange(context.Set<Publisher>());
            // context.RemoveRange(context.Set<Genre>());
            // context.RemoveRange(context.Set<Author>());
            // await context.SaveChangesAsync();
            
            if (!context.Set<Book>().Any())
            {
                // Add publishers
                var publishers = new List<Publisher>
                {
                    new Publisher { Name = "Penguin Random House", PhoneNumber = "1234567890" },
                    new Publisher { Name = "HarperCollins", PhoneNumber = "1987654321" },
                    new Publisher { Name = "Simon & Schuster", PhoneNumber = "1122334455" },
                    new Publisher { Name = "Macmillan Publishers", PhoneNumber = "1555666777" },
                    new Publisher { Name = "Hachette Livre", PhoneNumber = "1443322111" }
                };
                await context.SaveChangesAsync();
                context.AddRange(publishers);
                await context.SaveChangesAsync();

                // Add genres
                var genres = new List<Genre>
                {
                    new Genre { Name = "Fantasy" },
                    new Genre { Name = "Science Fiction" },
                    new Genre { Name = "Mystery" },
                    new Genre { Name = "Romance" },
                    new Genre { Name = "Thriller" },
                    new Genre { Name = "Historical Fiction" },
                    new Genre { Name = "Horror" },
                    new Genre { Name = "Adventure" },
                    new Genre { Name = "Literary Fiction" },
                    new Genre { Name = "Young Adult" },
                    new Genre { Name = "Non-fiction" },
                    new Genre { Name = "Biography" },
                    new Genre { Name = "Memoir" },
                    new Genre { Name = "Self-Help" },
                    new Genre { Name = "Cookbook" }
                };
                context.AddRange(genres);
                await context.SaveChangesAsync();

                // Add authors
                var authors = new List<Author>
                {
                    new Author
                    {
                        Name = "J.K.",
                        Surname = "Rowling",
                        PenName = "Robert Galbraith",
                        ImageUrl = "J.K._Rowling.jpg",
                        BirthDate = new DateOnly(1965, 7, 31),
                        Country = "United Kingdom",
                        City = "Yate"
                    },
                    new Author
                    {
                        Name = "Stephen",
                        Surname = "King",
                        ImageUrl = "Stephen_King.jpg",
                        BirthDate = new DateOnly(1947, 9, 21),
                        Country = "United States",
                        City = "Portland"
                    },
                    new Author
                    {
                        Name = "Agatha",
                        Surname = "Christie",
                        PenName = "Mary Westmacott",
                        ImageUrl = "Agatha_Christie.jpg",
                        BirthDate = new DateOnly(1890, 9, 15),
                        Country = "United Kingdom",
                        City = "Torquay"
                    },
                    new Author
                    {
                        Name = "Jane",
                        Surname = "Austen",
                        ImageUrl = "Jane_Austen.jpg",
                        BirthDate = new DateOnly(1775, 12, 16),
                        Country = "United Kingdom",
                        City = "Steventon"
                    },
                    new Author
                    {
                        Name = "George",
                        Surname = "Orwell",
                        PenName = "Eric Arthur Blair",
                        ImageUrl = "George_Orwell.jpg",
                        BirthDate = new DateOnly(1903, 6, 25),
                        Country = "United Kingdom",
                        City = "Motihari"
                    },
                    new Author
                    {
                        Name = "Tara",
                        Surname = "Westover",
                        ImageUrl = "Tara_Westover.jpg",
                        BirthDate = new DateOnly(1986, 9, 27),
                        Country = "United States",
                        City = "Clifton"
                    },
                    new Author
                    {
                        Name = "Delia",
                        Surname = "Owens",
                        ImageUrl = "Delia_Owens.jpg",
                        BirthDate = new DateOnly(1949, 7, 18),
                        Country = "United States",
                        City = "Thomasville"
                    },
                    new Author
                    {
                        Name = "Alex",
                        Surname = "Michaelides",
                        ImageUrl = "Alex_Michaelides.jpg",
                        BirthDate = new DateOnly(1977, 8, 21),
                        Country = "Cyprus",
                        City = "Limassol"
                    },
                    new Author
                    {
                        Name = "Ann",
                        Surname = "Patchett",
                        ImageUrl = "Ann_Patchett.jpg",
                        BirthDate = new DateOnly(1963, 12, 2),
                        Country = "United States",
                        City = "Los Angeles"
                    },
                    new Author
                    {
                        Name = "Glendy",
                        Surname = "Vanderah",
                        ImageUrl = "Glendy_Vanderah.jpg",
                        BirthDate = new DateOnly(1988, 4, 24),
                        Country = "United States",
                        City = "Houston"
                    },
                    new Author
                    {
                        Name = "Margaret",
                        Surname = "Atwood",
                        ImageUrl = "Margaret_Atwood.jpg",
                        BirthDate = new DateOnly(1939, 11, 18),
                        Country = "Canada",
                        City = "Ottawa"
                    },
                    new Author
                    {
                        Name = "Heather",
                        Surname = "Morris",
                        ImageUrl = "Heather_Morris.jpg",
                        BirthDate = new DateOnly(1963, 10, 13),
                        Country = "New Zealand",
                        City = "Rotorua"
                    },
                    new Author
                    {
                        Name = "Jodi",
                        Surname = "Picoult",
                        ImageUrl = "Jodi_Picoult.jpg",
                        BirthDate = new DateOnly(1966, 5, 19),
                        Country = "United States",
                        City = "Nesconset"
                    },
                    new Author
                    {
                        Name = "Lisa",
                        Surname = "Wingate",
                        ImageUrl = "Lisa_Wingate.jpg",
                        BirthDate = new DateOnly(1964, 5, 16),
                        Country = "United States",
                        City = "Baylor"
                    },
                    new Author
                    {
                        Name = "Michelle",
                        Surname = "Obama",
                        ImageUrl = "Michelle_Obama.jpg",
                        BirthDate = new DateOnly(1964, 1, 17),
                        Country = "United States",
                        City = "Chicago"
                    }
                };
                context.AddRange(authors);
                await context.SaveChangesAsync();

                // Add books
                var books = new List<Book>
                {
                    new Book
                    {
                        ISBN = "9780439554930",
                        Title = "Harry Potter and the Philosopher's Stone",
                        Description = "The first book in the Harry Potter series.",
                        ImageUrl = "harry_potter.jpg",
                        Price = 15.99m,
                        PublishDate = new DateOnly(1997, 6, 26),
                        Publisher = publishers[0] // Penguin Random House
                    },
                    new Book
                    {
                        ISBN = "9781982123617",
                        Title = "The Institute",
                        Description = "A novel by Stephen King.",
                        ImageUrl = "the_institute.jpg",
                        Price = 24.99m,
                        PublishDate = new DateOnly(2019, 9, 10),
                        Publisher = publishers[1] // HarperCollins
                    },
                    new Book
                    {
                        ISBN = "9780007232833",
                        Title = "Murder on the Orient Express",
                        Description = "A detective novel by Agatha Christie.",
                        ImageUrl = "murder_orient_express.jpg",
                        Price = 12.50m,
                        PublishDate = new DateOnly(1934, 1, 1),
                        Publisher = publishers[2] // Simon & Schuster
                    },
                    new Book
                    {
                        ISBN = "9780141439501",
                        Title = "Pride and Prejudice",
                        Description = "A romantic novel by Jane Austen.",
                        ImageUrl = "pride_prejudice.jpg",
                        Price = 10.00m,
                        PublishDate = new DateOnly(1813, 1, 28),
                        Publisher = publishers[3] // Macmillan Publishers
                    },
                    new Book
                    {
                        ISBN = "9780452284244",
                        Title = "1984",
                        Description = "A dystopian novel by George Orwell.",
                        ImageUrl = "1984.jpg",
                        Price = 9.99m,
                        PublishDate = new DateOnly(1949, 6, 8),
                        Publisher = publishers[4] // Hachette Livre
                    },
                    new Book
                    {
                        ISBN = "9780062693025",
                        Title = "Where the Crawdads Sing",
                        Description = "A mystery novel by Delia Owens.",
                        ImageUrl = "where_crawdads_sing.jpg",
                        Price = 16.99m,
                        PublishDate = new DateOnly(2018, 8, 14),
                        Publisher = publishers[0] // Penguin Random House
                    },
                    new Book
                    {
                        ISBN = "9780062459367",
                        Title = "Educated",
                        Description = "A memoir by Tara Westover.",
                        ImageUrl = "educated.jpg",
                        Price = 18.99m,
                        PublishDate = new DateOnly(2018, 2, 20),
                        Publisher = publishers[1] // HarperCollins
                    },
                    new Book
                    {
                        ISBN = "9781524741669",
                        Title = "The Silent Patient",
                        Description = "A psychological thriller by Alex Michaelides.",
                        ImageUrl = "silent_patient.jpg",
                        Price = 22.00m,
                        PublishDate = new DateOnly(2019, 2, 5),
                        Publisher = publishers[2] // Simon & Schuster
                    },
                    new Book
                    {
                        ISBN = "9781984822185",
                        Title = "The Dutch House",
                        Description = "A novel by Ann Patchett.",
                        ImageUrl = "dutch_house.jpg",
                        Price = 19.95m,
                        PublishDate = new DateOnly(2019, 9, 24),
                        Publisher = publishers[3] // Macmillan Publishers
                    },
                    new Book
                    {
                        ISBN = "9781501136076",
                        Title = "Small Great Things",
                        Description = "A novel by Jodi Picoult.",
                        ImageUrl = "small_great_things.jpg",
                        Price = 16.99m,
                        PublishDate = new DateOnly(2016, 10, 11),
                        Publisher = publishers[4] // Hachette Livre
                    },
                    new Book
                    {
                        ISBN = "9781982121637",
                        Title = "Becoming",
                        Description = "A memoir by Michelle Obama.",
                        ImageUrl = "becoming.jpg",
                        Price = 22.99m,
                        PublishDate = new DateOnly(2018, 11, 13),
                        Publisher = publishers[0] // Penguin Random House
                    },
                    new Book
                    {
                        ISBN = "9781982102315",
                        Title = "Where the Forest Meets the Stars",
                        Description = "A novel by Glendy Vanderah.",
                        ImageUrl = "forest_meets_stars.jpg",
                        Price = 17.00m,
                        PublishDate = new DateOnly(2019, 3, 1),
                        Publisher = publishers[1] // HarperCollins
                    },
                    new Book
                    {
                        ISBN = "9781982127363",
                        Title = "The Testaments",
                        Description = "A novel by Margaret Atwood.",
                        ImageUrl = "testaments.jpg",
                        Price = 24.99m,
                        PublishDate = new DateOnly(2019, 9, 10),
                        Publisher = publishers[2] // Simon & Schuster
                    },
                    new Book
                    {
                        ISBN = "9780062457714",
                        Title = "The Tattooist of Auschwitz",
                        Description = "A novel by Heather Morris.",
                        ImageUrl = "tattooist_auschwitz.jpg",
                        Price = 15.99m,
                        PublishDate = new DateOnly(2018, 9, 4),
                        Publisher = publishers[3] // Macmillan Publishers
                    },
                    new Book
                    {
                        ISBN = "9780735219090",
                        Title = "Before We Were Yours",
                        Description = "A novel by Lisa Wingate.",
                        ImageUrl = "before_we_were_yours.jpg",
                        Price = 16.00m,
                        PublishDate = new DateOnly(2017, 6, 6),
                        Publisher = publishers[4] // Hachette Livre
                    }

                };
                
                books[0].Genres.Add(genres[0]);
                books[0].Genres.Add(genres[5]);
                books[0].Genres.Add(genres[10]);
                books[0].Authors.Add(authors[0]);

                books[1].Genres.Add(genres[1]);
                books[1].Genres.Add(genres[13]);
                books[1].Authors.Add(authors[1]);

                books[2].Genres.Add(genres[2]);
                books[2].Genres.Add(genres[12]);
                books[2].Authors.Add(authors[2]);

                books[3].Genres.Add(genres[3]);
                books[3].Genres.Add(genres[8]);
                books[3].Authors.Add(authors[3]);

                books[4].Genres.Add(genres[4]);
                books[4].Genres.Add(genres[9]);
                books[4].Authors.Add(authors[4]);

                books[5].Genres.Add(genres[0]);
                books[5].Genres.Add(genres[11]);
                books[5].Authors.Add(authors[5]);

                books[6].Genres.Add(genres[10]);
                books[6].Genres.Add(genres[11]);
                books[6].Authors.Add(authors[6]);

                books[7].Genres.Add(genres[2]);
                books[7].Genres.Add(genres[5]);
                books[7].Authors.Add(authors[7]);

                books[8].Genres.Add(genres[8]);
                books[8].Genres.Add(genres[11]);
                books[8].Authors.Add(authors[8]);

                books[9].Genres.Add(genres[3]);
                books[9].Genres.Add(genres[9]);
                books[9].Authors.Add(authors[9]);

                books[10].Genres.Add(genres[6]);
                books[10].Genres.Add(genres[11]);
                books[10].Authors.Add(authors[10]);

                books[11].Genres.Add(genres[7]);
                books[11].Genres.Add(genres[12]);
                books[11].Authors.Add(authors[11]);

                books[12].Genres.Add(genres[2]);
                books[12].Genres.Add(genres[5]);
                books[12].Authors.Add(authors[12]);

                books[13].Genres.Add(genres[8]);
                books[13].Genres.Add(genres[10]);
                books[13].Authors.Add(authors[13]);

                books[14].Genres.Add(genres[3]);
                books[14].Genres.Add(genres[9]);
                books[14].Authors.Add(authors[14]);
                
                await context.AddRangeAsync(books);
                await context.SaveChangesAsync();
                Console.WriteLine("Data is successfully seeded!");
            }
        }
    
}