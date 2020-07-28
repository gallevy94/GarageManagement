using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B19_Ex03_Aviv_315529131_Gal_205431141
{
    public class ElectricEngine : Engine
    {
        public ElectricEngine(float i_ElectricMaxCapacity, float i_BatteryTimeLeft) : base(i_ElectricMaxCapacity, i_BatteryTimeLeft)
        {
        }

        public void LoadBatteryOperation(float i_AddTime)
        {
            AddEnergyOperation(i_AddTime);
        }
    }
}
