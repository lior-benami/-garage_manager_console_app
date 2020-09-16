using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Motorcycle : Vehicle
    {
        private readonly eLicenseType r_LicenseType;
        private readonly int r_EngineCapacity;

        public Motorcycle(string i_Model, string i_LicenseNumber, eLicenseType i_LicenseType, int i_EngineCapacity) : base(i_Model, i_LicenseNumber)
        {
            r_LicenseType = i_LicenseType;
            r_EngineCapacity = i_EngineCapacity;
        }

        public eLicenseType LicenseType
        {
            get
            {
                return r_LicenseType;
            }
        }

        public int EngingeCapacity
        {
            get
            {
                return r_EngineCapacity;
            }
        }

        public override string ToString()
        {
            string electricMotorcycleDescription = string.Format(@"{0}
Max battery time: {1}
License type: {2}
Engine capacity: {3}", base.ToString(), m_Engine.MaxCapacity, r_LicenseType, r_EngineCapacity);

            return electricMotorcycleDescription;
        }
    }

    public enum eLicenseType
    {
        A = 1,
        A1 = 2,
        A2 = 3,
        B = 4
    }
}
