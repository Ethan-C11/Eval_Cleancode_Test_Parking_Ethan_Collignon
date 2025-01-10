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
        [DataRow(10)]
        [DataRow(1)]
        [DataRow(1000)]
        public void CreateParking_ValidNumberOfSpot_ReturnNumberOfSpot(int numberOfSpot) => Assert.AreEqual(numberOfSpot, _parking.CreateParking(numberOfSpot));

        [TestMethod]
        [DataRow(-1)]
        [DataRow(0)]
        [DataRow(-1000)]
        public void CreateParking_InvalidNumberOfSpot_Return0(int numberOfSpot) => Assert.AreEqual(_parking.CreateParking(numberOfSpot), 0);

        [TestMethod]
        public void BookFirstAvalaibleSpot_ASpotIsAvalaible_ReturnTrue()
        {
            Car _car = new Car();
            _parking.CreateParking(1);

            Assert.IsTrue(_parking.BookFirstAvalaibleSpot(_car));
        }

        [TestMethod]
        public void BookFirstAvalaibleSpot_NoSpotIsAvalaible_ReturnTrue()
        {
            Car _car = new Car();
            _parking.CreateParking(1);

            ParkingSpot _spot = new ParkingSpot();
            _spot.CarParked = new Car();
            _parking.parkingSpots[0] = _spot;

            Assert.IsFalse(_parking.BookFirstAvalaibleSpot(_car));
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

        [TestMethod]
        [DataRow(0)]
        [DataRow(9)]
        [DataRow(5)]
        public void LeaveParking_SpotIsEmpty_ReturnNull(int spotIndex)
        {
            _parking.CreateParking(10);

            _parking.parkingSpots[spotIndex].CarParked = null;

            Assert.AreEqual(_parking.LeaveParkingSpot(spotIndex), null);
        }
    }
}
