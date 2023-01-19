using CarDealer.DataAccess.Model.Base;

namespace CarDealer.DataAccess.Model
{
    public class DealerCar : Entity
    {
        public decimal Price { get; set; }
        public Dealer Dealer { get; set; }
        public Car Car { get; set; }
    }
}
