namespace CarDealer
{
    using CarDealer.Data;
    using CarDealer.DataTransferObjects.ExportDTOs;
    using CarDealer.DataTransferObjects.ImportDTOs;
    using CarDealer.Models;
    using CarDealer.XMLHelper;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new CarDealerContext();
            File.WriteAllText("../../../Datasets/ExportXMLs/sales-discounts.xml", GetSalesWithAppliedDiscount(context));
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            //Get all sales with information about the car, customer and price of the sale with and without discount.

            var sales = context
                .Sales
                .Select(s => new ExportSalesDTO
                {
                    Car = new ExportCarDTO
                    {
                       Make = s.Car.Make,
                       Model = s.Car.Model,
                       TravelledDistance = s.Car.TravelledDistance
                    },
                   Discount = s.Discount,
                   CusomerName = s.Customer.Name,
                   Price = s.Car.PartCars.Sum(pc=>pc.Part.Price),
                    PriceWithDiscount = s.Car.PartCars.Sum(pc => pc.Part.Price) - s.Car.PartCars.Sum(pc => pc.Part.Price) * s.Discount / 100M
                })
                .ToList();

            var root = "sales";
            var result = XMLConverter.Serialize(sales, root);

            return result;
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {           
            var customers = context
                .Sales
                .Where(s => s.Customer.Sales.Any())
                .Select(s => new ExportCustomerSalesDTO
                {
                   Name = s.Customer.Name,
                   BoughtCars = s.Customer.Sales.Count,
                    SpentMoney = s.Car.PartCars.Sum(x => x.Part.Price)
                })
                .OrderByDescending(c => c.SpentMoney)
                .ToList();

            var root = "customers";

            var result = XMLConverter.Serialize(customers, root);

            return result;
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context
                        .Cars
                        .Select(c => new ExportCarsWithPartsDTO
                        {
                            Make = c.Make,
                            Model = c.Model,
                            TravelledDistance = c.TravelledDistance,
                            Parts = c.PartCars.Select(pc => new ExportPartsDTO
                            {
                                Name = pc.Part.Name,
                                Price = pc.Part.Price
                            })
                                .OrderByDescending(x => x.Price)
                                .ToList()
                        })
                        .OrderByDescending(c => c.TravelledDistance)
                        .ThenBy(c => c.Model)
                        .Take(5)
                        .ToList();

            var root = "cars";
            var result = XMLConverter.Serialize(cars, root);

            return result;
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context
                    .Suppliers
                    .Where(s => s.IsImporter == false)
                    .Select(s => new ExportLocalSuppliersDTO
                    {
                        Id = s.Id,
                        Name = s.Name,
                        PartsCount = s.Parts.Count
                    })
                    .ToList();

            var root = "suppliers";
            var result = XMLConverter.Serialize(suppliers, root);

            return result;
        }

        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var cars = context
                .Cars
                .Where(c => c.Make == "BMW")
                .Select(c => new ExportCarBMWDTO
                {
                    Id = c.Id,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .ToList();

            var root = "cars";
            var result = XMLConverter.Serialize(cars, root);

            return result;
        }

        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var carsWithDistance = context
                .Cars
                .Where(c => c.TravelledDistance > 2000000)
                .Select(c => new ExportCarWithDistanceDTO
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .ToList();

            var root = "cars";

            var result = XMLConverter.Serialize(carsWithDistance, root);

            return result;
        }

        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            var root = "Sales";
            var salesData = XMLConverter.Deserializer<ImportSalesDTO>(inputXml, root);

            var sales = salesData
                .Where(s => context.Cars.Any(c => c.Id == s.CarId))
                .Select(s => new Sale
                {
                    CarId = s.CarId,
                    CustomerId = s.CustomerId,
                    Discount = s.Discount
                })
                .ToList();

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}";
        }

        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            var root = "Customers";
            var customersData = XMLConverter.Deserializer<ImportCustomerDTO>(inputXml, root);

            var customers = customersData
                .Select(c => new Customer
                {
                    Name = c.Name,
                    BirthDate = c.BirthDate,
                    IsYoungDriver = c.IsYoungDriver
                })
                .ToList();

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}";
        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            var root = "Cars";
            var cars = new List<Car>();
            var carData = XMLConverter.Deserializer<ImportCarsDTO>(inputXml, root);

            foreach (var carInfo in carData)
            {
                var distinctParts = carInfo.CarParts
                    .Select(p => p.Id)
                    .Distinct()
                    .ToList();

                var actualParts = distinctParts
                    .Where(id => context.Parts.Any(p => p.Id == id))
                    .ToList();

                var car = new Car
                {
                    Make = carInfo.Make,
                    Model = carInfo.Model,
                    TravelledDistance = carInfo.TravelledDistance,
                    PartCars = actualParts.Select(id => new PartCar
                    {
                        PartId = id
                    })
                    .ToList()
                };

                cars.Add(car);
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}";
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            var root = "Parts";

            var partsData = XMLConverter.Deserializer<ImportPartsDTO>(inputXml, root);

            var parts = partsData
                .Where(p => context.Suppliers.Count() >= p.SupplierId && p.SupplierId > 0)
                .Select(p => new Part
                {
                    Name = p.Name,
                    Price = p.Price,
                    Quantity = p.Quantity,
                    SupplierId = p.SupplierId
                })
                .ToList();

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}";
        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            var root = "Suppliers";
            var suppliersData = XMLConverter.Deserializer<ImportSuppliersDTO>(inputXml, root);

            var suppliers = suppliersData
                .Select(s => new Supplier
                {
                    Name = s.Name,
                    IsImporter = s.IsImporter
                })
                .ToList();

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}";
        }
    }
}