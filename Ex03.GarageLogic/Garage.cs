using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private Dictionary<string, VehicleInGarage> m_VehiclesInGarage = new Dictionary<string, VehicleInGarage>();

        public void AddNewVehicle(VehicleInGarage i_Vehicle)
        {
            m_VehiclesInGarage.Add(i_Vehicle.Vehicle.LicenseNumber, i_Vehicle);
        }

        public int GetNumberOfVehicleInGarge()
        {
            return m_VehiclesInGarage.Count;
        }

        public List<string> GetAllLicenseNumbers(int i_VehicleStatus)
        {
            List<string> licenseNumbers = new List<string>();

            if (i_VehicleStatus != 4)
            {
                foreach (VehicleInGarage vehicle in m_VehiclesInGarage.Values)
                {
                    if (((eVehicleStatus)i_VehicleStatus) == vehicle.VehicleStatus)
                    {
                        licenseNumbers.Add(vehicle.Vehicle.LicenseNumber);
                    }
                }
            }
            else
            {
                foreach (VehicleInGarage vehicle in m_VehiclesInGarage.Values)
                {
                    licenseNumbers.Add(vehicle.Vehicle.LicenseNumber);
                }
            }
            return licenseNumbers;
        }

        public void UpdateVehicleStatus(string i_LicenseNumber, eVehicleStatus i_NewStatus)
        {
            if (!IsVehicleExists(i_LicenseNumber))
            {
                throw new ArgumentNullException("Vehicle doesn't exist");
            }
            else
            {
                VehicleInGarage garageVehicle = this.GetVehicle(i_LicenseNumber);
                garageVehicle.VehicleStatus = i_NewStatus;
            }
        }

        public void FillAirPresure(string i_LicenseNumber)
        {
            if (!IsVehicleExists(i_LicenseNumber))
            {
                throw new ArgumentNullException("Vehicle doesn't exist");
            }
            else
            {
                VehicleInGarage garageVehicle = GetVehicle(i_LicenseNumber);
                float airPresureToFill = 0;
                float currentAirPresure = 0;
                float maxAirPresure = garageVehicle.Vehicle.WheelsCollection.ElementAt(0).MaxPresure;
                for (int i = 0; i < garageVehicle.Vehicle.WheelsCollection.Count; i++)
                {
                    currentAirPresure = getCurrentWheelAirPresure(garageVehicle.Vehicle.WheelsCollection.ElementAt(i));
                    airPresureToFill = maxAirPresure - currentAirPresure;
                    garageVehicle.Vehicle.WheelsCollection.ElementAt(i).FillAirPresure(airPresureToFill);
                }
            }
        }

        public VehicleInGarage GetVehicle(string i_LicenseNumber)
        {
            VehicleInGarage garageVehicle = null;
            m_VehiclesInGarage.TryGetValue(i_LicenseNumber, out garageVehicle);
            return garageVehicle;
        }

        private float getCurrentWheelAirPresure(Wheel i_Wheel)
        {
            return i_Wheel.CurrentAirPresure;
        }

        public void FillFuelInVehicle(string i_LicenseNumber, eFuelType i_FuelType, float i_AmountFuelToFill)
        {
            if (!IsVehicleExists(i_LicenseNumber))
            {
                throw new ArgumentNullException("Vehicle doesn't exist");
            }
            else
            {
                VehicleInGarage garageVehicle = GetVehicle(i_LicenseNumber);
                if (garageVehicle.Vehicle.Engine is FuelEngine)
                {
                    ((FuelEngine)garageVehicle.Vehicle.Engine).Fuel(i_AmountFuelToFill, i_FuelType);
                }
                else
                {
                    throw new ArgumentNullException("Incorrect engine type");
                }
            }
        }

        public void ChargeElectricEngine(string i_LicenseNumber, float i_MinutesToCharge)
        {
            if (!IsVehicleExists(i_LicenseNumber))
            {
                throw new ArgumentNullException("Vehicle doesn't exist in the garage");
            }
            else
            {
                VehicleInGarage garageVehicle = GetVehicle(i_LicenseNumber);
                if (garageVehicle.Vehicle.Engine is ElectricEngine)
                {
                    ((ElectricEngine)garageVehicle.Vehicle.Engine).ChargeElectricEngine(i_MinutesToCharge / 60f);
                }
                else
                {
                    throw new ArgumentNullException("Incorrect engine type");
                }
            }
        }

        public bool IsVehicleExists(string i_LicenseNumber)
        {
            return m_VehiclesInGarage.ContainsKey(i_LicenseNumber);
        }

    }
}

