
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Ex03.ConsoleUI
{
    public class UI
    {
        private GarageLogic.Garage m_Garage;
        private bool m_ToQuit = false;

        public void OpenGarage()
        {
            Console.WriteLine("Welcome!");
            m_Garage = new GarageLogic.Garage();
            while (!m_ToQuit)
            {
                Console.WriteLine("Please choose one option to do from the list:");
                Console.WriteLine();
                printMainMenu();
                performChoise(getChoiseNumber());
                Console.WriteLine();
                if (!m_ToQuit)
                {
                    Console.WriteLine("Press anything to return to main menu");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }

        private int getChoiseNumber()
        {
            int choiseNumber = 0;
            bool isValidChoiseNumber = false;
            while (choiseNumber <= 0 || choiseNumber >= 9 || !isValidChoiseNumber)
            {
                Console.WriteLine("Choose an option number between 1 to 8");
                isValidChoiseNumber = int.TryParse(Console.ReadLine(), out choiseNumber);
            }
            return choiseNumber;
        }

        private void performChoise(int i_choiseNumber)
        {
            switch (i_choiseNumber)
            {
                case 1:
                    addNewVehicle();
                    break;
                case 2:
                    ShowAllLicenseNumberOfVehiclesInGarage();
                    break;
                case 3:
                    UpdateVehicleStatus();
                    break;
                case 4:
                    FillAirInWheels();
                    break;
                case 5:
                    FuelVehicle();
                    break;
                case 6:
                    ChargeElectricEngine();
                    break;
                case 7:
                    ShowVehicleDetails();
                    break;
                default:
                    m_ToQuit = true;
                    break;
            }
        }

        private void printMainMenu()
        {
            Console.WriteLine(string.Format(@"1. Add new vehicle
2. Show list of all the vehicles by licenses number
3. Update vehicle's status
4. Fill air in wheels
5. Fuel vehicle
6. Charge vehicle's electric engine
7. Show vehicle's details 
8. Exit"));
        }

        private void addNewVehicle()
        {
            string licenseNumber = getLicenseNumber();
            if (!m_Garage.IsVehicleExists(licenseNumber))
            {
                string ownerName = getOwnerName();
                string ownerPhoneNumber = getPhoneNumber();
                string vehicleModel = getModel();
                GarageLogic.eVehicleType vehicleType = getVehicleType();
                string wheelsManufaturerName = getWheelsManufatcureName();
                GarageLogic.eLicenseType licenseType = GarageLogic.eLicenseType.A;
                int engineCapacity = 0;
                float currentWheelAirPresure = 0;
                float currentEnergyAmount = 0;
                GarageLogic.eEngineType engineType;
                switch (vehicleType)
                {
                    case GarageLogic.eVehicleType.Motorcycle:
                        GetMotorcycleDetails(out licenseType, out engineCapacity, out currentWheelAirPresure);
                        engineType = getEngineType();
                        if (engineType == GarageLogic.eEngineType.Fuel)
                        {
                            currentEnergyAmount = getCurrentEnergyAmount(GarageLogic.CreateNewVehicle.k_CapacityOfFuelEngineMotorcycle);
                            m_Garage.AddNewVehicle(GarageLogic.CreateNewVehicle.CreateVehicleInGarage(GarageLogic.CreateNewVehicle.CreateFuelMotorcycle(vehicleModel, licenseNumber, licenseType, engineCapacity, wheelsManufaturerName, currentWheelAirPresure, currentEnergyAmount), ownerName, ownerPhoneNumber));
                        }
                        else
                        {
                            currentEnergyAmount = getCurrentEnergyAmount(GarageLogic.CreateNewVehicle.k_CapacityTimeOfElectricEngineMotorcycle);
                            m_Garage.AddNewVehicle(GarageLogic.CreateNewVehicle.CreateVehicleInGarage(GarageLogic.CreateNewVehicle.CreateElectricMotorcycle(vehicleModel, licenseNumber, licenseType, engineCapacity, wheelsManufaturerName, currentWheelAirPresure, currentEnergyAmount), ownerName, ownerPhoneNumber));
                        }
                        break;
                    case GarageLogic.eVehicleType.Car:
                        GarageLogic.eColor carColor = GarageLogic.eColor.Red;
                        GarageLogic.eNumberOfDoors carNumberOfDoors = GarageLogic.eNumberOfDoors.Two;
                        GetCarDetails(out carColor, out carNumberOfDoors, out currentWheelAirPresure);
                        engineType = getEngineType();
                        if (engineType == GarageLogic.eEngineType.Fuel)
                        {
                            currentEnergyAmount = getCurrentEnergyAmount(GarageLogic.CreateNewVehicle.k_CapacityOfFuelEngineCar);
                            m_Garage.AddNewVehicle(GarageLogic.CreateNewVehicle.CreateVehicleInGarage(GarageLogic.CreateNewVehicle.CreateFuelCar(vehicleModel, licenseNumber, carColor, carNumberOfDoors, wheelsManufaturerName, currentWheelAirPresure, currentEnergyAmount), ownerName, ownerPhoneNumber));
                        }
                        else
                        {
                            currentEnergyAmount = getCurrentEnergyAmount(GarageLogic.CreateNewVehicle.k_CapacityTimeOfElectricEngineCar);
                            m_Garage.AddNewVehicle(GarageLogic.CreateNewVehicle.CreateVehicleInGarage(GarageLogic.CreateNewVehicle.CreateElectricCar(vehicleModel, licenseNumber, carColor, carNumberOfDoors, wheelsManufaturerName, currentWheelAirPresure, currentEnergyAmount), ownerName, ownerPhoneNumber));
                        }

                        break;
                    default:
                        bool isCarryDangerousMaterials;
                        float baggageCapacity;
                        GetTruckDetails(out isCarryDangerousMaterials, out baggageCapacity, out currentWheelAirPresure);
                        currentEnergyAmount = getCurrentEnergyAmount(GarageLogic.CreateNewVehicle.k_CapacityOfEngineTruck);
                        m_Garage.AddNewVehicle(GarageLogic.CreateNewVehicle.CreateVehicleInGarage(GarageLogic.CreateNewVehicle.CreateFuelTruck(licenseNumber, vehicleModel, isCarryDangerousMaterials, baggageCapacity, wheelsManufaturerName, currentWheelAirPresure, currentEnergyAmount), ownerName, ownerPhoneNumber));
                        break;
                }

                Console.WriteLine("Your request completed!");
            }
            else
            {
                Console.WriteLine("This vehicle already exsits!");
                m_Garage.UpdateVehicleStatus(licenseNumber, GarageLogic.eVehicleStatus.InRepair);
            }
        }

        private GarageLogic.eEngineType getEngineType()
        {
            int userChoise;
            GetEnumType(Enum.GetNames((typeof(GarageLogic.eEngineType))), "Please enter engine type", out userChoise);

            return (GarageLogic.eEngineType)userChoise;
        }

        public GarageLogic.eVehicleType getVehicleType()
        {
            int userChoise;
            GetEnumType(Enum.GetNames(typeof(GarageLogic.eVehicleType)), "Please enter vehicle type", out userChoise);

            return (GarageLogic.eVehicleType)userChoise;
        }

        public void GetMotorcycleDetails(out GarageLogic.eLicenseType o_LicenseType, out int o_EngineCapacity, out float o_CurrentWheelAirPresure)
        {
            int userChoise;
            GetEnumType(Enum.GetNames((typeof(GarageLogic.eLicenseType))), "Please enter license type", out userChoise);
            o_LicenseType = (GarageLogic.eLicenseType)userChoise;
            o_EngineCapacity = getEngineCapacity();
            o_CurrentWheelAirPresure = getCurrentWheelAirPresure(GarageLogic.CreateNewVehicle.k_MotorcycleMaxAirPressure);
        }

        private int getEngineCapacity()
        {
            int engineCapacity = 0;
            Console.WriteLine("Please enter engine capacity");
            while ((!(int.TryParse(Console.ReadLine(), out engineCapacity)) || (engineCapacity < 0)))
            {
                Console.WriteLine(("Invalid engine capacity"));
            }
            return engineCapacity;
        }

        public void GetCarDetails(out GarageLogic.eColor o_CarColor, out GarageLogic.eNumberOfDoors o_CarNumberOfDoors, out float o_CurrentWheelAirPresure)
        {
            int userChoise;
            GetEnumType(Enum.GetNames((typeof(GarageLogic.eNumberOfDoors))), "Please enter number of doors", out userChoise);
            o_CarNumberOfDoors = (GarageLogic.eNumberOfDoors)userChoise;
            GetEnumType(Enum.GetNames((typeof(GarageLogic.eColor))), "Please enter car color", out userChoise);
            o_CarColor = (GarageLogic.eColor)userChoise;
            o_CurrentWheelAirPresure = getCurrentWheelAirPresure(GarageLogic.CreateNewVehicle.k_CarMaxAirPressure);
        }

        public void GetTruckDetails(out bool o_IsCarryingDangerousMaterials, out float o_BaggageCapacity, out float o_CurrentWheelAirPresure)
        {
            o_IsCarryingDangerousMaterials = isCarryDangerousMaterials();
            o_BaggageCapacity = getBaggageCapacity();
            o_CurrentWheelAirPresure = getCurrentWheelAirPresure(GarageLogic.CreateNewVehicle.k_TruckMaxAirPressure);
        }

        private bool isCarryDangerousMaterials()
        {
            int userChoise;
            bool isCarryingDangerousMaterials = false;
            GetEnumType(Enum.GetNames((typeof(GarageLogic.eTruckBaggageType))), "Please enter baggage type", out userChoise);
            if (userChoise == 1)
            {
                isCarryingDangerousMaterials = true;
            }

            return isCarryingDangerousMaterials;
        }

        private float getBaggageCapacity()
        {
            float baggageCapacity = 0;

            Console.WriteLine("Please enter baggage capacity");
            while (!(float.TryParse(Console.ReadLine(), out baggageCapacity)) || baggageCapacity < 0)
            {
                Console.WriteLine("Invalid baggage capacity");
            }

            return baggageCapacity;
        }

        private float getCurrentWheelAirPresure(float i_MaxAirPresure)
        {
            float currentWheelAirPresure = 0f;
            bool isValidNumber = false;
            Console.WriteLine("Please enter current wheel air presure");
            while (!isValidNumber)
            {
                isValidNumber = float.TryParse(Console.ReadLine(), out currentWheelAirPresure);
                if (isValidNumber && currentWheelAirPresure <= i_MaxAirPresure && currentWheelAirPresure >= 0)
                {
                    return currentWheelAirPresure;
                }
                else
                {
                    isValidNumber = false;
                    Console.WriteLine(string.Format("Invalid wheel air presure. Please enter presure between 0 to {0}", i_MaxAirPresure));
                }
            }

            return currentWheelAirPresure;
        }

        private void ShowAllLicenseNumberOfVehiclesInGarage()
        {
            List<string> licenseNumbers;
            int userChoise;
            if (m_Garage.GetNumberOfVehicleInGarge() != 0)
            {
                GetEnumType(Enum.GetNames((typeof(GarageLogic.eVehicleStatus))), "Please enter vehicle status to filter by", out userChoise);
                licenseNumbers = m_Garage.GetAllLicenseNumbers(userChoise);
                foreach (string licenseNumber in licenseNumbers)
                {
                    Console.WriteLine(licenseNumber);
                }
            }
            else
            {
                Console.WriteLine("There is no vehicle in the garage");
            }
            Console.WriteLine("Your request completed!");
        }

        private void UpdateVehicleStatus()
        {
            string licenseNumber = getLicenseNumber();
            if (!(m_Garage.IsVehicleExists(licenseNumber)))
            {
                Console.WriteLine("Vehicle doesn't exists");
            }
            else
            {
                int userChoise;
                GetEnumType(Enum.GetNames((typeof(GarageLogic.eVehicleStatus))), "Please enter vehicle status", out userChoise);
                m_Garage.UpdateVehicleStatus(licenseNumber, ((GarageLogic.eVehicleStatus)userChoise));
                Console.WriteLine("Your request completed!");
            }
        }

        private void FillAirInWheels()
        {
            string licenseNumber = getLicenseNumber();

            if (!(m_Garage.IsVehicleExists(licenseNumber)))
            {
                Console.WriteLine("Vehicle doesn't exists");
            }
            else
            {
                m_Garage.FillAirPresure(licenseNumber);
                Console.WriteLine("Your request completed!");
            }
        }

        private void FuelVehicle()
        {
            string licenseNumber = getLicenseNumber();
            bool isFueled = false;

            if (!(m_Garage.IsVehicleExists(licenseNumber)))
            {
                Console.WriteLine("Vehicle doesn't exists");
            }
            else
            {
                GarageLogic.Vehicle vehicle = m_Garage.GetVehicle(licenseNumber).Vehicle;

                if (vehicle.Engine is GarageLogic.FuelEngine)
                {
                    if (vehicle.Engine.CurrentEnergyAmount == vehicle.Engine.MaxCapacity)
                    {
                        isFueled = true;
                        Console.WriteLine("The vehicle has been completely fueled already!");
                    }

                    while (!isFueled)
                    {
                        int userChoise;
                        GetEnumType(Enum.GetNames(typeof(GarageLogic.eFuelType)), "Please enter fuel type", out userChoise);

                        float NumberOflitersToFill;
                        Console.WriteLine("Please enter number of liters to Fill");
                        if ((float.TryParse(Console.ReadLine(), out NumberOflitersToFill)) && (NumberOflitersToFill >= 0))
                        {
                            try
                            {
                                m_Garage.FillFuelInVehicle(licenseNumber, ((GarageLogic.eFuelType)userChoise), NumberOflitersToFill);
                                Console.WriteLine("Your request completed!");
                                isFueled = true;
                            }
                            catch (ArgumentException e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            catch (GarageLogic.ValueOutOfRangeException e)
                            {
                                Console.WriteLine(e.Message);
                                Console.WriteLine(string.Format("Enter number of liters to fill between 0 to {0}", (vehicle.Engine.MaxCapacity - vehicle.Engine.CurrentEnergyAmount)));
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("This Vehicle's engine isn't a fuel engine");
                }
            }
        }

        private void ChargeElectricEngine()
        {
            string licenseNumber = getLicenseNumber();
            bool isCharged = false;
            if (!(m_Garage.IsVehicleExists(licenseNumber)))
            {
                Console.WriteLine("Vehicle doesn't exists");
            }
            else
            {
                GarageLogic.Vehicle vehicle = m_Garage.GetVehicle(licenseNumber).Vehicle;

                if (vehicle.Engine is GarageLogic.ElectricEngine)
                {
                    if (vehicle.Engine.CurrentEnergyAmount == vehicle.Engine.MaxCapacity)
                    {
                        Console.WriteLine("The vehicle has been completely charged already!");
                        isCharged = true;
                    }

                    while (!isCharged)
                    {
                        Console.WriteLine("Please enter number of minutes to charge");
                        float minutesToCharge;
                        if ((float.TryParse(Console.ReadLine(), out minutesToCharge)) && (minutesToCharge >= 0))
                        {
                            try
                            {
                                m_Garage.ChargeElectricEngine(licenseNumber, minutesToCharge);
                                Console.WriteLine("Your request completed!");
                                isCharged = true;
                            }
                            catch (GarageLogic.ValueOutOfRangeException e)
                            {
                                Console.WriteLine(e.Message);
                                Console.WriteLine(string.Format("Enter number of minutes to charge between 0 to {0}", (vehicle.Engine.MaxCapacity - vehicle.Engine.CurrentEnergyAmount) * 60));
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("This Vehicle's engine isn't an electric engine");
                }
            }
        }


        private void ShowVehicleDetails()
        {
            string licenseNumber = getLicenseNumber();
            if (!(m_Garage.IsVehicleExists(licenseNumber)))
            {
                Console.WriteLine("Vehicle doesn't exists");
            }
            else
            {
                Console.WriteLine(m_Garage.GetVehicle(licenseNumber));
                Console.WriteLine("Your request completed!");
            }
        }

        private string getModel()
        {
            Console.WriteLine("Please enter model");
            string model = "";
            bool isValidModel = false;
            while (!isValidModel)
            {
                model = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(model))
                {
                    isValidModel = false;
                    Console.WriteLine("Please enter a valid model");
                }
                else
                {
                    isValidModel = true;
                }
            }
            return model;
        }

        private string getLicenseNumber()
        {
            Console.WriteLine("Please enter license number");
            string licenseNumber = "";
            bool isValidLicenseNumber = false;
            while (!isValidLicenseNumber)
            {
                licenseNumber = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(licenseNumber))
                {
                    isValidLicenseNumber = false;
                    Console.WriteLine("Please enter a valid license number");
                }
                else
                {
                    isValidLicenseNumber = true;
                }
            }
            return licenseNumber;
        }

        private string getOwnerName()
        {
            Console.WriteLine("Please enter owner name");
            string name = "";
            bool isValidName = false;
            while (!isValidName)
            {
                name = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(name))
                {
                    isValidName = false;
                    Console.WriteLine("Please enter a valid owner name");
                }
                else
                {
                    isValidName = true;
                }
            }
            return name;
        }

        private string getPhoneNumber()
        {
            Console.WriteLine("Please enter phone number");
            string phoneNumber = "";
            bool isValidPhoneNumber = false;
            while (!isValidPhoneNumber)
            {
                phoneNumber = Console.ReadLine();
                int number;
                isValidPhoneNumber = (int.TryParse(phoneNumber, out number)) && (number >= 0);
                if (!isValidPhoneNumber)
                {
                    Console.WriteLine("Please enter a valid phone number");
                }
            }
            return phoneNumber;
        }

        private string getWheelsManufatcureName()
        {
            Console.WriteLine("Please enter wheels manufatcure name");
            string name = "";
            bool isValidName = false;
            while (!isValidName)
            {
                name = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(name))
                {
                    isValidName = false;
                    Console.WriteLine("Please enter a valid wheels manufatcure name");
                }
                else
                {
                    isValidName = true;
                }
            }
            return name;
        }

        private float getCurrentEnergyAmount(float i_MaxCapacity)
        {
            Console.WriteLine("Please enter current energy amount");
            float currentEnergyAmount = -1;
            bool isValidAmount = false;
            while (!isValidAmount)
            {
                isValidAmount = (float.TryParse(Console.ReadLine(), out currentEnergyAmount)) && (currentEnergyAmount >= 0) && (currentEnergyAmount <= i_MaxCapacity);
                if (!isValidAmount)
                {
                    Console.WriteLine(string.Format("Please enter a valid amount of energy between 0 to {0}", i_MaxCapacity));
                }
            }

            return currentEnergyAmount;
        }

        private void GetEnumType(string[] i_EnumList, string i_Message, out int i_UserChoise)
        {
            int i = 1;
            Console.WriteLine(i_Message);
            foreach (string enumType in i_EnumList)
            {
                Console.WriteLine(string.Format("{0}.{1}", i, enumType));
                i++;
            }

            i_UserChoise = GetUserChoise(1, i - 1);
        }

        private int GetUserChoise(int i_Min, int i_Max)
        {
            string choise = Console.ReadLine();
            int userChoise;
            while (!(int.TryParse(choise, out userChoise)) || (userChoise < i_Min) || (userChoise > i_Max))
            {
                Console.WriteLine("Please press a number between {0} to {1}", i_Min, i_Max);
                choise = Console.ReadLine();
            }
            return userChoise;
        }
    }
}
