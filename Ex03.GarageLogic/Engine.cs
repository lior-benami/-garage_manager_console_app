using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Engine
    {
        protected float m_CurrentEnergyAmount;
        protected readonly float r_MaxCapacity;
        protected float m_CurrentEnergyAmountPercent;

        public Engine(float i_MaxCapacity)
        {
            r_MaxCapacity = i_MaxCapacity;
        }

        public float CurrentEnergyAmount
        {
            get
            {
                return m_CurrentEnergyAmount;
            }
            set
            {
                m_CurrentEnergyAmount = value;
            }
        }

        public float MaxCapacity
        {
            get
            {
                return r_MaxCapacity;
            }
        }

        protected void FillEnergy(float i_AmountOfEnergyToFill)
        {
            if (i_AmountOfEnergyToFill + this.m_CurrentEnergyAmount <= this.r_MaxCapacity)
            {
                this.m_CurrentEnergyAmount += i_AmountOfEnergyToFill;
                calculatemEnergyAmount();
            }
            else
            {
                throw new ValueOutOfRangeException(0f, (r_MaxCapacity - m_CurrentEnergyAmount));
            }
        }

        public void calculatemEnergyAmount()
        {
            this.m_CurrentEnergyAmountPercent = (this.m_CurrentEnergyAmount / this.MaxCapacity) * 100;
        }

        public override string ToString()
        {
            string engineDescription =
            string.Format(@"Energy left: {0}
Max capacity: {1}
Current energy amount percent {2}%", m_CurrentEnergyAmount, MaxCapacity, m_CurrentEnergyAmountPercent);

            return engineDescription;
        }
    }

    public enum eEngineType
    {
        Electric = 1,
        Fuel = 2
    }
}

