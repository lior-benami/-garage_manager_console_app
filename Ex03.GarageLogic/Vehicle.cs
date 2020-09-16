using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        protected readonly string r_Model;
        protected readonly string r_LicenseNumber;
        protected List<Wheel> m_WheelsCollection;
        protected Engine m_Engine;

        public Vehicle(string i_Model, string i_LicenseNumber)
        {
            this.r_Model = i_Model;
            this.r_LicenseNumber = i_LicenseNumber;
        }

        public void CreateWheelsCollection(int i_WheelsNumber, string i_WheelsManufactureName, float i_CurrentAirPressure, float i_MaxWheelPresure)
        {
            m_WheelsCollection = new List<Wheel>();
            for (int i = 0; i < i_WheelsNumber; i++)
            {
                Wheel wheel = new Wheel(i_WheelsManufactureName, i_MaxWheelPresure);
                wheel.CurrentAirPresure = i_CurrentAirPressure;
                m_WheelsCollection.Add(wheel);
            }
        }

        public string Model
        {
            get
            {
                return r_Model;
            }
        }

        public string LicenseNumber
        {
            get
            {
                return r_LicenseNumber;
            }
        }

        public List<Wheel> WheelsCollection
        {
            get
            {
                return m_WheelsCollection;
            }
            set
            {
                m_WheelsCollection = value;
            }
        }

        public Engine Engine
        {
            get
            {
                return m_Engine;
            }
            set
            {
                m_Engine = value;
            }
        }

        private string printWheelsDescription()
        {
            StringBuilder allWheels = new StringBuilder();
            int NumberOfWheels = 1;
            foreach (Wheel wheel in m_WheelsCollection)
            {
                allWheels.Append(string.Format(@"Wheel number {0} details: 
{1}
", NumberOfWheels, wheel));
                allWheels.Append(Environment.NewLine);
                NumberOfWheels++;
            }

            return allWheels.ToString();
        }

        public override string ToString()
        {
            string vehicleDescription = string.Format(@"Model: {0}
License number: {1}
Energy left: {2} 
Number of wheels: {3}
Engine: 
{4}
Wheels: 
{5}", r_Model, r_LicenseNumber, m_Engine.CurrentEnergyAmount, m_WheelsCollection.Count, m_Engine, printWheelsDescription());

            return vehicleDescription;
        }
    }

    public enum eVehicleType
    {
        Car = 1,
        Motorcycle = 2,
        Truck = 3
    }
}
