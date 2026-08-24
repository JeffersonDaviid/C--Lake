using System.ComponentModel.DataAnnotations;

namespace APIv1.DTO
{
    public class CarDTO
    {
        public int Id { get; set; }
        [Required]
        public string Brand { get; set; } = string.Empty;
        [Required]
        public string Model { get; set; } = string.Empty;
        [Required]
        public decimal Price { get; set; } //price for day
        [Required]
        public int Year { get; set; }
    }
}