using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private bool m_IsCarryingDangerousMatrials;
        private readonly float r_BaggageCapacity;

        public Truck(string i_Model, string i_LicenseNumber, float i_BaggageCapacity) : base(i_Model, i_LicenseNumber)
        {
            this.r_BaggageCapacity = i_BaggageCapacity;
        }

        public bool IsCarryingDangerousMatrials
        {
            get
            {
                return m_IsCarryingDangerousMatrials;
            }
            set
            {
                m_IsCarryingDangerousMatrials = value;
            }
        }

        public float MaxBaggageCapacity
        {
            get
            {
                return r_BaggageCapacity;
            }
        }

        public override string ToString()
        {
            string fuelCarDescription = string.Format(@"{0}
Is carrying dangerous materials: {1}
Max baggage capacity: {2}", base.ToString(), m_IsCarryingDangerousMatrials, MaxBaggageCapacity);

            return fuelCarDescription;
        }
    }

    public enum eTruckBaggageType
    {
        dangerous = 1,
        regular = 2
    }
}
