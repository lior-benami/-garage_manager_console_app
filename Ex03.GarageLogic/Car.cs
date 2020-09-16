using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        private readonly eColor r_Color;
        private readonly eNumberOfDoors r_NumberOfDoors;

        public Car(string i_Model, string i_LicenseNumber, eColor i_Color, eNumberOfDoors i_NumberOfDoors) : base(i_Model, i_LicenseNumber)
        {
            r_Color = i_Color;
            r_NumberOfDoors = i_NumberOfDoors;
        }

        public eColor CarColor
        {
            get
            {
                return r_Color;
            }
        }

        public eNumberOfDoors NumberOfDoors
        {
            get
            {
                return r_NumberOfDoors;
            }
        }

        public override string ToString()
        {
            string fuelCarDescription = string.Format(@"{0}
Car color: {1}
Number of doors: {2}", base.ToString(), r_Color, r_NumberOfDoors);

            return fuelCarDescription;
        }
    }

    public enum eColor
    {
        Red = 1,
        Blue = 2,
        Black = 3,
        Gray = 4
    }

    public enum eNumberOfDoors
    {
        Two = 1,
        Three = 2,
        Four = 3,
        Five = 4
    }
}