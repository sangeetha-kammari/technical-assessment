using FlightConsole.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FlightConsole
{
    public class Program
    {
        private readonly IFlightSchedule _flightSchedule;
        
        public Program():this(new FlightSchedule())
        {

        }
        public Program(IFlightSchedule flightSchedule) {

            _flightSchedule = flightSchedule;
        }
        
        public static void Main(string[] args)
        {
            Program p = new Program();
            p.getFlightSchedulesAndOrders();
        }

        public void getFlightSchedulesAndOrders()
        {
            List<Flights> flights = _flightSchedule.GetSchedules();
            List<Orders> orders = _flightSchedule.GetOrders();

            Console.WriteLine("\n=================== UserStory1 ==========================\n");
            foreach (var item in flights)
            {
                Console.WriteLine("Flight: {0}, departure: {1}, arrival: {2}, day: {3}", item.FlightNumber, item.Destination, item.Arraival, item.Day);

            }
            Console.WriteLine("\n=================== UserStory2 ==========================\n");
            foreach (var item in flights)
            {

                foreach (var ord in orders.OrderBy(x => x.OrderNumber))
                {
                    if (flights.Select(x => x.Arraival).Contains(ord.Destination))
                    {
                        Console.WriteLine("Order: {0}, Flight: {1}, departure: {2}, arrival: {3}, day: {4}", ord.OrderNumber, item.FlightNumber, item.Destination, item.Arraival, item.Day);
                    }
                    else
                    {
                        Console.WriteLine("Order: {0}, Flight: {1}", ord.OrderNumber, "Not Scheduled");

                    }
                }
            }

            Console.ReadLine();
        }
    }
}
