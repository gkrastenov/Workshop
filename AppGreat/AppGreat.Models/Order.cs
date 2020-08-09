namespace AppGreat.Data.Models
{
    using System;
    using System.Collections.Generic;
    public class Order
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public ICollection<Product> Products { get; set; } = new HashSet<Product>();

        public OrderStatus Status { get; set; }

        public DateTime PurchaseTime { get; set; }
    }
}
