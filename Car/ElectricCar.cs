using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B19_Ex03_Aviv_315529131_Gal_205431141
{
    public class ElectricCar : Car
    {
        private const float m_MaxBatteryTime = 1.8f;
        private const Vehicle.eType m_Type = Vehicle.eType.ElectricCar;
        private float m_BatteryTimeLeft = 0;

        public ElectricCar(
            string i_ModelName,
            string i_LicensePlate,
            float i_BatteryTimeLeft,
            string i_ManufacturerName,
            eColor i_Color,
            eDoorsAmount i_DoorsNumber,
            float i_CurrentAirPressure) : base(
                                        i_ModelName,
                                        i_LicensePlate,
                                        i_BatteryTimeLeft, 
                                        i_ManufacturerName,
                                        i_Color,
                                        i_DoorsNumber,
                                        m_MaxBatteryTime,
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
