using EvalCleadcodeTestParking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvalCleadcodeTestParking
{
    public class ParkingSpot
    {
        public Car? CarParked { get; set; } = null;
        public DateTime? ParkTime { get; set; } = null;
        public int HourlyPrice { get; set; } = 1;

        public bool BookParkingSpot(Car car, DateTime parkTime)
        {
            if (CarParked != null)
                return false;
            else
            {
                CarParked = car;
                ParkTime = parkTime;
                return true;
            }
        }

        public int? LeaveParkingSpot()
        {
            if (CarParked == null)
                return null;

            CarParked = null;
            TimeSpan timeParked = DateTime.Now.Subtract(ParkTime ?? DateTime.Now);


            return (int?)(timeParked.TotalHours * HourlyPrice);
        }

    }
}
