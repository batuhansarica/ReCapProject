using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //RentalManager rentalManager = new RentalManager(new EfRentalDal());
            //Rental rental = new Rental();
            //rental.Id = 1;
            //rental.CarId = 1;
            //rental.UserId = 1;
            //rental.RentDate = DateTime.Today;
            //rentalManager.Add(rental) ;
            //Rental rental2 = new Rental() { Id = 2, CarId = 2, UserId = 3, RentDate = new DateTime(2021, 12, 13), ReturnDate = new DateTime(2022, 01, 18) };
            //rentalManager.Add(rental2);

            UserTest();
            CarTest();
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();
            if (result.Succes == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.CarName + " " + car.BrandName + car.ColorName);

                }
            }

            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void UserTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            var resultt = userManager.GetAll();
            if (resultt.Succes == true)
            {
                foreach (var user in resultt.Data)
                {
                    Console.WriteLine(user.FirstName);
                }
            }
            else
            {
                Console.WriteLine(resultt.Message);
            }
        }
    }
}
