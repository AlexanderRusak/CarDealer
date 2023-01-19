using CarDealer.DataAccess.Model.Base;

namespace CarDealer.DataAccess.Model
{
    public class Car : Entity
    {
        public string Model { get; set; }
        public Brand Brand { get; set; }
        public Color Color { get; set; }
    }
}
