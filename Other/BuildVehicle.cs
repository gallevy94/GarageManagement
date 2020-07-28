using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B19_Ex03_Aviv_315529131_Gal_205431141
{
    public class BuildVehicle
    {
        public static Vehicle getVehicleFromUser(Vehicle.eType i_Type, List<object> i_Paramaters)
        {
            Vehicle newVehicle = null;
            switch (i_Type)
            {
                case Vehicle.eType.ElectricCar:
                    newVehicle = new ElectricCar(
                        i_Paramaters[0].ToString(),
                        i_Paramaters[1].ToString(),
                        float.Parse(i_Paramaters[2].ToString()),
                        (string)i_Paramaters[3], 
                        (Car.eColor)Enum.Parse(typeof(Car.eColor), 
                        i_Paramaters[5].ToString()),
                        (Car.eDoorsAmount)Enum.Parse(typeof(Car.eDoorsAmount),
                        i_Paramaters[6].ToString()),
                        float.Parse(i_Paramaters[4].ToString()));
                    break;

                case Vehicle.eType.FuelCar:
                    newVehicle = new FuelCar(
                        i_Paramaters[0].ToString(),
                        i_Paramaters[1].ToString(), 
                        float.Parse(i_Paramaters[2].ToString()),
                        i_Paramaters[3].ToString(), 
                        (Car.eColor)Enum.Parse(typeof(Car.eColor),
                        i_Paramaters[5].ToString()),
                        (Car.eDoorsAmount)Enum.Parse(typeof(Car.eDoorsAmount),
                        i_Paramaters[6].ToString()),
                        float.Parse(i_Paramaters[4].ToString()));
                    break;

                case Vehicle.eType.ElectricMotorcycle:
                    newVehicle = new ElectricMotorcycle(
                        i_Paramaters[0].ToString(), 
                        i_Paramaters[1].ToString(),
                        float.Parse(i_Paramaters[2].ToString()), 
                        i_Paramaters[3].ToString(),
                        (Motorcycle.eLicenseType)Enum.Parse(typeof(Motorcycle.eLicenseType),
                        i_Paramaters[5].ToString()),
                        int.Parse(i_Paramaters[6].ToString()),
                        float.Parse(i_Paramaters[4].ToString()));
                    break;

                case Vehicle.eType.FuelMotorcycle:
                    newVehicle = new FuelMotorcycle(
                        i_Paramaters[0].ToString(),
                        i_Paramaters[1].ToString(),
                        float.Parse(i_Paramaters[2].ToString()),
                        i_Paramaters[3].ToString(),
                        (Motorcycle.eLicenseType)Enum.Parse(typeof(Motorcycle.eLicenseType),
                        i_Paramaters[5].ToString()),
                        int.Parse(i_Paramaters[6].ToString()),
                        float.Parse(i_Paramaters[4].ToString()));
                    break;

                case Vehicle.eType.FuelTruck:
                    newVehicle = new FuelTrack(
                        i_Paramaters[0].ToString(),
                        i_Paramaters[1].ToString(),
                        float.Parse(i_Paramaters[2].ToString()),
                        i_Paramaters[3].ToString(),
                        bool.Parse(i_Paramaters[5].ToString()),
                        float.Parse(i_Paramaters[6].ToString()),
                        float.Parse(i_Paramaters[4].ToString()));
                    break;

                default:
                    break;
            }

            return newVehicle;
        }
    }
}
