using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B19_Ex03_Aviv_315529131_Gal_205431141
{
    public abstract class Engine
    {
        private float m_MaxEnergy;
        private float m_CurrentEnergy;

        public Engine(float i_MaxEnergy, float i_CurrentEnergy)
        {
            m_MaxEnergy = i_MaxEnergy;
            //// check if its out of range
            if (i_CurrentEnergy > i_MaxEnergy || i_CurrentEnergy < 0) 
            {
                throw new ValueOutOfRangeException(0, i_MaxEnergy);
            }

            m_CurrentEnergy = i_CurrentEnergy;
        }

        public void AddEnergyOperation(float i_AmountToAddEnergy)
        {
            if (m_CurrentEnergy + i_AmountToAddEnergy > m_MaxEnergy || i_AmountToAddEnergy <= 0)
            {
                throw new ValueOutOfRangeException(0, m_MaxEnergy - m_CurrentEnergy);
            }

            m_CurrentEnergy += i_AmountToAddEnergy;
        }
    }
}
