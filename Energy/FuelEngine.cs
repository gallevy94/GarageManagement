using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B19_Ex03_Aviv_315529131_Gal_205431141
{
    public class FuelEngine : Engine
    {
        private eFuelTypes m_FuelType;

        public FuelEngine(float i_FuelMaxCapacity, eFuelTypes i_FuelType, float i_CurrentFuelAmount)
                        : base(i_FuelMaxCapacity, i_CurrentFuelAmount)
        {
            m_FuelType = i_FuelType;
        }

        public enum eFuelTypes
        {
            Octan98 = 1,
            Octan96 = 2,
            Octan95 = 3,
            Soler = 4
        }

        public eFuelTypes FuelType
        {
            get
            {
                return m_FuelType;
            }
        }

        public void FuelOperation(float i_AddFuel, eFuelTypes i_FuelType)
        {
            if (i_FuelType != m_FuelType)
            {
                throw new ArgumentException();
            }

            AddEnergyOperation(i_AddFuel);
        }
    }
}
