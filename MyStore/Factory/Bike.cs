using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    public class Bike : IDrivable
    {
        public int WheelNo { get; set; }

        public void Drive(int km)
        {
            Console.WriteLine($"Drive the bike: {km} km");
        }
    }
}
