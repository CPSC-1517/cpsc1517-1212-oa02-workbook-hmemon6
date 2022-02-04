using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial_RentalCar
{
    internal class RentalCompany
    {
        public int CarCount { get; private set; }
        public RentalCompany(int carCount)
        {
            CarCount = carCount;
        }
        public RentalCar BookRental(string name, int days)
        {
            RentalCar car;
            car = new RentalCar(name, DateTime.Today, days);
            CarCount = CarCount - 1;
            return car;
        }

        public override string ToString()
        {
            return CarCount.ToString() + " Cars availaible to rent.";
        }
    }
}
