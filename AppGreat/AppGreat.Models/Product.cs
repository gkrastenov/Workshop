namespace AppGreat.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static AppGreat.Models.DataValidation;
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string ImageUrl { get; set; }

        public int OrderId { get; set; }

        public Order Order { get; set; }


    }
}
