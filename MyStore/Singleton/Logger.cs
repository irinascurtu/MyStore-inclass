using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    public class Logger
    {
        private static Logger instance;
        public static int Count;

        private Logger()
        {
            
        }

        public static Logger GetInstance()
        {
            if (instance == null)
            {
                instance = new Logger();
                Count++;
            }

            return instance;
        }

        public void Log(string message)
        {
            Console.WriteLine($"[{DateTime.Now}] {message}");
        }
    }
}
