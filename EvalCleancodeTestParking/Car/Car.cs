using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EvalCleadcodeTestParking
{
    public class Car
    {
        private string LicencePlate { get; set; }

        public bool CreateCar(string LicencePlate) //Exemple plaque AB-123-CD
        {
            if (LicencePlate.Length != 9) // Plaque trop grande, non valide
                return false;

            string _LicencePlate = LicencePlate.ToLower();

            // découpe la plaque selon les normes françaises
            string firstPart = LicencePlate.Substring(0, 2);
            string middlePart = LicencePlate.Substring(3,3);
            string lastPart = LicencePlate.Substring(7,2);

            if ( !Regex.IsMatch(firstPart, @"^[a-zA-Z]+$") || 
                !Regex.IsMatch(middlePart, @"^[0-9]+$") || 
                !Regex.IsMatch(lastPart, @"^[a-zA-Z]+$"))
                return false;
            else
                return true;
        }
    }
}
