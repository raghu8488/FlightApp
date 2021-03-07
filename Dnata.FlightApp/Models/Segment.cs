using System;

namespace Dnata.FlightApp.Models
{
    public class Segment
    {
        public DateTime DepartureDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
    }
}
