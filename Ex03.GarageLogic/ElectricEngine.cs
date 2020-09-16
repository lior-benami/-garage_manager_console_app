using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ElectricEngine : Engine
    {
        public ElectricEngine(float i_MaxCapacity) : base(i_MaxCapacity) { }

        public void ChargeElectricEngine(float i_NumberOfHoursToAdd)
        {
            base.FillEnergy(i_NumberOfHoursToAdd);
        }
    }
}
