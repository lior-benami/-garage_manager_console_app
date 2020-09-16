using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class FuelEngine : Engine
    {
        private readonly eFuelType r_FuelType;

        public FuelEngine(float i_MaxCapacity, eFuelType i_FuelType) : base(i_MaxCapacity)
        {
            r_FuelType = i_FuelType;
        }

        public void Fuel(float i_LitersOfFuelToAdd, eFuelType i_FuelType)
        {
            if (this.r_FuelType == i_FuelType)
            {
                base.FillEnergy(i_LitersOfFuelToAdd);
            }
            else
            {
                throw new ArgumentException("Incorrect type of fuel");
            }
        }

        public eFuelType FuelType
        {
            get
            {
                return r_FuelType;
            }
        }

        public override string ToString()
        {
            string fuelEngineDescription = string.Format(@"{0}
Fuel type: {1}", base.ToString(), r_FuelType.ToString());

            return fuelEngineDescription;
        }
    }

    public enum eFuelType
    {
        Octan95 = 1,
        Octan96 = 2,
        Octan98 = 3,
        Soler = 4
    }
}
