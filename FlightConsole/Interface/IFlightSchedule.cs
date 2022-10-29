using System;
using System.Collections.Generic;
using System.Text;

namespace FlightConsole.Interface
{
    public interface IFlightSchedule
    {
         List<Flights> GetSchedules();
         List<Orders> GetOrders();
    }
}
