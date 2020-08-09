namespace AppGreat.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static AppGreat.Models.DataValidation;
    public class User
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Username { get; set; }

        [Required]
        [MaxLength(PasswordMaxLength)]
        public string Password { get; set; }

        public string CurrencyCode { get; set; }

        public ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    }
}
