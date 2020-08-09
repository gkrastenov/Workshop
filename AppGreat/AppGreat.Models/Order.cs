namespace AppGreat.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text.Json.Serialization;

    public class Order
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        [JsonIgnore]
        public User User { get; set; }

        public ICollection<Product> Products { get; set; } = new HashSet<Product>();

        [Required]
        public OrderStatus Status { get; set; }

        public DateTime PurchaseTime { get; set; }
    }
}
