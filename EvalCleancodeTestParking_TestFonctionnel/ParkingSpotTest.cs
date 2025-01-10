using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvalCleadcodeTestParking;

namespace EvalCleancodeTestParking_UnitTest
{
    [TestClass]
    public class ParkingSpotTest
    {
        ParkingSpot _parkingSpot;

        [TestInitialize]
        public void Init()
        {
            _parkingSpot = new ParkingSpot();
        }

      
        [TestMethod]
        public void BookParkingSpot_SpotIsNotEmpty_ReturnsFalse()
        {
            _parkingSpot.CarParked = new Car();
            DateTime ParkTime = DateTime.Now;

            Assert.IsFalse(_parkingSpot.BookParkingSpot(new Car(), ParkTime));
        }

      
    }
}
