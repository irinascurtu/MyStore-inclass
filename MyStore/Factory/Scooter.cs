using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    public class Scooter : IDrivable
    {
        public int WheelNo { get; set; }

        public void Drive(int km)
        {
            Console.WriteLine($"Drive the scooter: {km} km" );
        }
    }
}
