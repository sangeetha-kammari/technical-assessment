using System;
using System.Collections.Generic;
using System.Text;

namespace FlightConsole
{
    public class Flights
    {
        public int Day { get; set; }
        public int FlightNumber { get; set; }
        public string Destination { get; set; }
        public string Arraival { get; set; }


    }

    public class Orders
    {
        public string OrderNumber { get; set; }
        public string Destination { get; set; }
    }
   
}
