using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetAll();
            if (result.Succes == true) {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.CarName + " " + car.Description);

                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
    }
}
