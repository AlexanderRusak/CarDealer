namespace CarDealer.BusinessLogic.Dtos
{
    public class CarDealerDto
    {
        public int Id { get; set; }
        public string Brand { get; set; }

        public string Model { get; set; }

        public string Color { get; set; }

        public decimal Price { get; set; }
 
        public string DealerName { get; set; }

        public string DealerPhone { get; set; }
    }
}
