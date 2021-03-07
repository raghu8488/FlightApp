using Dnata.FlightApp.Implementation;
using Dnata.FlightApp.Interface;
using Dnata.FlightApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dnata.FlightApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Display List of all flights
            Console.WriteLine("\n");
            Console.WriteLine("1. List of all Flights");

            IFlight iFlight = new FlightManager();

            IList<Flight> flights = iFlight.GetAllFlights();
            iFlight.DisplayFlightData(flights);

            //Display List of Flights departs before arrival
            Console.WriteLine("\n");
            Console.WriteLine("2. List of Flights departs before current date \n");

            flights = iFlight.DepartsBeforeCurrentDate();
            iFlight.DisplayFlightData(flights);

            //Display List of Flights departs before arrival
            Console.WriteLine("\n");
            Console.WriteLine("3.List of Flights departs before arrival \n");

            flights = iFlight.EarlyFlights();
            iFlight.DisplayFlightData(flights);

            //Display flights which are Spended more than 2 hours on the ground 
            Console.WriteLine("\n");
            Console.WriteLine("4.List of Flights Spend more than 2 hours on the ground \n");

            flights = iFlight.GroundedFlights();
            iFlight.DisplayFlightData(flights);

            Console.Read();
        }        
    }
}
