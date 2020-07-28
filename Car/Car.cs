using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B19_Ex03_Aviv_315529131_Gal_205431141
{
    public abstract class Car : Vehicle
    {
        private const int k_NumberOfWheels = 4; 
        private const float k_WheelsMaxAirPressure = 31;
        private eColor m_Color;
        private eDoorsAmount m_DoorsNumber;

        public Car(
            string i_ModelName,
            string i_LicensePlate,
            float i_EnergyLeft,
            string i_ManufacturerName, 
            eColor i_Color,
            eDoorsAmount i_DoorsNumber, 
            float i_MaxEngineCapacity, 
            float i_CurrentAirPressure,
            Engine i_Engine,
            Vehicle.eType i_VehicleType) : base(
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
            m_Color = i_Color;
            m_DoorsNumber = i_DoorsNumber;
        }

        public enum eColor
        {
            Red = 1,
            Blue = 2,
            Black = 3,
            Gray = 4
        }

        public enum eDoorsAmount
        {
            Two = 1,
            Three = 2,
            Four = 3,
            Five = 4
        }

        public eColor Color
        {
            get
            {
                return m_Color;
            }
        }

        public eDoorsAmount Doors
        {
            get
            {
                return m_DoorsNumber;
            }
        }

        public static new List<VehicleParameters> GetParameters()
        {
            List<VehicleParameters> theParameters = Vehicle.GetParameters();
            theParameters.Add(new VehicleParameters("Color Of Car", typeof(Car.eColor)));
            theParameters.Add(new VehicleParameters("Number Of Doors", typeof(Car.eDoorsAmount)));

            return theParameters;
        }

        public override string ToString()
        {
            return base.ToString() + string.Format("Number of doors: {0}{2}" + "Color of the car: {1}{2}", m_DoorsNumber, m_Color, Environment.NewLine);
        }
    }
}
