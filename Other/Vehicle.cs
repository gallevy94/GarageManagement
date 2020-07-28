using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B19_Ex03_Aviv_315529131_Gal_205431141
{
    public abstract class Vehicle
    {
        private string m_ModelName;
        private string m_LicensePlate;
        private float m_MaxEngineCapacity;
        private float m_EnergyPrecentLeft = 0;
        private Engine m_EnergySource;
        private List<Wheel> m_Wheels = new List<Wheel>();
        private eType m_TypeOfVehicle;

        public Vehicle(
            string i_ModelName,
            string i_LicensePlate,
            float i_EnergyLeft,
            int i_NumberOfWheels,
            float i_MaxAirPressure,
            string i_ManufacturerName,
            float i_MaxEngineCapacity, 
            float i_CurrentAirPressure, 
            Engine i_engine, 
            eType i_TypeOfVehicle)
        {
            m_MaxEngineCapacity = i_MaxEngineCapacity;
            m_ModelName = i_ModelName;
            m_LicensePlate = i_LicensePlate;
            m_EnergyPrecentLeft = i_EnergyLeft;
            m_EnergySource = i_engine;
            m_TypeOfVehicle = i_TypeOfVehicle;
            CreateWheels(i_NumberOfWheels, i_ManufacturerName, i_MaxAirPressure, i_CurrentAirPressure);
        }

        public enum eType
        {
            ElectricCar = 1,
            FuelCar = 2,
            ElectricMotorcycle = 3,
            FuelMotorcycle = 4,
            FuelTruck = 5
        }

        public eType TypeOfVehicle
        {
            get
            {
                return m_TypeOfVehicle;
            }
        }

        public Engine EnergySource
        {
            get
            {
                return m_EnergySource;
            }
        }

        public string ModelName
        {
            get
            {
                return m_ModelName;
            }
        }

        public string LicensePlate
        {
            get
            {
                return m_LicensePlate;
            }
        }

        public float EnergyPrecentLeft
        {
            get
            {
                return 100 * (m_EnergyPrecentLeft / m_MaxEngineCapacity);
            }
        }

        public List<Wheel> Wheels
        {
            get
            {
                return m_Wheels;
            }
        }

        public static List<VehicleParameters> GetParameters()
        {
            List<VehicleParameters> theParameters = new List<VehicleParameters>();
            theParameters.Add(new VehicleParameters("Model Name", typeof(string)));
            theParameters.Add(new VehicleParameters("License Plate", typeof(string)));
            theParameters.Add(new VehicleParameters("Current Energy", typeof(float)));
            theParameters.Add(new VehicleParameters("Wheels Manufacturer", typeof(string)));
            theParameters.Add(new VehicleParameters("Current Air Pressure", typeof(float)));

            return theParameters;
        }

        public static List<VehicleParameters> ChooseParametrsByType(eType type)
        {
            List<VehicleParameters> theParametresByType = new List<VehicleParameters>();

            if (type.ToString() == "ElectricCar" || type.ToString() == "FuelCar")
            {
                theParametresByType = Car.GetParameters();
            }
            else if (type.ToString() == "ElectricMotorcycle" || type.ToString() == "FuelMotorcycle")
            {
                theParametresByType = Motorcycle.GetParameters();
            }
            else if (type.ToString() == "FuelTruck")
            {
                theParametresByType = FuelTrack.GetParameters();
            }

            return theParametresByType;
        }

        public void CreateWheels(int i_NumberOfWeels, string i_ManufacturerName, float i_MaxAirPressure, float i_CurrentAirPressure)
        {
            if (i_CurrentAirPressure > i_MaxAirPressure || i_CurrentAirPressure < 0)
            {
                throw new ValueOutOfRangeException(0, i_MaxAirPressure);
            }

            for (int i = 0; i < i_NumberOfWeels; i++)
            {
                m_Wheels.Add(new Wheel(i_ManufacturerName, i_MaxAirPressure, i_CurrentAirPressure));
            }
        }

        public override string ToString()
        {
            return string.Format(
                "License Plate: {0}{8}" +
                "Model Name: {1}{8}" +
                "Current Air Pressure: {2}{8}" +
                "Max Air Pressure: {3}{8}" + 
                "Manufacturer Name: {4}{8}" +
                "Number of wheels: {5}{8}" +
                "Type Of Energy: {6}{8}" +
                "Energy Precent Left: {7}%{8}",
                m_LicensePlate,
                m_ModelName,
                m_Wheels[0].CurrentAirPressure,
                m_Wheels[0].MaxAirPressure,
                m_Wheels[0].ManufacturerName,
                m_Wheels.Count,
                TypeOfVehicle,
                EnergyPrecentLeft,
                Environment.NewLine);
        }
    }
}