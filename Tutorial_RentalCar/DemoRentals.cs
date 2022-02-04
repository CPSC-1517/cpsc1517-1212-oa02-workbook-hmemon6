using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial_RentalCar
{
    internal class DemoRentals
    {
        public static void Start()
        {
            string name;
            int daysToRent;

            name = PromptName();
            daysToRent = PromptRentalTime();

            RentalCar rentalCar;
            RentalCompany budget = new RentalCompany(5);

            rentalCar = budget.BookRental(name, daysToRent);

            DisplayRentalInfo(rentalCar);

        }

        private static string PromptName()
        {
            Console.Write("Enter name of person renting vehicle: ");
            string name = Console.ReadLine();
            return name;
        }
        private static int PromptRentalTime()
        {
            Console.Write("Enter number of days to rent: ");
            string daysAsText = Console.ReadLine();
            int days = Convert.ToInt32(daysAsText);
            return days;
        }

        private static void DisplayRentalInfo(RentalCar rentalCar)
        {
            Console.WriteLine("Rental Info");
            Console.WriteLine("-----------");
            Console.WriteLine(rentalCar);
            Console.WriteLine("Customer: " + rentalCar.ClientName);
            Console.WriteLine("Due Date: " + rentalCar.DateDue.ToShortDateString());
            Console.WriteLine();
        }
    }


}
