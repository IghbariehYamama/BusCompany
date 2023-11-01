using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TranspoFinal2.Models;

namespace TranspoFinal2.Controllers
{
    public class PassengerController : Controller
    {
        public IActionResult Index()
        {
            if(User.IsInRole("Passenger") || User.IsInRole("Manager"))
            {
                Passenger st = Passenger.GetAllOrByPassID(User.Identity.Name)[0];
                ViewBag.name = st.pass_name;
            }//to display the user's name on the welcome page
            return View("WelcomePage");
        }
        
        public IActionResult ViewLogin()
        {
            return View("Login");
        }
                
        public IActionResult ViewRegister(route st)
        {
           //this function receives a parameter because the button in the bus info page works by a form that return a route parameter(פרמטר זבל)  
            return View("Register");
        }

        public IActionResult ViewAddCardInfo(Passenger st)
        {
            List<Passenger> all = Passenger.GetAllOrByPassID(null);
            for (int i = 0; i < all.Count; i++)
                if (all[i].pass_ID.CompareTo(st.pass_ID) == 0)
                {
                    st.pass_ID = null;
                    return RedirectToAction("ViewRejectedByID", st);//if there's somebody with the same id do not accept registeration
                }

            if (st.file1 != null)
            {
                Task<string> location = UploadPhoto(st.file1, "UsersPhotos");
                st.pass_photo = location.Result;
            }
            else
            {
                st.pass_photo = "UserGeneral.png";//if the user didn't upload photo take the default photo
            }
            st.pass_birthday = st.brth.ToShortDateString();
            st.pass_active = true;//logged in so he's active (update it)
            st.pass_last_update_profile = DateTime.Now.ToShortDateString();
            Passenger.Add(st);

            return View("AddCardInfo");
        }

        [HttpPost]
        public IActionResult ChooseBus(Ticket place)
        {
            List<route> buses = route.GetAll(null);//to get all the buses
            List<route> help = new List<route>();//to save the requested buses in it

            List<StationRoute> StationTime=new List<StationRoute>();//to save the time that the bus passes by the station (if it is one of the requested) by saving the route


            List<StationRoute> help2;//to get stations from each bus route -by bus id then station id then add to list 
            int count1 = 0, count2=0;

            for (int i = 0; i < buses.Count; i++)
            {
                help2 = StationRoute.GetAllOrByRouteID(buses[i].route_ID);//to get this specific bus's stations that it passes by
                List<station> stations = new List<station>();
                for (int j = 0; j < help2.Count; j++)
                    stations.Add(station.GetByID(help2[j].station_ID)[0]);//to get the stations and all of their details 

         
                for (int j=0; j<stations.Count; j++)
                {
                    if (stations[j].station_location == place.from_destination)
                        count1++;
                    if (stations[j].station_location == place.to_destination)
                        count2++;
                }

                //counts to check if the bus passes by both the origin and destination not just one of them

                if (count1 > 0 && count2 > 0)
                {
                    //this process is to check whether the origin station is before the destination station according to time

                    StationRoute origin = new StationRoute();
                    StationRoute destination = new StationRoute();
                  


                    for (int j = 0; j < stations.Count; j++)
                        {
                           
                            if (stations[j].station_location == place.from_destination)
                               origin = StationRoute.GetByStationID(stations[j].station_ID)[0];

                        if (stations[j].station_location == place.to_destination)
                           destination = StationRoute.GetByStationID(stations[j].station_ID)[0];
                         }

                        //after the end of the for

                    //these two ifs is to check if the origin is before the destination according to the time of the bus's arrival at the station

                    if (int.Parse(destination.each_hours.Substring(0, 2)) > int.Parse(origin.each_hours.Substring(0, 2)))
                    {
                        help.Add(buses[i]);
                        StationTime.Add(StationRoute.StationTimeInRouteForTicket(buses[i].route_ID, place.from_destination));

                    }
                    if (int.Parse(destination.each_hours.Substring(0, 2)) == int.Parse(origin.each_hours.Substring(0, 2)))
                    {
                        if (int.Parse(destination.each_hours.Substring(3, 2)) > int.Parse(origin.each_hours.Substring(3, 2)))
                        {
                            help.Add(buses[i]);
                            StationTime.Add(StationRoute.StationTimeInRouteForTicket(buses[i].route_ID, place.from_destination));

                        }

                    }



                    
                }
                count1 = 0;
                count2 = 0;

            }

            //we need to get these buses' tickets
            List<Ticket> tickets = new List<Ticket>();

            for(int i=0; i<help.Count; i++)
            {
                tickets.Add(Ticket.GetByRouteID(help[i].route_ID));
            }

            //to get the stations so we can view their names for the user
            List<station> stations2 = new List<station>();
            for(int i=0; i<StationTime.Count; i++ )
                stations2.Add(station.GetByID(StationTime[i].station_ID)[0]);


            ViewBag.stations = stations2;
            ViewBag.l2 = 1;
            ViewBag.l1 = StationTime;
           

            if(User.IsInRole("Passenger") || User.IsInRole("Manager"))
            {
                ViewBag.money = double.Parse(Passenger.GetAllOrByPassID(User.Identity.Name)[0].pass_money);
            }
            return View("RequestedBuses", tickets);
        }

        
        public IActionResult ViewProfile(Passenger st)
        {
            Passenger pass = new Passenger();
            if (st.the_ID == 0)
            {
                pass = Passenger.GetAllOrByPassID(User.Identity.Name)[0];
                ViewBag.card = Credit_Card.GetByPassID(pass.pass_ID)[0];
                ViewBag.transactions = Transactions.GetByPassID(pass.pass_ID);
                ViewBag.deleteuser = false;
            }
            else
            {
                pass = Passenger.GetAllOrByPassID(st.pass_ID)[0];
                ViewBag.card = Credit_Card.GetByPassID(st.pass_ID)[0];
                ViewBag.transactions = Transactions.GetByPassID(st.pass_ID);
                ViewBag.deleteuser = true;
            }
            return View("ProfilePage",pass);


         }


