using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B19_Ex03_Aviv_315529131_Gal_205431141
{
    public abstract class Motorcycle : Vehicle
    {
        private const int k_NumberOfWheels = 2;
        private const float k_WheelsMaxAirPressure = 33;
        private eLicenseType m_LicenseType;
        private int m_EngineCapacity;

        public Motorcycle(
            string i_ModelName, 
            string i_LicensePlate,
            float i_EnergyLeft,
            float i_MaxAirPressure,
            string i_ManufacturerName, 
            eLicenseType i_LicenseType, 
            float i_MaxEngineCapacity,
            int i_EngineCapacity, 
            float i_CurrentAirPressure,
            Engine i_Engine,
            Vehicle.eType i_VehicleType)
                          : base(
                                i_ModelName,
                                i_LicensePlate,
                                i_EnergyLeft,
                                k_NumberOfWheels,
                                k_WheelsMaxAirPressure,
                                i_ManufacturerName,
                                i_MaxEngineCapacity, 
                                i_CurrentAirPressure,
                                i_Engine,
                                i_VehicleType)
        {
            m_LicenseType = i_LicenseType;
            m_EngineCapacity = i_EngineCapacity;
        }

        public enum eLicenseType
        {
            A,
            A1,
            A2,
            B
        }

        public int EngineCapacity
        {
            get
            {
                return m_EngineCapacity;
            }
        }

        public eLicenseType LicenseType
        {
            get
            {
                return m_LicenseType;
            }
        }

        public static new List<VehicleParameters> GetParameters()
        {
            List<VehicleParameters> theParameters = Vehicle.GetParameters();
            theParameters.Add(new VehicleParameters("License Type Of Motorcycle", typeof(Motorcycle.eLicenseType)));
            theParameters.Add(new VehicleParameters("Engine Capacity of Motorcycle", typeof(int)));

            return theParameters;
        }

        public override string ToString()
        {
            return base.ToString() + string.Format("Licence Type is: {0}{2}" + "Engine Capacity is: {1}{2}", m_LicenseType, m_EngineCapacity, Environment.NewLine);
        }
    }
}
