namespace BookShop
{
    using Data;
    using Initializer;
    using System;
    using System.Linq;
    using System.Text;
    using Models.Enums;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            // DbInitializer.ResetDatabase(db);

            //Age Restriction task
            // var command = Console.ReadLine();
            // var resultAgeRestriction = GetBooksByAgeRestriction(db, command);


            //Golden Books
            // var resultGoldenBooks = GetGoldenBooks(db);

            //Books by price
            var resultBooksByPrice = GetBooksByPrice(db);

            Console.WriteLine(resultBooksByPrice);
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
                result.AppendLine($"{b.Title} - ${b.Price}");
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
