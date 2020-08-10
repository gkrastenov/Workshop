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

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string Image { get; set; }

        public int OrderId { get; set; }

        public Order Order { get; set; }

    }
}
