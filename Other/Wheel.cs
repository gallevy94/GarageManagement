using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B19_Ex03_Aviv_315529131_Gal_205431141
{
    public class Wheel
    {
        private string m_ManufacturerName;
        private float m_CurrentAirPressure;
        private float m_MaxAirPressure;

        public Wheel(string i_ManufacturerName, float i_MaxAirPressure, float i_CurrentAirPressure)
        {
            m_ManufacturerName = i_ManufacturerName;
            m_MaxAirPressure = i_MaxAirPressure;
            m_CurrentAirPressure = i_CurrentAirPressure;
        }

        public string ManufacturerName
        {
            get
            {
                return m_ManufacturerName;
            }
        }

        public float CurrentAirPressure
        {
            get
            {
                return m_CurrentAirPressure;
            }
        }

        public float MaxAirPressure
        {
            get
            {
                return m_MaxAirPressure;
            }
        }

        public void PumpOperation(float i_AddAir)
        {
            if (m_CurrentAirPressure + i_AddAir > m_MaxAirPressure || i_AddAir <= 0)
            {
                throw new ValueOutOfRangeException(0, m_MaxAirPressure - m_CurrentAirPressure);
            }

            m_CurrentAirPressure += i_AddAir;
        }

        public void PumpOperationToMax()
        {
            PumpOperation(m_MaxAirPressure - m_CurrentAirPressure);
        }
    }
}
