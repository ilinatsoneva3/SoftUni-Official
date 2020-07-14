namespace BookShop
{
    using Data;
    using Initializer;
    using System;
    using System.Linq;
    using System.Text;
    using Models.Enums;
    using System.Globalization;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            // DbInitializer.ResetDatabase(db);
                       
            var result = RemoveBooks(db);

            Console.WriteLine(result);
        }

        public static int RemoveBooks(BookShopContext context)
        {
            var books = context
                .Books
                .Where(b => b.Copies < 4200)
                .ToList();

            var count = books.Count();

            context.RemoveRange(books);
            context.SaveChanges();

            return count;
        }

        public static void IncreasePrices(BookShopContext context)
        {
            var books = context
                .Books
                .Where(b => b.ReleaseDate.Value.Year < 2010)
                .ToList();

            foreach (var book in books)
            {
                book.Price += 5;
            }

            context.SaveChanges();
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            var result = new StringBuilder();

            var books = context
                .Categories
                .Select(c => new
                {
                    c.Name,
                    LastThreeBooks = c.CategoryBooks
                                          .OrderByDescending(b => b.Book.ReleaseDate)
                                          .Take(3)
                                          .Select(b => new { BookTitle = b.Book.Title
                                          , BookYear = b.Book.ReleaseDate.Value.Year })
                })
                .OrderBy(c => c.Name)
                .ToList();

            foreach (var item in books)
            {
                result.AppendLine($"--{item.Name}");

                foreach (var book in item.LastThreeBooks)
                {
                    result.AppendLine($"{book.BookTitle} ({book.BookYear})");
                }
            }

            return result.ToString().Trim();
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var result = new StringBuilder();

            var profit = context
                .Categories
                .Select(c => new
                {
                    c.Name,
                    TotalProfit = c.CategoryBooks.Sum(b => b.Book.Price * b.Book.Copies)
                })
                .OrderByDescending(x => x.TotalProfit)
                .ThenBy(x => x.Name)
                .ToList();

            foreach (var item in profit)
            {
                result.AppendLine($"{item.Name} ${item.TotalProfit:F2}");
            }

            return result.ToString().Trim();
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var result = new StringBuilder();

            var booksTotal = context
                .Authors
                .Select(b => new
                {
                    AuthorName = b.FirstName + " " + b.LastName,
                    TotalCount = b.Books.Sum(b => b.Copies)
                })
                .OrderByDescending(b => b.TotalCount)
                .ToList();

            foreach (var item in booksTotal)
            {
                result.AppendLine($"{item.AuthorName} - {item.TotalCount}");
            }

            return result.ToString().Trim();
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var booksCount = context
                .Books
                .Where(b => b.Title.Length > lengthCheck)
                .Select(b => b.Title)
                .ToList()
                .Count();

            return booksCount;
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var result = new StringBuilder();

            var booksAuthors = context
                .Books
                .OrderBy(b => b.BookId)
                .Select(b => new { b.Title, b.Author.FirstName, b.Author.LastName })
                .Where(a => a.LastName.ToLower().StartsWith(input.ToLower()))
                .ToList();

            foreach (var item in booksAuthors)
            {
                result.AppendLine($"{item.Title} ({item.FirstName} {item.LastName})");
            }

            return result.ToString().Trim();
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var result = context
                .Books
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToList();

            return string.Join(Environment.NewLine, result);
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var result = context
                .Authors
                .Where(a => a.FirstName.EndsWith(input))
                .Select(a => a.FirstName + " " + a.LastName)
                .OrderBy(a => a)
                .ToList();

            return string.Join(Environment.NewLine, result);
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var result = new StringBuilder();

            var parsedDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var books = context
                .Books
                .Where(b => b.ReleaseDate < parsedDate)
                .OrderByDescending(b=>b.ReleaseDate)
                .Select(b => new { b.Title, b.EditionType, b.Price })
                .ToList();

            books.ForEach(b =>
            {
                result.AppendLine($"{b.Title} - {b.EditionType} - ${b.Price:F2}");
            });

            return result.ToString().Trim();
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var result = new StringBuilder();

            var categories = input.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(c => c.ToLower())
                .ToList();

            var bookTitles = context
                .BooksCategories
                .Where(bc => categories.Contains(bc.Category.Name.ToLower()))
                .OrderBy(b=>b.Book.Title)
                .Select(b => b.Book.Title)
                .ToList();

            return string.Join(Environment.NewLine, bookTitles);
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var titles = context
                .Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList();
            
            return string.Join(Environment.NewLine, titles);
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            var result = new StringBuilder();

            var books = context
                .Books
                .Where(b => b.Price > 40)
                .OrderByDescending(b => b.Price)
                .Select(b => new { b.Title, b.Price })
                .ToList();

            books.ForEach(b =>
            {
                result.AppendLine($"{b.Title} - ${b.Price:F2}");
            });

            return result.ToString().Trim();
        }


        public static string GetGoldenBooks(BookShopContext context)
        {            
            var titles = context
                     .Books
                     .Where(b => b.EditionType == EditionType.Gold && b.Copies < 5000)
                     .OrderBy(b => b.BookId)
                     .Select(b => b.Title)
                     .ToList();

            return string.Join(Environment.NewLine, titles);
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var result = new StringBuilder();

            command = command.ToLower();

            var bookTitles = context
                .Books
                .AsEnumerable()
                .Where(b => b.AgeRestriction.ToString().ToLower() == command)
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToList();

            bookTitles.ForEach(b =>
            {
                result.AppendLine(b);
            });

            return result.ToString().Trim();
        }
    }
}
