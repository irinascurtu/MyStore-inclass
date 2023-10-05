using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Factory.Enums;

namespace Factory
{
    //VehicleFactoryImplementation
    public class ConcreteVehicleFactory : VehicleFactory
    {
        public override IDrivable GetVehicle(VehicleType vehicleType)
        {
            switch (vehicleType)
            {
                case VehicleType.Scooter:
                    return new Scooter();
                case VehicleType.Bike:
                    return new Bike();
                default:
                    throw new ApplicationException($"vehicle of type {vehicleType.ToString()} can't be created");

            }
        }

        //public void ComputeNecessaryMaterials()
        //{
        //    Console.WriteLine(2 + 2);
        //}
    }
}
