using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using WcfService1.Models;
using WcfService1.WebServiceModels;

namespace WcfService1
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        [WebMethod]
        public List<Attraction> AttractionsNearStations(station st)
        {
            List<Attraction> list = Attraction.GetAll(st.station_location);
            return list;
        }

        [WebMethod]
        public List<station> StationsNearAttractions(Attraction at)
        {
            List<station> stations = station.GetByLocation(at.attraction_location);
            return stations;
        }

        [WebMethod]
        public bool CoolOrNot()
        {
            bool[] list = new bool[2];
            list[0] = true;
            list[1] = false;

            Random rnd = new Random();
            int i = rnd.Next(0, 2);
            return list[i];
        }

        [WebMethod]
        public void DeleteAttraction(string str)
        {
            Attraction.DeleteByAttractionID(str);
        }

        [WebMethod]
        public List<Attraction> SearchAttraction(string str)
        {
            List<Attraction> st = Attraction.GetByAttraction_name(str);

                st = Attraction.GetByAttraction_name(str);
                  
            return st;
        }
    }
}
