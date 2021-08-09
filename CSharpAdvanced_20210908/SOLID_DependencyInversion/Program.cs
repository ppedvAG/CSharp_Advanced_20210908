using System;

namespace SOLID_DependencyInversion
{
    class Program
    {
        static void Main(string[] args)
        {
            ICar myTestCar = new MockCar();
            ICar myTestCar1 = new Car();

            ICarService service = new CarService();
            service.Repair(myTestCar1);
        }
    }

    #region BadCode
    public class BadCar // Programmierer A -> 5 tage 
    {
        int Id { get; set; }
        string Brandt { get; set; }

        string Model { get; set; }

        DateTime ConstructionYear { get; set; }
    }

    public class BadElektroCar : BadCar
    {

    }

    public class BadCarService //Programmierer B -> 3 Tage
    {
        public void Repair (BadCar car)
        {
            //repariere Auto...
        }
    }
    #endregion


    #region Good Sample


        
    public interface ICar
    {
        int Id { get; set; }
        string Brandt { get; set; }

        string Model { get; set; }

        DateTime ConstructionYear { get; set; }
    }

    public interface ICarService
    {
        void Repair(ICar car);
    }



    public class Car : ICar //Programmieer A -> 5
    {
        public int Id { get; set; }
        public string Brandt { get; set; }
        public string Model { get; set; }
        public DateTime ConstructionYear { get; set; }
    }

    public class CarService : ICarService // Programmierer B -> 3 Tage
    {
        public void Repair(ICar car)
        {
           //Mach etwas
        }
    }

    public class MockCar : ICar
    {
        public int Id { get; set; } = 1;
        public string Brandt { get; set; } = "VW";
        public string Model { get; set; } = "Polo";
        public DateTime ConstructionYear { get; set; } = DateTime.Now;
    }

    #endregion
}
