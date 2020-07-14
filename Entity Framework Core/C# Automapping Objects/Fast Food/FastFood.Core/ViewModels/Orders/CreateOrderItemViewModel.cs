namespace FastFood.Core.ViewModels.Orders
{
    using System.ComponentModel.DataAnnotations;

    public class CreateOrderItemViewModel
    {
        public int ItemId { get; set; }

        public string ItemName { get; set; }
    }
}
