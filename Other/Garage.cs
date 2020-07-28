using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B19_Ex03_Aviv_315529131_Gal_205431141
{
    public class Garage
    {
        private Dictionary<string, VehiclesInGarage> m_CarsInGarage;

        public Garage()
        {
            m_CarsInGarage = new Dictionary<string, VehiclesInGarage>();
        }

        public Dictionary<string, VehiclesInGarage> CarsInGarage
        {
            get
            {
                return m_CarsInGarage;
            }
        }

        public bool TryToAddVehicle(Vehicle i_Vehicle, string i_OwnersName, string i_OwnersTelephone)
        {
            bool isCarExist = m_CarsInGarage.ContainsKey(i_Vehicle.LicensePlate); // true = exist, false = not exist in the garage

            if (i_Vehicle == null)
            {
                throw new ArgumentNullException();
            }
            
            if (isCarExist == true) 
            {
                ChangeVehicleState(i_Vehicle.LicensePlate, VehiclesInGarage.eStateInGarage.RepairInProgress); 
            }
            else
            {
                isCarExist = false;
                VehiclesInGarage newVehicle = new VehiclesInGarage(i_Vehicle, i_OwnersName, i_OwnersTelephone);
                m_CarsInGarage.Add(i_Vehicle.LicensePlate, newVehicle);
            }

            return isCarExist;
        } 

        public void ChangeVehicleState(string i_LicensePlate, VehiclesInGarage.eStateInGarage i_ChangeState)
        {
            VehiclesInGarage vehicle = GetExistVehicles(i_LicensePlate);

            if (vehicle == null)
            {
                throw new ArgumentNullException();
            }
        
            vehicle.StateInGarage = i_ChangeState;
        }
  
        public VehiclesInGarage GetExistVehicles(string i_LicensePlate)
        {
            VehiclesInGarage vehicle;
            bool IsExist = m_CarsInGarage.TryGetValue(i_LicensePlate, out vehicle);

            if (IsExist == false)
            {
                vehicle = null;
            }

            return vehicle;
        }

        public List<string> AllLicensePlates()
        {
            List<string> licensePlates = new List<string>();

            foreach (string licensePlate in m_CarsInGarage.Keys)
            {
                licensePlates.Add(licensePlate);
            }

            return licensePlates;
        }

        public List<string> LicenseNumbersByState(VehiclesInGarage.eStateInGarage i_State)
        {
            List<string> FilteredLicensePlates = new List<string>();

            foreach (VehiclesInGarage vehiclesInGarage in m_CarsInGarage.Values)
            {
                if (i_State == vehiclesInGarage.StateInGarage)
                {
                    FilteredLicensePlates.Add(vehiclesInGarage.Vehicle.LicensePlate);
                }
            }

            return FilteredLicensePlates;
        }

        public void PumpAirInWheelsToMax(string i_LicensePlate)
        {
            VehiclesInGarage vehicle = GetExistVehicles(i_LicensePlate);

            if (vehicle == null)
            {
                throw new ArgumentNullException();
            }

            foreach (Wheel wheel in vehicle.Vehicle.Wheels)
            {
                wheel.PumpOperationToMax();
            }
        }

        public void FuelTheVehicle(string i_LicensePlate, FuelEngine.eFuelTypes i_FuelType, float i_AmountToFill)
        {
            VehiclesInGarage vehicle = GetExistVehicles(i_LicensePlate);

            if (vehicle == null)
            {
                throw new ArgumentNullException();
            }

            if ((vehicle.Vehicle.EnergySource is FuelEngine) == false)
            {
                throw new ArgumentException();
            }

            (vehicle.Vehicle.EnergySource as FuelEngine).FuelOperation(i_AmountToFill, i_FuelType);
        }

        public void ChargeTheVehicle(string i_LicensePlate, float i_AddMinutes)
        {
            VehiclesInGarage vehicle = GetExistVehicles(i_LicensePlate);

            if (vehicle == null)
            {
                throw new ArgumentNullException();
            }

            if (!(vehicle.Vehicle.EnergySource is ElectricEngine))
            {
                throw new ArgumentException();
            }

            float MinutesToHours = i_AddMinutes / 60;
            (vehicle.Vehicle.EnergySource as ElectricEngine).LoadBatteryOperation(MinutesToHours);
        }

        public string DisplayVehicleInformation(string i_LicensePlate)
        {
            VehiclesInGarage vehicle = GetExistVehicles(i_LicensePlate);

            if (vehicle == null)
            {
                throw new ArgumentNullException();
            }

            return vehicle.ToString();
        }

        public class VehiclesInGarage
        {
            private string m_OwnersName;
            private string m_OwnersTelephone;
            private eStateInGarage m_State;
            private Vehicle m_Vehicle;

            public VehiclesInGarage(Vehicle i_Vheicle, string i_OwnersName, string i_OwnersTelephone)
            {
                m_Vehicle = i_Vheicle;
                m_OwnersName = i_OwnersName;
                m_OwnersTelephone = i_OwnersTelephone;
                m_State = eStateInGarage.RepairInProgress;
            }

            public enum eStateInGarage
            {
                RepairInProgress = 1,
                Repaired = 2,
                Payed = 3
            }

            public Vehicle Vehicle
            {
                get
                {
                    return m_Vehicle;
                }
            }

            public eStateInGarage StateInGarage
            {
                get
                {
                    return m_State;
                }

                set
                {
                    m_State = value;
                }
            }

            public string OwnersName
            {
                get
                {
                    return m_OwnersName;
                }
            }

            public string OwnersTelephone
            {
                get
                {
                    return m_OwnersTelephone;
                }
            }

            public override string ToString()
            {
                return string.Format("Owners Name: {0}{2}" + "The state of the vehicle in the garage: {1}{2}", m_OwnersName, m_State, Environment.NewLine) + Vehicle.ToString();
            }
        }
    }
}
