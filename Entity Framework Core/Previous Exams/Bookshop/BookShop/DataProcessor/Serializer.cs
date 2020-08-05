namespace BookShop.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using BookShop.Data.Models.Enums;
    using BookShop.DataProcessor.ExportDto;
    using Data;
    using Newtonsoft.Json;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportMostCraziestAuthors(BookShopContext context)
        {
            var authors = context
                .Authors               
                .Select(a => new
                {
                    AuthorName = a.FirstName + " " + a.LastName,
                    Books = a.AuthorsBooks
                    .OrderByDescending(b => b.Book.Price)
                    .Select(b=>new
                    {
                        BookName = b.Book.Name,
                        BookPrice = b.Book.Price.ToString("F2")
                    })                    
                    .ToList()
                })
                .ToList()
                .OrderByDescending(a=>a.Books.Count)
                .ThenBy(a=>a.AuthorName)
                .ToList();

            var result = JsonConvert.SerializeObject(authors, Formatting.Indented);
            return result;
        }

        public static string ExportOldestBooks(BookShopContext context, DateTime date)
        {
            //Export top 10 oldest books that are published before the given date and are of type science. 
            //    For each book select its name, date (in format "d") and pages. 
            //    Sort them by pages in descending order and then by date in descending order.

            var books = context
                .Books
                .Where(b => b.PublishedOn < date && b.Genre == Genre.Science)
                .Select(b => new ExportBookDTO
                {
                   Pages = b.Pages,
                   Name = b.Name,
                    Date = b.PublishedOn.ToString("d", CultureInfo.InvariantCulture)
                })
                .ToList()
                .OrderByDescending(b=>b.Pages)
                .ThenByDescending(b=>b.Date)
                .Take(10)
                .ToList();

            var serializer = new XmlSerializer(typeof(List<ExportBookDTO>), new XmlRootAttribute("Books"));
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            var result = new StringBuilder();

            using var writer = new StringWriter(result);

            serializer.Serialize(writer, books, namespaces);

            return result.ToString().TrimEnd();
        }
    }
}