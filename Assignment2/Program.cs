using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;

namespace Assignment2
{
    public class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            program.Start();
        }

        void Start()
        {
            Dictionary<string, IVehicle> vehicles = new Dictionary<string, IVehicle>();
            vehicles.Add("car", new Car());
            vehicles.Add("boat", new Boat());
            
            StartAllVehicles(vehicles);

        }
        public void StartAllVehicles(Dictionary<string, IVehicle> vehicles)
        {

            {
                foreach (var pair in vehicles)
                {
                    Console.Write($"Starting {pair.Key}: ");
                    pair.Value.Start();
                }
            }
        }
   
    }
}




