namespace BookShop.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using BookShop.Data.Models;
    using BookShop.Data.Models.Enums;
    using BookShop.DataProcessor.ImportDto;
    using Data;
    using Newtonsoft.Json;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedBook
            = "Successfully imported book {0} for {1:F2}.";

        private const string SuccessfullyImportedAuthor
            = "Successfully imported author - {0} with {1} books.";

        public static string ImportBooks(BookShopContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(ImportBookDTO[]), new XmlRootAttribute("Books"));
            var books = new List<Book>();
            var result = new StringBuilder();

            var booksDTO = serializer.Deserialize(new StringReader(xmlString)) as ImportBookDTO[];

            foreach (var bookDTO in booksDTO)
            {
                if (!IsValid(bookDTO))
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime publishedOn;

                bool isDateValid = DateTime.TryParseExact(bookDTO.PublishedOn, "MM/dd/yyyy", 
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out publishedOn);

                if (!isDateValid)
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                var validBook = new Book
                {
                    Name = bookDTO.Name,
                    Genre = (Genre)bookDTO.Genre,
                    Price = bookDTO.Price,
                    Pages = bookDTO.Pages,
                    PublishedOn = publishedOn
                };

                books.Add(validBook);
                result.AppendLine(String.Format(SuccessfullyImportedBook, validBook.Name, validBook.Price));
            }

            context.Books.AddRange(books);
            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

        public static string ImportAuthors(BookShopContext context, string jsonString)
        {
            var result = new StringBuilder();
            var authors = new List<Author>();

            var authorDTOs = JsonConvert.DeserializeObject<List<ImportAuthorDTO>>(jsonString);

            foreach (var authorDto in authorDTOs)
            {
                if (!IsValid(authorDto))
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                if (authors.Any(a=>a.Email == authorDto.Email))
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                var author = new Author
                {
                    FirstName = authorDto.FirstName,
                    LastName = authorDto.LastName,
                    Email = authorDto.Email,
                    Phone = authorDto.Phone
                };

                foreach (var bookDto in authorDto.Books)
                {
                    if (!bookDto.BookId.HasValue)
                    {
                        continue;
                    }

                    var book = context
                        .Books
                        .FirstOrDefault(b => b.Id == bookDto.BookId);

                    if (book == null)
                    {
                        continue;
                    }

                    author.AuthorsBooks.Add(new AuthorBook
                    {
                        Author = author,
                        Book = book
                    });
                }

                if (author.AuthorsBooks.Count == 0)
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                authors.Add(author);
                result.AppendLine(String.Format(SuccessfullyImportedAuthor, author.FirstName + " " + author.LastName, 
                    author.AuthorsBooks.Count));
            }

            context.Authors.AddRange(authors);
            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}