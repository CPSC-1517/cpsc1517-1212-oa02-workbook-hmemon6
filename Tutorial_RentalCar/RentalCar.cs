using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial_RentalCar
{
    internal class RentalCar
    {
        public string VIN { get; private set; }
        public string ClientName { get; private set; }
        public DateTime DateTaken { get; private set; }
        public int DaysRental { get; set; }

        public DateTime DateDue 
        { 
            get 
            { 
                return DateTaken.AddDays(DaysRental); 
            }
        }

        public RentalCar(string clientName, DateTime dateTaken, int days)
        {
            ClientName = clientName;
            DateTaken = dateTaken;
            DaysRental = days;
            VIN = GetPretendVIN();

        }

        private static string _PretendVIN = "1ABC234DE567";
        private static int _Counter = 10;
        public static string GetPretendVIN()
        {
            //Dont know what _Counter.ToString() here does??? Try debugging?
            string tempVIN = _PretendVIN + _Counter.ToString();
            _Counter = _Counter + 1;
            return tempVIN;
        }

        public override string ToString()
        {
            return VIN;
        }
    }
}
