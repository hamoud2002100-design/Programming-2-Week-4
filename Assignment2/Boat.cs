using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public class Boat : IVehicle
    {
        public void Start()
        {
            Console.WriteLine("Propeller is spinning.");
        }
    }
}
