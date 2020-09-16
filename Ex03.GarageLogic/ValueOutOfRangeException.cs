using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        private float m_MinValue;
        private float m_MaxValue;

        public float MinValue
        {
            get
            {
                return m_MinValue;
            }
        }

        public float MaxValue
        {
            get
            {
                return m_MaxValue;
            }
        }

        public ValueOutOfRangeException(float i_MinValue, float i_MaxValue) : base(string.Format(
            "Value out of range error: the range is between {0} to {1}", i_MinValue, i_MaxValue))
        {
            m_MinValue = i_MinValue;
            m_MaxValue = i_MaxValue;
        }

        public ValueOutOfRangeException(Exception i_InnerException, float i_MinValue, float i_MaxValue) : base(string.Format(
            "Value out of range error : the range is between {0} to {1}", i_MinValue, i_MaxValue, i_InnerException))
        {
            m_MinValue = i_MinValue;
            m_MaxValue = i_MaxValue;
        }
    }
}
