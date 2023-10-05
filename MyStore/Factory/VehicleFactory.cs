using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Factory.Enums;

namespace Factory
{
    public abstract class VehicleFactory
    {
        public abstract IDrivable GetVehicle(VehicleType vehicleType);
      
    }
}
