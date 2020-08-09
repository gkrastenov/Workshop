namespace AppGreat.Models
{
    using AppGreat.Data.Models;
    using System.ComponentModel.DataAnnotations;
    public class OrderChangeStatusRequest
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public OrderStatus Status { get; set; }
    }
}
