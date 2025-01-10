using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvalCleadcodeTestParking;

namespace Parking_UnitTest
{
    [TestClass]
    public class ParkingTest
    {
        private Parking _parking;

        [TestInitialize]
        public void Init()
        {
            _parking = new Parking();
        }

        [TestMethod]
        public void BookFirstAvalaibleSpot_ASpotIsAvalaible_ReturnTrue()
        {
            Car _car = new Car();
            _parking.CreateParking(1);

            Assert.IsTrue(_parking.BookFirstAvalaibleSpot(_car));
        }

        [TestMethod]
        [DataRow(0)]
        [DataRow(9)]
        [DataRow(5)]
        public void LeaveParking_SpotIsNotEmpty_ReturnPriceAndCarIsGone(int spotIndex)
        {
            _parking.CreateParking(10);

            _parking.parkingSpots[spotIndex].CarParked = new Car();
            _parking.parkingSpots[spotIndex].ParkTime = DateTime.Now.AddHours(-1);

            Assert.AreEqual(_parking.LeaveParkingSpot(spotIndex), 1);
            Assert.AreEqual(_parking.parkingSpots[0].CarParked, null);
        }
    }
}