        [HttpPost]
        public IActionResult ViewEditProfile(Passenger pass)
        {
            ViewBag.card = Credit_Card.GetByPassID(pass.pass_ID)[0];
            pass.brth = DateTime.Parse(pass.pass_birthday);
            return View("EditProfilePage", pass);
        }
        
        [HttpPost]
        public IActionResult EditProfile(Passenger pass)
        {
            pass.pass_last_update_profile = DateTime.Now.ToShortDateString();
            if(pass.file1!=null)
            {
                Task<string> location = UploadPhoto(pass.file1, "UsersPhotos");
                pass.pass_photo = location.Result;
            }
            
            Passenger test = Passenger.GetBytheID(pass.the_ID);
            Credit_Card cr = Credit_Card.GetByPassID(test.pass_ID)[0];
            cr.pass_ID = pass.pass_ID;
            List<Transactions> tr = Transactions.GetByPassID(test.pass_ID);
            List<Bus_Seats> seats = Bus_Seats.GetByPassID(test.pass_ID);
            Passenger.Edit(pass);
            for (int i=0; i<tr.Count; i++)
            {
                tr[i].pass_ID = pass.pass_ID;
                Transactions.Edit(tr[i]);
            }
            for (int i = 0; i < seats.Count; i++)
            {
                seats[i].pass_ID = pass.pass_ID;
                Bus_Seats.Edit(seats[i]);
            }
            Credit_Card.Edit(cr);
            ViewBag.card = Credit_Card.GetByPassID(pass.pass_ID)[0];
            ViewBag.transactions = tr;
            ViewBag.deleteuser = false;

            return View("ProfilePage", pass);
        }
        
        public IActionResult ViewRejected(Passenger st)
        {
            return View("Rejected", st);
        }

        public IActionResult ViewRejectedByID(Passenger st)
        {
            return View("RejectedByID", st);
        }


        public IActionResult ViewRegisterAfterRejectedByID(Passenger st)
        {
            return View("Register", st);
        }
        
        public IActionResult ViewLoginAfterRejected(Passenger st)
        {
            return View("Login", st);
        }
             
        [Authorize(Roles = "Manager")]
        public IActionResult GetAllUsers()
        {
            ViewBag.users = Passenger.GetAllOrByPassID(null);
            ViewBag.l2 = 1;
            return View("AllUsers");
        }

        [Authorize(Roles = "Manager")]
        public IActionResult DeleteUser(Passenger st)
        {
            Passenger.DeleteByID(st);
            List<Transactions> list = Transactions.GetByPassID(st.pass_ID);
            for (int i = 0; i < list.Count; i++)
                Transactions.DeleteByID(list[i].the_ID);

            ViewBag.users = Passenger.GetAllOrByPassID(null);
            ViewBag.l2 = 1;
            return View("AllUsers");
        }

        [Authorize(Roles = "Manager")]
        public IActionResult SearchUser(Passenger st)
        {
            if (Passenger.GetAllOrByPassID(st.pass_name).Count == 0)
                ViewBag.users = Passenger.GetByPassName(st.pass_name);
            else
                ViewBag.users = Passenger.GetAllOrByPassID(st.pass_name);
            ViewBag.l2 = 1;
            return View("AllUsers");
        }

        public async Task<IActionResult> DeleteAccountAsync(Passenger st)
        {
            Passenger.DeleteByID(st);
            List<Transactions> list = Transactions.GetByPassID(st.pass_ID);
            for (int i = 0; i < list.Count; i++)
                Transactions.DeleteByID(list[i].the_ID);
            await HttpContext.SignOutAsync();
            return View("WelcomePage");
        }

