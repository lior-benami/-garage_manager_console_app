using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private readonly string r_ManufacturerName;
        private float m_CurrentAirPresure;
        private readonly float r_MaxAirPresure;

        public Wheel(string i_ManufactureName, float i_MaxAirPresure)
        {
            this.r_ManufacturerName = i_ManufactureName;
            this.r_MaxAirPresure = i_MaxAirPresure;
        }

        public string ManufactureName
        {
            get
            {
                return r_ManufacturerName;
            }
        }

        public float CurrentAirPresure
        {
            get
            {
                return m_CurrentAirPresure;
            }
            set
            {
                m_CurrentAirPresure = value;
            }
        }

        public float MaxPresure
        {
            get
            {
                return r_MaxAirPresure;
            }
        }

        public void FillAirPresure(float i_AirPresure)
        {
            if (i_AirPresure + this.m_CurrentAirPresure > r_MaxAirPresure)
            {
                throw new ValueOutOfRangeException(0f, (r_MaxAirPresure - m_CurrentAirPresure));
            }
            else
            {
                this.m_CurrentAirPresure += i_AirPresure;
            }
        }

        public override string ToString()
        {
            string wheelDescription = string.Format(@"Manufacture: {0}
Current air presure: {1}
Max air presure: {2}", r_ManufacturerName, m_CurrentAirPresure, r_MaxAirPresure);

            return wheelDescription;
        }
    }
}
