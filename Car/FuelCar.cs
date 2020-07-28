using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B19_Ex03_Aviv_315529131_Gal_205431141
{
    public class FuelCar : Car
    {
        private const float m_MaxFuelCapacity = 55;
        private const FuelEngine.eFuelTypes m_FuelType = FuelEngine.eFuelTypes.Octan96;
        private const Vehicle.eType m_Type = Vehicle.eType.FuelCar;
        private float m_CurrentFuelAmount = 0;

        public FuelCar(
            string i_ModelName,
            string i_LicensePlate,
            float i_CurrentFuelAmount, 
            string i_ManufacturerName,
            eColor i_Color,
            eDoorsAmount i_DoorsNumber,
            float i_CurrentAirPressure) : base(
                                        i_ModelName,
                                        i_LicensePlate, 
                                        i_CurrentFuelAmount,
                                        i_ManufacturerName, 
                                        i_Color,
                                        i_DoorsNumber,
                                        m_MaxFuelCapacity, 
                                        i_CurrentAirPressure,
                                        new FuelEngine(m_MaxFuelCapacity, m_FuelType, i_CurrentFuelAmount),
                                        m_Type)
        {
            m_CurrentFuelAmount = i_CurrentFuelAmount;
        }

        public void FuelOperation(float i_AddFuel, FuelEngine.eFuelTypes i_FuelType) 
        {
            FuelEngine fuel = null;
            fuel.FuelOperation(i_AddFuel, m_FuelType);
        }
    }
}
