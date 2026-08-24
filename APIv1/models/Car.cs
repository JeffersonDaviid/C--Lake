namespace APIv1.models
{
    public class Car
    {
        public int Id { get; set; }
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public decimal Price { get; set; } //price for day
        public int Year { get; set; }
        public ICollection<Rental> Rentals { get; set; }

    }
}