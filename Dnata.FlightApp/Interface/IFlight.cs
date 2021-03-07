using Dnata.FlightApp.Models;
using System.Collections.Generic;

namespace Dnata.FlightApp.Interface
{
    interface IFlight
    {
        //Get All flights
        IList<Flight> GetAllFlights();

        //Get flights which departs before current datetime
        IList<Flight> DepartsBeforeCurrentDate();

        //any segment with an arrival date before the departure date
        IList<Flight> EarlyFlights();

        //Spend more than 2 hours on the ground - overall with all segments
        IList<Flight> GroundedFlights();

        void DisplayFlightData(IList<Flight> flights);
    }
}
