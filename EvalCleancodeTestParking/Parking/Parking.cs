using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvalCleadcodeTestParking
{
    public class Parking
    {
        public ParkingSpot[]? parkingSpots;

        public int CreateParking(int parkingSpotCount, int ParkingHourlyPrice = 1)
        {
            if (parkingSpotCount < 1)
                return 0;
            else
            {
                parkingSpots = new ParkingSpot[parkingSpotCount];
                for (int i = 0; i < parkingSpotCount; i++)
                {
                    parkingSpots[i] = new ParkingSpot();
                    parkingSpots[i].HourlyPrice = ParkingHourlyPrice;
                }

            }

            return parkingSpots.Length;
        }

        public bool BookFirstAvalaibleSpot(Car _car, DateTime? ParkTime = null)
        {
            foreach(ParkingSpot spot in parkingSpots)
            {
                if(spot.CarParked == null)
                {
                    spot.BookParkingSpot(_car, ParkTime ?? DateTime.Now);
                    return true;
                }
            }
            return false;
        }

        public int? LeaveParkingSpot(int parkingSpotIndex)
        {
            if (parkingSpots[parkingSpotIndex].CarParked == null)
                return null;

            return parkingSpots[parkingSpotIndex].LeaveParkingSpot();
        }
    }
}
