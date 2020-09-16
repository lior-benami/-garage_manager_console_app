using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class VehicleInGarage
    {
        private readonly string r_OwnerName;
        private readonly string r_OwnerPhoneNumber;
        private readonly Vehicle r_Vehicle;
        private eVehicleStatus m_VehicleStatus;

        public VehicleInGarage(string i_OwnerName, string i_OwnerPhoneNumber, Vehicle i_Vehicle)
        {
            this.r_OwnerName = i_OwnerName;
            this.r_OwnerPhoneNumber = i_OwnerPhoneNumber;
            this.r_Vehicle = i_Vehicle;
        }

        public string OwnerName
        {
            get
            {
                return r_OwnerName;
            }
        }

        public string OwnerPhoneNumber
        {
            get
            {
                return r_OwnerPhoneNumber;
            }
        }

        public Vehicle Vehicle
        {
            get
            {
                return r_Vehicle;
            }
        }

        public eVehicleStatus VehicleStatus
        {
            get
            {
                return m_VehicleStatus;
            }
            set
            {
                m_VehicleStatus = value;
            }
        }

        public override string ToString()
        {
            string vehicleInGarageDescription = string.Format(@"Owner name: {0}
Owner phone number: {1}
Vehicle status: {2}
{3}", r_OwnerName, r_OwnerPhoneNumber, m_VehicleStatus, r_Vehicle);

            return vehicleInGarageDescription;
        }
    }

    public enum eVehicleStatus
    {
        InRepair = 1,
        Fixed = 2,
        Paid = 3,
        None = 4
    }
}

