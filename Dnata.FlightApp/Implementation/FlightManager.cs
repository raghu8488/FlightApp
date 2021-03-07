using Dnata.FlightApp.Interface;
using Dnata.FlightApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using TravelRepublic.FlightCodingTest;

namespace Dnata.FlightApp.Implementation
{
    public class FlightManager : IFlight
    {
        public IList<Flight> flights = new List<Flight>();

        /// <summary>
        /// Get flights which departs before current datetime
        /// </summary>
        /// <returns>list of flights</returns>
        public IList<Flight> DepartsBeforeCurrentDate()
        {
            try
            {
                var filteredFlights = new List<Flight>();
                if (flights != null && flights.Count() > 0)
                {
                    filteredFlights = flights.Where(f => f.Segments.Any(s => s.DepartureDate < DateTime.Now)).ToList();
                }
                return filteredFlights;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return null;
            }
        }

        /// <summary>
        /// any segment with an arrival date before the departure date
        /// </summary>
        /// <returns></returns>
        public IList<Flight> EarlyFlights()
        {
            try
            {
                var filteredFlights = new List<Flight>();
                if (flights != null && flights.Count() > 0)
                {
                    filteredFlights = flights.Where(f => f.Segments.Any(s => s.DepartureDate < s.ArrivalDate)).ToList();
                }
                return filteredFlights;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return null;
            }
        }

        /// <summary>
        /// Get all flights
        /// </summary>
        /// <returns></returns>
        public IList<Flight> GetAllFlights()
        {
            try
            {
                FlightBuilder flightBuilder = new FlightBuilder();
                flights = flightBuilder.GetFlights();
                return flights;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return null;
            }
        }

        /// <summary>
        /// Spend more than 2 hours on the ground - overall with all segments
        /// </summary>
        /// <returns></returns>
        public IList<Flight> GroundedFlights()
        {
            try
            {
                var filteredFlights = new List<Flight>();

                if (flights != null && flights.Count() > 0)
                {
                    foreach (var fl in flights)
                    {
                        double totalHours = 0;
                        foreach (var seg in fl.Segments)
                        {
                            totalHours += (seg.DepartureDate - seg.ArrivalDate).TotalHours;
                        }
                        if (totalHours > 2.0)
                        {
                            filteredFlights.Add(fl);
                        }
                    }
                }
                return filteredFlights;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return null;
            }
        }

        public void DisplayFlightData(IList<Flight> flights)
        {
            try
            {
                if (flights == null && flights.Count() == 0)
                {
                    Console.WriteLine("No Record to display");
                }
                Console.WriteLine("|---------------------------------------------------------------------------------------|");
                Console.WriteLine("| FlightName        |        Arrival Time           |            Depart Time            |");
                Console.WriteLine("|---------------------------------------------------------------------------------------|");
                foreach (var flight in flights)
                {
                    foreach (var segment in flight.Segments)
                    {
                        Console.WriteLine(flight.FlightName + "                " + segment.ArrivalDate + "               " + segment.DepartureDate);
                        Console.WriteLine("|------------------------------------------------------------------------------------------|");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());                
            }
        }

    }
}
