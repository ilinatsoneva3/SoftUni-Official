namespace P03_SalesDatabase.Data.Models
{
    using P03_SalesDatabase.Common;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Store
    {
        public int StoreId { get; set; }

        [Required, MaxLength(GlobalConstants.StoreNameMaxLength)]
        public string Name { get; set; }

        [Required]
        public virtual ICollection<Sale> Sales { get; set; }
    }
}
