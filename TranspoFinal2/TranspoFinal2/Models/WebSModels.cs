using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TranspoFinal2.Models
{
    public class WebSModels
    {
        public static async Task<ServiceReference1.Attraction[]> AttractionsNearStationsAsync(station st)
        {
            //create object that ref to the service
            //then use the ref to call the req method and send any value to it
            //save the result in some var
            ServiceReference1.station tick = new ServiceReference1.station { station_ID = st.station_ID, station_location = st.station_location, station_name = st.station_name, station_photo = st.station_photo };

            ServiceReference1.WebService1SoapClient s1 =
                new ServiceReference1.WebService1SoapClient
                (ServiceReference1.WebService1SoapClient.EndpointConfiguration.WebService1Soap);
            ServiceReference1.AttractionsNearStationsResponse x = await s1.AttractionsNearStationsAsync(tick);
            return x.Body.AttractionsNearStationsResult;

        }

        public static async Task<ServiceReference1.ArrayOfStation> StationsNearAttractionsAsync(ServiceReference1.Attraction at)
        {
            //create object that ref to the service
            //then use the ref to call the req method and send any value to it
            //save the result in some var

            ServiceReference1.WebService1SoapClient s1 =
                new ServiceReference1.WebService1SoapClient
                (ServiceReference1.WebService1SoapClient.EndpointConfiguration.WebService1Soap);
            ServiceReference1.StationsNearAttractionsResponse x = await s1.StationsNearAttractionsAsync(at);
            return x.Body.StationsNearAttractionsResult;

        }

        public static async Task<ServiceReference1.Attraction[]> SearchAttractionAsync(string str)
        {
            //create object that ref to the service
            //then use the ref to call the req method and send any value to it
            //save the result in some var

            ServiceReference1.WebService1SoapClient s1 =
                new ServiceReference1.WebService1SoapClient
                (ServiceReference1.WebService1SoapClient.EndpointConfiguration.WebService1Soap);
            ServiceReference1.SearchAttractionResponse x = await s1.SearchAttractionAsync(str);
            return x.Body.SearchAttractionResult;

        }

    }
}
