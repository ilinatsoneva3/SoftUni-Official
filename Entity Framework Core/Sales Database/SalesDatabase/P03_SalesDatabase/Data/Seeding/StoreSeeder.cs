namespace P03_SalesDatabase.Data.Seeding
{
    using P03_SalesDatabase.Data.IOManagement.Contracts;
    using P03_SalesDatabase.Data.Models;
    using P03_SalesDatabase.Data.Seeding.Contracts;
    using System.Linq;

    public class StoreSeeder : ISeeder
    {
        private readonly SalesContext dbContext;
        private readonly IWriter writer;

        public StoreSeeder(SalesContext context, IWriter writer)
        {
            this.dbContext = context;
            this.writer = writer;
        }

        public void Seed()
        {
            Store[] stores = new Store[]
            {
               new Store() {Name = "Orange"},
               new Store() {Name = "Selena"},
               new Store() {Name = "Helikon"}
            };

            this.dbContext.AddRange(stores);
            this.dbContext.SaveChanges();


            foreach (var store in stores)
            {
                this.writer.WriteLine($"Store {store.Name} was added");
            }
        }
    }
}