        private async Task<string> UploadPhoto(IFormFile f1, string folder)
        {
            var baseFolder = "wwwroot";
            var newFileName = DateTime.Now.Ticks.ToString() + "_" + f1.FileName;
            var filepath = baseFolder + "/" + folder + "/" + newFileName;

            using (var stream = new FileStream(filepath, FileMode.Create))
            {
                await f1.CopyToAsync(stream);
            }
            return newFileName;
        }


        public IActionResult Cheap(List<Ticket> tickets)
        {
            double min = 0; int ind = 0;
            List<Ticket> sort = new List<Ticket>();
            while(tickets.Count!=0)
            {
                min = double.Parse(tickets[0].price);
                ind = 0;
                for (int j = 1; j < tickets.Count; j++)
                    if (double.Parse(tickets[j].price) < min)
                    {
                        min = double.Parse(tickets[j].price);
                        ind = j;
                    }
                sort.Add(tickets[ind]);
                tickets.Remove(tickets[ind]);
            }

            List<StationRoute> StationTime = new List<StationRoute>();
            for(int i=0; i<sort.Count;i++)
        
                StationTime.Add(StationRoute.StationTimeInRouteForTicket(sort[i].route_ID, sort[i].from_destination));
          


            //to get the stations so we can view their names for the user
            List<station> stations2 = new List<station>();
            for (int i = 0; i < StationTime.Count; i++)
                stations2.Add(station.GetByID(StationTime[i].station_ID)[0]);


            ViewBag.stations = stations2;
            ViewBag.l2 = 1;
            ViewBag.l1 = StationTime;


            if (User.IsInRole("Passenger") || User.IsInRole("Manager"))
            {
                ViewBag.money = double.Parse(Passenger.GetAllOrByPassID(User.Identity.Name)[0].pass_money);
            }

            return View("RequestedBuses", sort);
        }

        public IActionResult Short(List<Ticket> tickets)
        {
            int min = 0, ind = 0;
            List<Ticket> sort = new List<Ticket>();
            while (tickets.Count != 0)
            {
                min = tickets[0].time;
                ind = 0;
                for (int j = 1; j < tickets.Count; j++)
                    if (tickets[j].time < min)
                    {
                        min = tickets[j].time;
                        ind = j;
                    }
                sort.Add(tickets[ind]);
                tickets.Remove(tickets[ind]);
            }

            List<StationRoute> StationTime = new List<StationRoute>();
            for (int i = 0; i < sort.Count; i++)

                StationTime.Add(StationRoute.StationTimeInRouteForTicket(sort[i].route_ID, sort[i].from_destination));



            //to get the stations so we can view their names for the user
            List<station> stations2 = new List<station>();
            for (int i = 0; i < StationTime.Count; i++)
                stations2.Add(station.GetByID(StationTime[i].station_ID)[0]);


            ViewBag.stations = stations2;
            ViewBag.l2 = 1;
            ViewBag.l1 = StationTime;


            if (User.IsInRole("Passenger") || User.IsInRole("Manager"))
            {
                ViewBag.money = double.Parse(Passenger.GetAllOrByPassID(User.Identity.Name)[0].pass_money);
            }

            return View("RequestedBuses", sort);
        }

        public IActionResult CheapAndShort(List<Ticket> tickets)
        {
            double min = 0; int ind = 0;
            List<Ticket> sort = new List<Ticket>();
            while (tickets.Count != 0)
            {
                min = double.Parse(tickets[0].price) + tickets[0].time;
                ind = 0;
                for (int j = 1; j < tickets.Count; j++)
                    if (double.Parse(tickets[j].price) + tickets[j].time < min)
                    {
                        min = double.Parse(tickets[j].price) + tickets[j].time;
                        ind = j;
                    }
                sort.Add(tickets[ind]);
                tickets.Remove(tickets[ind]);
            }

            List<StationRoute> StationTime = new List<StationRoute>();
            for (int i = 0; i < sort.Count; i++)

                StationTime.Add(StationRoute.StationTimeInRouteForTicket(sort[i].route_ID, sort[i].from_destination));



            //to get the stations so we can view their names for the user
            List<station> stations2 = new List<station>();
            for (int i = 0; i < StationTime.Count; i++)
                stations2.Add(station.GetByID(StationTime[i].station_ID)[0]);


            ViewBag.stations = stations2;
            ViewBag.l2 = 1;
            ViewBag.l1 = StationTime;


            if (User.IsInRole("Passenger") || User.IsInRole("Manager"))
            {
                ViewBag.money = double.Parse(Passenger.GetAllOrByPassID(User.Identity.Name)[0].pass_money);
            }

            return View("RequestedBuses", sort);
        }


    }
}