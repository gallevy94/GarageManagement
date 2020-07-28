using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B19_Ex03_Aviv_315529131_Gal_205431141
{
    public class FuelTrack : Vehicle
    {
        private const float m_MaxFuelCapacity = 110;
        private const FuelEngine.eFuelTypes m_FuelType = FuelEngine.eFuelTypes.Soler;
        private const int k_NumberOfWheels = 12;
        private const float k_WheelsMaxAirPressure = 26;
        private const Vehicle.eType m_Type = Vehicle.eType.FuelTruck;
        private bool m_IsDrivesDangerousMaterials;
        private float m_CargoCapacity;
        private float m_CurrentFuelAmount = 0;

        public FuelTrack(
            string i_ModelName,
            string i_LicensePlate,
            float i_CurrentFuelAmount, 
            string i_ManufacturerName,
            bool i_IsDrivesDangerousMaterials,
            float i_CargoCapacity, 
            float i_CurrentAirPressure)
                        : base(
                              i_ModelName,
                              i_LicensePlate, 
                              i_CurrentFuelAmount,
                              k_NumberOfWheels, 
                              k_WheelsMaxAirPressure,
                              i_ManufacturerName,
                              m_MaxFuelCapacity,
                              i_CurrentAirPressure,
                              new FuelEngine(m_MaxFuelCapacity, m_FuelType, i_CurrentFuelAmount),
                              m_Type)
        {
            m_IsDrivesDangerousMaterials = i_IsDrivesDangerousMaterials;
            m_CargoCapacity = i_CargoCapacity;
            m_CurrentFuelAmount = i_CurrentFuelAmount;
        }

        public static new List<VehicleParameters> GetParameters()
        {
            List<VehicleParameters> theParameters = Vehicle.GetParameters();
            theParameters.Add(new VehicleParameters("Is Carrying a Dangerous Materials in Track", typeof(bool)));
            theParameters.Add(new VehicleParameters("Cargo Capacity Of Track", typeof(float)));

            return theParameters;
        }

        public void FuelOperation(float i_AddFuel, FuelEngine.eFuelTypes i_FuelType) 
        {
            FuelEngine fuel = null;
            fuel.FuelOperation(i_AddFuel, m_FuelType);
        }

        public override string ToString()
        {
            return base.ToString() + string.Format("Drives a dangerous materials: {0}{2}" + "Capacity of the cargo: {1}{2}", m_IsDrivesDangerousMaterials, m_CargoCapacity, Environment.NewLine);
        }
    }
}
