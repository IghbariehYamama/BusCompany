using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TranspoFinal2.Models;

namespace TranspoFinal2.Controllers
{
    public class RouteController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.l1 = route.GetAll(null);
            ViewBag.l2 = 1;
            return View("all_buses");
        }


        public IActionResult ViewAddBus(route st)
        {
            return View("AddBus");
        }


        [HttpPost]
        public IActionResult AddBus(route st)
        {
            st.capacity = 15;
            route.Add(st);
            return View("AddTicketInfo");
        }


       [HttpPost]
        public IActionResult AddTicketInfo(Ticket tick)
        {
            int x = route.LastAddedRoute();
            route rt = route.GetBytheID(x);
            tick.route_ID = rt.route_ID;
            Ticket.Add(tick);
            ViewBag.l2 = 1;
            ViewBag.l3 = new List<StationRoute>();
            ViewBag.ticket = tick.price;

            return View("BusInfo2", rt);
        }

        [Authorize(Roles = "Manager")]
        public IActionResult ViewEditTicketInfo(route rt)
        {
            Ticket tick = Ticket.GetByRouteID(rt.route_ID);
            return View("EditTicketInfo", tick);
        }

        [Authorize(Roles = "Manager")]
        public IActionResult EditTicketInfo(Ticket tick)
        {
            tick.the_ID = Ticket.GetByRouteID(tick.route_ID).the_ID;
            Ticket.Edit(tick);
            route st = route.GetByID(tick.route_ID)[0];
            ViewBag.l2 = 1;
            st.stations = station.GetAllOrByName(null);
            ViewBag.l1 = st.stations;
            int min = 0;
            StationRoute test = new StationRoute();
            List<StationRoute> list = StationRoute.GetAllOrByRouteID(st.route_ID);
            List<StationRoute> sort = new List<StationRoute>();

            //to sort stations according to hours-from min to max
            while (list.Count != 0)
            {
                min = 0;
                test = list[0];
                for (int i = 1; i < list.Count; i++)
                {
                    if (int.Parse(test.each_hours.Substring(0, 2)) > int.Parse(list[i].each_hours.Substring(0, 2)))
                    {
                        min = i;
                        test = list[i];
                    }
                    if (int.Parse(test.each_hours.Substring(0, 2)) == int.Parse(list[i].each_hours.Substring(0, 2)))
                    {
                        if (int.Parse(test.each_hours.Substring(3, 2)) > int.Parse(list[i].each_hours.Substring(3, 2)))
                        {
                            min = i;
                            test = list[i];
                        }

                    }
                }
                sort.Add(test);
                list.RemoveAt(min);

            }


            ViewBag.ticket = Ticket.GetByRouteID(st.route_ID).price;

            ViewBag.l3 = sort;
            return View("BusInfo2", st);
        }


        [HttpPost]
        public IActionResult SearchBus(route st)
        {
            if (route.GetAll(st.route_name).Count==0)
                ViewBag.l1 = route.GetByID(st.route_name);
            else
                ViewBag.l1 = route.GetAll(st.route_name);

            ViewBag.l2 = 1;
                return View("all_buses");
        }

   

        public IActionResult ViewEditBus(route st)
        {
            return View("EditBus", st);
        }

        [HttpPost]
        public IActionResult EditBus(route st)
        {
            route test = route.GetBytheID(st.the_ID);
            List<StationRoute> list = StationRoute.GetAllOrByRouteID(test.route_ID);
            List<Bus_Seats> seats = Bus_Seats.GetByRouteID(test.route_ID);
            List<Transactions> tr = Transactions.GetByRouteID(test.route_ID);
            Ticket tick = Ticket.GetByRouteID(test.route_ID);
            route.Edit(st);
            Ticket.Edit(tick);
            for(int i=0; i<list.Count; i++)
            {
                list[i].route_ID = st.route_ID;
                StationRoute.Edit(list[i]);
            }
            for (int i = 0; i < tr.Count; i++)
            {
                tr[i].route_ID = st.route_ID;
                Transactions.Edit(tr[i]);
            }
            for (int i = 0; i < seats.Count; i++)
            {
                seats[i].route_ID = st.route_ID;
                Bus_Seats.Edit(seats[i]);
            }
            ViewBag.l2 = 1;
            ViewBag.l1 = st.stations;
            ViewBag.l3 = StationRoute.GetAllOrByRouteID(st.route_ID);
            ViewBag.ticket = Ticket.GetByRouteID(st.route_ID).price;

            return View("BusInfo2", st);
        }


        public IActionResult DeleteBus(route st)
        {
            route.DeleteByID(st.route_ID);
            StationRoute.DeleteByRouteID(st.route_ID);
            ViewBag.l1 = route.GetAll(null);
            ViewBag.l2 = 1;
            return View("all_buses");
        }


        public IActionResult BusInfo(route st)
        {
            ViewBag.l2 = 1;
            st.stations=station.GetAllOrByName(null);
            ViewBag.l1 = st.stations;
            int min=0;
            StationRoute test = new StationRoute();
            List<StationRoute> list = StationRoute.GetAllOrByRouteID(st.route_ID);
            List<StationRoute> sort = new List<StationRoute>();

            //to sort stations according to hours-from min to max
            while (list.Count!=0)
            {
                min = 0;
                test = list[0];
                for (int i = 1; i < list.Count; i++)
                {
                    if (int.Parse(test.each_hours.Substring(0, 2)) > int.Parse(list[i].each_hours.Substring(0, 2)))
                    {
                        min = i;
                        test = list[i];
                    }
                    if (int.Parse(test.each_hours.Substring(0, 2)) == int.Parse(list[i].each_hours.Substring(0, 2)))
                    {
                        if (int.Parse(test.each_hours.Substring(3, 2)) > int.Parse(list[i].each_hours.Substring(3, 2)))
                        {
                            min = i;
                            test = list[i];
                        }

                    }
                }
                sort.Add(test);
                list.RemoveAt(min);

            }


            ViewBag.ticket = Ticket.GetByRouteID(st.route_ID).price;
            ViewBag.l3 = sort;
            return View("BusInfo2",st);
        }


        [HttpPost]
        public IActionResult SearchStationInRoute(route st)
        {
            if (station.GetAllOrByName(st.stations[0].station_name).Count == 0)
                ViewBag.l1 = station.GetByID(st.stations[0].station_name);
            else
                ViewBag.l1 = station.GetAllOrByName(st.stations[0].station_name);

            ViewBag.l2 = 1;
            return View("AddStationsToBus", st);
        }


        public ActionResult ChooseStation(string route_ID)
        {
            route st = route.GetByID(route_ID)[0];
            st.stations = station.GetAllOrByName(null);
            List<StationRoute> l3 = StationRoute.GetAllOrByRouteID(st.route_ID);
            for(int i=0; i<st.stations.Count; i++)
            {
                for (int j = 0; j < l3.Count; j++)
                    if (st.stations[i].station_ID.CompareTo(l3[j].station_ID) == 0)
                        st.stations[i].check = true;
                       
            }

            ViewBag.l2 = 1;
            return View("AddStationsToBus", st);
        }


        [HttpPost]
        public ActionResult ChooseHour(route st)
        {
            //List<StationRoute> l1 = StationRoute.GetAll(st.route_ID);
            List<station> list = new List<station>();
            List<StationRoute> list2 = StationRoute.GetAllOrByRouteID(st.route_ID);
            List<StationRoute> list3 = new List<StationRoute>();


          //  StationRoute.DeleteByRouteID(st.route_ID);

            for(int i=0; i<st.stations.Count; i++)
            {
                if(st.stations[i].check==true)
                {
                    /*if (l1.Count != 0)
                    {
                        int j = 0;
                        while ((j < l1.Count) & (l1[j].station_ID.CompareTo(st.stations[i].station_ID) != 0))
                            j++;
                        if (j == l1.Count)
                            list.Add(st.stations[i]);


                    }
                    else*/

                    /*<input type="checkbox" name="room_ids[]" value="@room.room_ID"/> @room.room_name*/
                        list.Add(st.stations[i]);
                }
            }

            for (int i = 0; i < list.Count; i++)
                list3.Add(new StationRoute { station_ID = list[i].station_ID, route_ID = st.route_ID });

            for (int i = 0; i < list2.Count; i++)
                for (int j = 0; j < list3.Count; j++)
                    if (list2[i].station_ID.CompareTo(list3[j].station_ID) == 0)
                    {
                        list2[i].hour = list2[i].each_hours.Substring(0, 2);

                        list2[i].minute = list2[i].each_hours.Substring(3, 2);

                        list3[j] = list2[i];
                    }
           /* for(int i=0; i<list.Count;i++)
            {
                for (int j = 0; j < list2.Count; j++)
                    if (list[i].station_ID.CompareTo(list2[j].station_ID) == 0)
                        list3.Add(list2[j]);
            }*/
          
          /*  for(int i=0; i<list.Count; i++)
                list3.Add(new StationRoute { station_ID=list[i].station_ID, route_ID=st.route_ID});*/
            ViewBag.l3 = list;
            ViewBag.l2 = 1;
            return View("AddHoursToStation", list3);
        }


        [HttpPost]
        public IActionResult BusInfoAfter(List<StationRoute> st)
        {
            ViewBag.l2 = 1;
            route x = route.GetByID(st[0].route_ID)[0];
            x.stations = station.GetAllOrByName(null);
            int h = 0;

            StationRoute.DeleteByRouteID(x.route_ID);

            while (h < st.Count)
            {
                if (st[h].hour.CompareTo("HH") == 0)
                    st[h].hour = "00";
                if (st[h].minute.CompareTo("MM") == 0)
                    st[h].minute = "00";
                StationRoute.Add(st[h]);
                h++;
            }

            

            for (int j = 0; j < x.stations.Count; j++)
            {
                for(int d=0; d<st.Count;d++)
                {
                    if (st[d].station_ID.CompareTo(x.stations[j].station_ID) == 0)
                        x.stations[j].check = true;
                }
            }

            List<StationRoute> list = StationRoute.GetAllOrByRouteID(x.route_ID);
            List<StationRoute> sort = new List<StationRoute>();
            int min = 0;
            StationRoute test = new StationRoute();

            while (list.Count != 0)
            {
                min = 0;
                test = list[0];
                for (int i = 1; i < list.Count; i++)
                {
                    if (int.Parse(test.each_hours.Substring(0, 2)) > int.Parse(list[i].each_hours.Substring(0, 2)))
                    {
                        min = i;
                        test = list[i];
                    }
                    if (int.Parse(test.each_hours.Substring(0, 2)) == int.Parse(list[i].each_hours.Substring(0, 2)))
                    {
                        if (int.Parse(test.each_hours.Substring(3, 2)) > int.Parse(list[i].each_hours.Substring(3, 2)))
                        {
                            min = i;
                            test = list[i];
                        }

                    }
                }

                sort.Add(test);
                list.RemoveAt(min);

            }
            ViewBag.l1 = x.stations;
            ViewBag.l3 = sort;
            ViewBag.ticket = Ticket.GetByRouteID(x.route_ID).price;

            return View("BusInfo2",x);
        }


        public ActionResult DeleteStationFromRoute(int the_ID)
        {
            StationRoute x = StationRoute.GetByTheID(the_ID)[0];
            route st = route.GetByID(x.route_ID)[0];
            st.stations = station.GetAllOrByName(null);
            StationRoute.Delete(the_ID);
            ViewBag.l2 = 1;
            ViewBag.l1 = st.stations;
            ViewBag.l3 = StationRoute.GetAllOrByRouteID(st.route_ID);
            ViewBag.ticket = Ticket.GetByRouteID(st.route_ID).price;

            return View("BusInfo2", st);
        }


        public ActionResult ViewEditStationRoute(int the_ID)
        {
            StationRoute st= StationRoute.GetByTheID(the_ID)[0];
            st.hour = st.each_hours.Substring(0, 2);
            st.minute = st.each_hours.Substring(3, 2);

            ViewBag.l3 = station.GetAllOrByName(null);
            ViewBag.l2 = 1;
            return View("EditStationHour", st);
        }


        public ActionResult EditStationRouteAfter(StationRoute st)
        {
            if (st.hour.CompareTo("HH") == 0)
                st.hour = "00";
            if (st.minute.CompareTo("MM") == 0)
                st.minute = "00";
            StationRoute.Edit(st);
            route x = route.GetByID(st.route_ID)[0];
            x.stations = station.GetAllOrByName(null);
           
            for (int j = 0; j < x.stations.Count; j++)
            {
                    if (st.station_ID.CompareTo(x.stations[j].station_ID) == 0)
                        x.stations[j].check = true;
                
            }


            ViewBag.l3 = StationRoute.GetAllOrByRouteID(st.route_ID);
            ViewBag.l2 = 1;
            ViewBag.l1 = x.stations;
            ViewBag.ticket = Ticket.GetByRouteID(st.route_ID).price;

            return View("BusInfo2", x);


       
        }

    }
}