namespace P03_SalesDatabase.Data.Models
{
    using P03_SalesDatabase.Common;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Product
    {
        public Product()
        {
            this.Sales = new HashSet<Sale>();
        }

        public int ProductId { get; set; }

        [Required, MaxLength(GlobalConstants.ProductNameMaxLength)]
        public string Name { get; set; }

        [Required]
        public double Quantity { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public virtual ICollection<Sale> Sales { get; set; }

        [MaxLength(250)]
        public string Description { get; set; }
    }
}
