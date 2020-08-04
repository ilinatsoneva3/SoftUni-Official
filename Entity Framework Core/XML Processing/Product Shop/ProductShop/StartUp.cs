namespace ProductShop
{
    using ProductShop.Data;
    using ProductShop.Dtos.Export;
    using ProductShop.Dtos.Import;
    using ProductShop.Models;
    using System;
    using System.IO;
    using System.Linq;
    using XMLHelper;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new ProductShopContext();
            File.WriteAllText("../../../ExportedDatasets/users-and-products.xml", GetUsersWithProducts(context));
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context
                .Users
                .Where(u => u.ProductsSold.Any())
                .Select(u => new ExportUserDTO
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    SoldProducts = new ExportSoldProductsDTO
                    {
                        Count = u.ProductsSold.Count,
                        Products = u.ProductsSold
                                    .Select(p => new ExportProductDetailsDTO
                                    {
                                        Name = p.Name,
                                        Price = p.Price
                                    })
                                    .OrderByDescending(x => x.Price)
                                    .ToList()
                    }
                })
                .OrderByDescending(x => x.SoldProducts.Count)
                .Take(10)
                .ToList();

            var finalUser = new ExportUserCountDTO
            {
                Count = context.Users.Count(u=>u.ProductsSold.Any()),
                Users = users
            };

            var root = "Users";
            var result = XMLConverter.Serialize(finalUser, root);

            return result;
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context
                .Categories
                .Select(c => new ExportCategoriesDTO
                {
                    Name = c.Name,
                    Count = c.CategoryProducts.Count,
                    AveragePrice = c.CategoryProducts.Average(cp => cp.Product.Price),
                    TotalRevenue = c.CategoryProducts.Sum(cp => cp.Product.Price)
                })
                .OrderByDescending(x => x.Count)
                .ThenBy(x => x.TotalRevenue)
                .ToList();

            var root = "Categories";
            var result = XMLConverter.Serialize(categories, root);
            return result;
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var usersProducts = context
                .Users
                .Where(u => u.ProductsSold.Any())
                .Select(u => new ExportUsersProductsDTO
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    soldProducts = u.ProductsSold
                                    .Select(p => new ExportProductDTO
                                    {
                                        Name = p.Name,
                                        Price = p.Price
                                    })
                                    .ToList()
                })
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName)
                .Take(5)
                .ToList();

            var root = "Users";
            var result = XMLConverter.Serialize(usersProducts, root);

            return result;
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context
                .Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .Select(p => new ExportProductInfoDTO
                {
                    Name = p.Name,
                    Price = p.Price,
                    Buyer = p.Buyer.FirstName + " " + p.Buyer.LastName
                })
                .OrderBy(p => p.Price)
                .Take(10)
                .ToList();

            var root = "Products";

            var result = XMLConverter.Serialize(products, root);

            return result;
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            var categoryProductInfo = XMLConverter.Deserializer<ImportCategoryProductDTO>(inputXml, "CategoryProducts");

            var categoriesProducts = categoryProductInfo
                .Where(i => context.Categories.Any(c => c.Id == i.CategoryId) && context.Products.Any(p => p.Id == i.ProductId))
                .Select(cp => new CategoryProduct
                {
                    ProductId = cp.ProductId,
                    CategoryId = cp.CategoryId
                })
                .ToList();

            context.CategoryProducts.AddRange(categoriesProducts);
            context.SaveChanges();

            return $"Successfully imported {categoriesProducts.Count}";
        }

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            var categoriesInfo = XMLConverter.Deserializer<ImportCategoryDTO>(inputXml, "Categories");

            var categories = categoriesInfo
                .Where(c => c.Name != null)
                .Select(c => new Category
                {
                    Name = c.Name
                })
                .ToList();

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            var root = "Products";

            var productInfo = XMLConverter.Deserializer<ImportProductDTO>(inputXml, root);

            var products = productInfo
                .Select(p => new Product
                {
                    Name = p.Name,
                    Price = p.Price,
                    SellerId = p.SellerId,
                    BuyerId = p.BuyerId
                })
                .ToList();

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            var root = "Users";

            var usersInfo = XMLConverter.Deserializer<ImportUserDTO>(inputXml, root);

            var users = usersInfo
                .Select(u => new User
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age
                })
                .ToList();

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }
    }
}
