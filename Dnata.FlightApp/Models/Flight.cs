using System.Collections.Generic;

namespace Dnata.FlightApp.Models
{
    public class Flight
    {
        public string FlightName { get; set; }

        public IList<Segment> Segments { get; set; }
    }
}
