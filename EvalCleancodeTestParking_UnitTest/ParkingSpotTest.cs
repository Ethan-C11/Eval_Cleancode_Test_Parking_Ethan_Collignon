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
        public void BookParkingSpot_SpotIsEmpty_ReturnsTrueAndCarIsParkedAndParkTimeIsCorrect()
        {
            _parkingSpot.CarParked = null;
            Car _car = new Car();
            DateTime ParkTime = DateTime.Now;
            Assert.IsTrue(_parkingSpot.BookParkingSpot(_car, ParkTime));
            Assert.AreEqual(_parkingSpot.CarParked, _car);
            Assert.AreEqual(_parkingSpot.ParkTime, ParkTime);
        }

        [TestMethod]
        public void BookParkingSpot_SpotIsNotEmpty_ReturnsFalse()
        {
            _parkingSpot.CarParked = new Car();
            DateTime ParkTime = DateTime.Now;

            Assert.IsFalse(_parkingSpot.BookParkingSpot(new Car(), ParkTime));
        }

        [TestMethod]
        public void LeaveParkingSpot_SpotIsNotEmpty_ReturnsParkingFeeAndCarIsGone()
        {
            Car _car = new Car();
            _parkingSpot.CarParked = _car;
            _parkingSpot.ParkTime =  DateTime.Now.AddHours(-1);

            Assert.AreEqual(_parkingSpot.LeaveParkingSpot(), 1);
            Assert.AreEqual(_parkingSpot.CarParked, null);
        }

        [TestMethod]
        public void LeaveParkingSpot_SpotIsEmpty_ReturnsNull()
        {
            _parkingSpot.CarParked = null;

            Assert.AreEqual(_parkingSpot.LeaveParkingSpot(), null);
        }
    }
}
