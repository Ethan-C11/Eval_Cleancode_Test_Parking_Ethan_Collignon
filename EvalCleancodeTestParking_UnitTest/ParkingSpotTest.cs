using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvalCleadcodeTestParking.ParkingSpot;

namespace EvalCleancodeTestParking_UnitTest
{
    [TestClass]
    public class ParkingSpotTest
    {
        ParkingSpotService _parkingSpotService;

        [TestInitialize]
        void Init()
        {
            _parkingSpotService = new ParkingSpotService();
        }
    }
}
