using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class CreateNewVehicle
    {
        public const float k_CapacityOfFuelEngineMotorcycle = 8f;
        public const float k_CapacityTimeOfElectricEngineMotorcycle = 1.4f;
        public const float k_CapacityOfFuelEngineCar = 55f;
        public const float k_CapacityTimeOfElectricEngineCar = 1.8f;
        public const float k_CapacityOfEngineTruck = 110f;
        public const float k_MotorcycleMaxAirPressure = 33f;
        public const float k_CarMaxAirPressure = 31f;
        public const float k_TruckMaxAirPressure = 26f;
        public const int k_MotorcycleWheelsNumber = 2;
        public const int k_CarWheelsNumber = 4;
        public const int k_TruckWheelsNumber = 12;


        public static VehicleInGarage CreateVehicleInGarage(Vehicle i_Vehicle, string i_OwnerName, string i_OwnerPhoneNumber)
        {
            i_Vehicle.Engine.calculatemEnergyAmount();
            VehicleInGarage garageVehicle = new VehicleInGarage(i_OwnerName, i_OwnerPhoneNumber, i_Vehicle);
            garageVehicle.VehicleStatus = eVehicleStatus.InRepair;
            return garageVehicle;
        }

        private static Motorcycle createMotorcycle(string i_Model, string i_LicenseNumber, eLicenseType i_LicenseType, int i_EngineCapacity, string i_WheelsManufacturerName, float i_CurrentAirPressure)
        {
            Motorcycle motorcycle = new Motorcycle(i_Model, i_LicenseNumber, i_LicenseType, i_EngineCapacity);
            motorcycle.CreateWheelsCollection(k_MotorcycleWheelsNumber, i_WheelsManufacturerName, i_CurrentAirPressure, k_MotorcycleMaxAirPressure);
            return motorcycle;
        }

        private static Car createCar(string i_Model, string i_LicenseNumber, eColor i_CarColor, eNumberOfDoors i_NumberOfDoors, string i_WheelsManufacturerName, float i_CurrentWheelAirPressure)
        {
            Car car = new Car(i_Model, i_LicenseNumber, i_CarColor, i_NumberOfDoors);
            car.CreateWheelsCollection(k_CarWheelsNumber, i_WheelsManufacturerName, i_CurrentWheelAirPressure, k_CarMaxAirPressure);
            return car;
        }

        private static Truck createTruck(string i_Model, string i_LicenseNumber, bool i_IsCarryDangerousMatrials, float i_BaggageCapacity, string i_WheelsManufacturerName, float i_CurrentWheelAirPressure)
        {
            Truck truck = new Truck(i_Model, i_LicenseNumber, i_BaggageCapacity);
            truck.IsCarryingDangerousMatrials = i_IsCarryDangerousMatrials;
            truck.CreateWheelsCollection(k_TruckWheelsNumber, i_WheelsManufacturerName, i_CurrentWheelAirPressure, k_TruckMaxAirPressure);
            return truck;
        }

        private static FuelEngine createFuelEngine(float i_MaxCapacity, eFuelType i_FuelType, float i_CurrentEnergyAmount)
        {
            FuelEngine fuelEngine = new FuelEngine(i_MaxCapacity, i_FuelType);
            fuelEngine.CurrentEnergyAmount = i_CurrentEnergyAmount;
            return fuelEngine;
        }

        private static ElectricEngine createElectricEngine(float i_MaxCapacity, float i_CurrentEnergyAmount)
        {
            ElectricEngine electricEngine = new ElectricEngine(i_MaxCapacity);
            electricEngine.CurrentEnergyAmount = i_CurrentEnergyAmount;
            return electricEngine;
        }

        public static Vehicle CreateFuelMotorcycle(string i_Model, string i_LicenseNumber, eLicenseType i_LicenseType, int i_EngineCapacity, string i_WheelsManufacturerName, float i_CurrentAirPressure, float i_CurrentEnergyAmount)
        {
            Motorcycle fuelMotorcycle = createMotorcycle(i_Model, i_LicenseNumber, i_LicenseType, i_EngineCapacity, i_WheelsManufacturerName, i_CurrentAirPressure);
            fuelMotorcycle.Engine = createFuelEngine(k_CapacityOfFuelEngineMotorcycle, eFuelType.Octan95, i_CurrentEnergyAmount);
            return fuelMotorcycle;
        }

        public static Vehicle CreateElectricMotorcycle(string i_Model, string i_LicenseNumber, eLicenseType i_LicenseType, int i_EngineCapacity, string i_WheelsManufacturerName, float i_CurrentAirPressure, float i_CurrentEnergyAmount)
        {
            Motorcycle electricMotorcycle = createMotorcycle(i_Model, i_LicenseNumber, i_LicenseType, i_EngineCapacity, i_WheelsManufacturerName, i_CurrentAirPressure);
            electricMotorcycle.Engine = createElectricEngine(k_CapacityTimeOfElectricEngineMotorcycle, i_CurrentEnergyAmount);
            return electricMotorcycle;
        }

        public static Vehicle CreateFuelCar(string i_Model, string i_LicenseNumber, eColor i_CarColor, eNumberOfDoors i_NumOfDoors, string i_WheelsManufacturerName, float i_CurrentWheelAirPressure, float i_CurrentEnergyAmount)
        {
            Car fuelCar = createCar(i_Model, i_LicenseNumber, i_CarColor, i_NumOfDoors, i_WheelsManufacturerName, i_CurrentWheelAirPressure);
            fuelCar.Engine = createFuelEngine(k_CapacityOfFuelEngineCar, eFuelType.Octan96, i_CurrentEnergyAmount);
            return fuelCar;
        }

        public static Vehicle CreateElectricCar(string i_Model, string i_LicenseNumber, eColor i_CarColor, eNumberOfDoors i_NumOfDoorsstring, string i_WheelsManufacturerName, float i_CurrentWheelAirPressure, float i_CurrentEnergyAmount)
        {
            Car electricCar = createCar(i_Model, i_LicenseNumber, i_CarColor, i_NumOfDoorsstring, i_WheelsManufacturerName, i_CurrentWheelAirPressure);
            electricCar.Engine = createElectricEngine(k_CapacityTimeOfElectricEngineCar, i_CurrentEnergyAmount);
            return electricCar;
        }

        public static Vehicle CreateFuelTruck(string i_Model, string i_LicenseNumber, bool i_IsCarryDangerousMatrials, float i_BaggageCapacity, string i_WheelsManufactureName, float i_CurrentWheelAirPressure, float i_CurrentEnergyAmount)
        {
            Truck truck = createTruck(i_Model, i_LicenseNumber, i_IsCarryDangerousMatrials, i_BaggageCapacity, i_WheelsManufactureName, i_CurrentWheelAirPressure);
            truck.Engine = createFuelEngine(k_CapacityOfEngineTruck, eFuelType.Soler, i_CurrentEnergyAmount);
            return truck;
        }
    }
}
