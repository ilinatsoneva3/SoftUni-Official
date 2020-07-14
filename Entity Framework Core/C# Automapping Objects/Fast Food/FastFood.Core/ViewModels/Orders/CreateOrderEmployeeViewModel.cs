namespace FastFood.Core.ViewModels.Orders
{
    using System.ComponentModel.DataAnnotations;

    public class CreateOrderEmployeeViewModel
    {
        public int EmployeeId { get; set; }

        public string EmployeeName { get; set; }
    }
}
