using EvalCleadcodeTestParking;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvalCleancodeTestParking_PerformanceTest
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
        public void BookFirstAvalaibleSpot_ASpotIsAvalaibleAndTimeIsBelowOneSecond_ReturnTrue()
        {
            Stopwatch stopwatch = new Stopwatch(); 
            Car _car = new Car();
            _parking.CreateParking(1);

            stopwatch.Start();
            {
            _parking.BookFirstAvalaibleSpot(_car);
            }
            stopwatch.Stop();

            Assert.IsTrue(stopwatch.ElapsedMilliseconds < 1000);
        }

        [TestMethod]
        [DataRow(0)]
        [DataRow(9)]
        [DataRow(5)]
        public void LeaveParking_SpotIsNotEmptyAndTimeIsBelowOneSecond_ReturnTrue(int spotIndex)
        {
            Stopwatch stopwatch = new Stopwatch();

            _parking.CreateParking(10);

            _parking.parkingSpots[spotIndex].CarParked = new Car();
            _parking.parkingSpots[spotIndex].ParkTime = DateTime.Now.AddHours(-1);

            stopwatch.Start();
            {
            _parking.LeaveParkingSpot(spotIndex);
            }
            stopwatch.Stop();

            Assert.IsTrue(stopwatch.ElapsedMilliseconds < 1000);
        }
    }
}
