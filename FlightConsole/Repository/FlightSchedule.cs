using FlightConsole.Interface;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace FlightConsole
{
    public class FlightSchedule: IFlightSchedule
    {
        public List<Flights> GetSchedules()
        {
            List<Flights> flights = new List<Flights>();
            Regex regex = new Regex(@"\(([^()]+)\)*");
            int day = 0;

            //Statically adding the Schedules
            /*
            List < Flights > flights = new List<Flights>
            {
                new Flights { Day = 1, FlightNumber = 1, Arraival = "YUL",Destination="YYZ" },
                new Flights { Day = 1, FlightNumber = 2, Arraival = "YUL",Destination="YYC" },
                new Flights { Day = 1, FlightNumber = 3, Arraival = "YUL",Destination="YVR" },
                new Flights { Day = 2, FlightNumber = 4, Arraival = "YUL",Destination="YYZ" },
                new Flights { Day = 2, FlightNumber = 5, Arraival = "YUL",Destination="YYC" },
                new Flights { Day = 2, FlightNumber = 6, Arraival = "YUL",Destination="YVR" }
            };
            return flights;
            */

            string[] lines = System.IO.File.ReadAllLines(Directory.GetCurrentDirectory().Replace("\\bin\\Debug\\netcoreapp3.1", "")
                                                            + "\\FlightScheduleFlies\\TransportLY_FilghtSchedules.txt");
            
            foreach (string line in lines)
            {
                if (!string.IsNullOrEmpty(line))
                {
                    Flights flight = new Flights();
                    if (line.Contains("Day"))
                    {
                        day = Convert.ToInt32(line.Split(" ")[1].Split(":")[0]);
                    }
                    else
                    {
                        flight.Day = day;
                        flight.FlightNumber = Convert.ToInt32(line.Split(":")[0].Split(" ")[1]);
                        flight.Destination = regex.Match(line.Split(":")[1].Split(")")[0]).Groups[1].Value.ToString();
                        flight.Arraival = regex.Match(line.Split(":")[1].Split(")")[1]).Groups[1].Value.ToString();
                        flights.Add(flight);
                    }
                }
                
            }
            return flights;
           
        }
        public List<Orders> GetOrders()
        {
            
            List<Orders> orders = new List<Orders>();
            using (System.IO.StreamReader sr = new System.IO.StreamReader(Directory.GetCurrentDirectory().Replace("\\bin\\Debug\\netcoreapp3.1", "")
                                                            + "\\FlightScheduleFlies\\coding-assigment-orders.json"))
            {
                string json = sr.ReadToEnd();
                var ls=JsonConvert.DeserializeObject<Dictionary<string, Orders>>(json);
                orders=ls.Select(x => new Orders { OrderNumber=x.Key,Destination=x.Value.Destination}).ToList<Orders>();
               
                return orders;
            }  
            
        }
    }
}
