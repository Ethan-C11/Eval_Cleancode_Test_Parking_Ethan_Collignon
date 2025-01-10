using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvalCleadcodeTestParking;

namespace EvalCleancodeTestParking_UnitTest
{
    [TestClass]
    public class CarTest
    {
        Car _car;

        [TestInitialize] 
        public void Init() { 
            _car = new Car();
        }

        [TestMethod]
        [DataRow("AB-123-CD")]
        [DataRow("OT-835-KL")]
        [DataRow("yt-500-pv")]
        public void CreateCar_ValidLicencePlate_ReturnTrue(string LicencePlate) => Assert.IsTrue(_car.CreateCar(LicencePlate));

        [TestMethod]
        [DataRow("AB123-CD")]
        [DataRow("O1-835-KL")]
        [DataRow("yt-500-1v")]
        [DataRow("yt-A00-cv")]
        [DataRow("yt-000-cvd")]
        public void CreateCar_InvalidLicencePlate_ReturnFalse(string LicencePlate) => Assert.IsFalse(_car.CreateCar(LicencePlate));


    }
}
