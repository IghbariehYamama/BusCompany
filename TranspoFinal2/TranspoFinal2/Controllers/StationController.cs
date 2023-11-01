using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TranspoFinal2.Models;

namespace TranspoFinal2.Controllers
{
    public class StationController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.l1 = station.GetAllOrByName(null);
            ViewBag.l2 = 1;
            return View("all_stations");
        }
        
        [HttpPost]
        public IActionResult SearchStation(station st)
        {
            if (station.GetAllOrByName(st.station_name).Count == 0)
                ViewBag.l1 =station.GetByID(st.station_name);
            else
                ViewBag.l1 = station.GetAllOrByName(st.station_name);

            ViewBag.l2 = 1;
            return View("all_stations");
        }
        
        public IActionResult DeleteStation(string station_ID)
        {
            station.DeleteByID(station_ID);
            ViewBag.l1 = station.GetAllOrByName(null);
            ViewBag.l2 = 1;
            return View("all_stations");
        }
        
        public IActionResult ViewAddStation()
        {
            return View("AddStation");
        }
        
        [HttpPost]
        public IActionResult AddStation(station st)
        {
            if (st.file1 != null)
            {
                Task<string> location = UploadPhoto(st.file1, "StationsPhotos");
                st.station_photo = location.Result;
            }
            else
                st.station_photo = "a1.jpg";//if there's no photo take general photo
            station.Add(st);
            ViewBag.l1 = station.GetAllOrByName(null);
            ViewBag.l2 = 1;
            return View("all_stations");
        }
        
        public IActionResult StationInfo(station st)
        {
            List<route> buses = station.BusesPassingBy(st);

            List<Ticket> tickets = new List<Ticket>();
            for (int i = 0; i < buses.Count; i++)
                tickets.Add(Ticket.GetByRouteID(buses[i].route_ID));//to get ticket price

            List<StationRoute> hours = new List<StationRoute>();

            for (int i = 0; i < buses.Count; i++)
                hours.Add(StationRoute.StationRouteForThisStationAndThisRoute(buses[i].route_ID, st.station_ID)[0]);//to get the time that thue bus passes by

            ViewBag.hours = hours;
            ViewBag.buses = buses;
            ViewBag.l1 = 1;
            ViewBag.tickets = tickets;
            return View(st);
        }
        
        public IActionResult ViewEditStation(station st)
        {
            return View("EditStation", st);
        }
        
        [HttpPost]
        public IActionResult EditStation(station st)
        {
            if (st.file1 != null)
            {
                Task<string> location = UploadPhoto(st.file1, "StationsPhotos");
                st.station_photo = location.Result;
            }
            station pa = station.GetByTheID(st.the_ID.ToString())[0];
            List<StationRoute> pass = StationRoute.GetByStationID(pa.station_ID);
            station.Edit(st);
            for(int i=0; i<pass.Count;i++)
            {
                pass[i].station_ID = st.station_ID;
                StationRoute.Edit(pass[i]);
            }
            return RedirectToAction("StationInfo", "Station", st);
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

        public async Task<IActionResult> AttractionsNearStation(station st)
        {
            ServiceReference1.Attraction[] list = await WebSModels.AttractionsNearStationsAsync(st);
            ViewBag.l1 = list;
            ViewBag.l2 = 1;
            return View("AllAttractions");
        }
        
        public async Task<IActionResult> AttractionInfo(ServiceReference1.Attraction at)
        {
            ServiceReference1.ArrayOfStation list = await WebSModels.StationsNearAttractionsAsync(at);
            ViewBag.l1 = list;
            ViewBag.l2 = 1;

            return View("ThisAttractionInfo", at);
        }

        [HttpPost]
        public async Task<IActionResult> SearchAttractionAsync(ServiceReference1.Attraction st)
        {
            ServiceReference1.Attraction[] list = await WebSModels.SearchAttractionAsync(st.attraction_name);
            ViewBag.l1 = list;
            ViewBag.l2 = 1;
            return View("AllAttractions");
        }
        
    }
}