using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B19_Ex03_Aviv_315529131_Gal_205431141
{
    public class ElectricMotorcycle : Motorcycle
    {
        private const float m_MaxBatteryTime = 1.4f;
        private const Vehicle.eType m_Type = Vehicle.eType.ElectricMotorcycle;
        private float m_BatteryTimeLeft = 0;

        public ElectricMotorcycle(
            string i_ModelName, 
            string i_LicensePlate,
            float i_BatteryTimeLeft,
            string i_ManufacturerName, 
            eLicenseType i_LicenseType,
            int i_EngineCapacity, 
            float i_CurrentAirPressure)
                                  : base(
                                        i_ModelName, 
                                        i_LicensePlate,
                                        i_BatteryTimeLeft,
                                        m_MaxBatteryTime,
                                        i_ManufacturerName, 
                                        i_LicenseType,
                                        m_MaxBatteryTime,
                                        i_EngineCapacity,
                                        i_CurrentAirPressure,
                                        new ElectricEngine(m_MaxBatteryTime, i_BatteryTimeLeft),
                                        m_Type)
        {
            m_BatteryTimeLeft = i_BatteryTimeLeft;
        }

        public float BatteryTimeLeft
        {
            get
            {
                return m_BatteryTimeLeft;
            }
        }

        public void LoadBatteryOperation(float i_AddTime) 
        {
            ElectricEngine electric = null;
            electric.LoadBatteryOperation(i_AddTime);
        }
    }
}
