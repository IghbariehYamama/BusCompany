using TranspoFinal2.Models;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace TranspoFinal2.Models
{
    public class StationRoute
    {
        public int the_ID { set; get; }
        public string route_ID { set; get; }
        public string station_ID { set; get; }
        public string each_hours { set; get; }
        public string hour { set; get; }
        public string minute { set; get; }

        public static List<StationRoute> GetAllOrByRouteID(string str)
        {
            List<StationRoute> lst = new List<StationRoute>();
            string sql = "SELECT * FROM Route_Stations where route_ID like '%" + str + "%'";
            Connector cn = new Connector("data/FINALPROJECT.accdb");
            OleDbDataReader result = cn.RunSelect(sql);
            StationRoute c;

            while (result.Read())
            {
                //Console.WriteLine(result[0].ToString());
                //Console.WriteLine(result["client_ID"].ToString());
                //string r = result["client_ID"].ToString();

                c = new StationRoute { the_ID = int.Parse(result["the_ID"].ToString()), route_ID = result["route_ID"].ToString(), station_ID = result["station_ID"].ToString(), each_hours = result["each_hours"].ToString() };
                lst.Add(c);
            }
            cn.CloseConnection();
            return lst;
        }
        
        public static List<StationRoute> GetByStationID(string str)
        {
            List<StationRoute> lst = new List<StationRoute>();
            string sql = "SELECT * FROM Route_Stations where station_ID like '%" + str + "%'";
            Connector cn = new Connector("data/FINALPROJECT.accdb");
            OleDbDataReader result = cn.RunSelect(sql);
            StationRoute c;

            while (result.Read())
            {
                //Console.WriteLine(result[0].ToString());
                //Console.WriteLine(result["client_ID"].ToString());
                //string r = result["client_ID"].ToString();

                c = new StationRoute { the_ID = int.Parse(result["the_ID"].ToString()), route_ID = result["route_ID"].ToString(), station_ID = result["station_ID"].ToString(), each_hours = result["each_hours"].ToString() };
                lst.Add(c);
            }
            cn.CloseConnection();
            return lst;
        }

        public static List<StationRoute> GetByTheID(int str)
        {
            List<StationRoute> lst = new List<StationRoute>();
            string sql = "SELECT * FROM Route_Stations where the_ID =" + str ;
            Connector cn = new Connector("data/FINALPROJECT.accdb");
            OleDbDataReader result = cn.RunSelect(sql);
            StationRoute c;

            while (result.Read())
            {
                //Console.WriteLine(result[0].ToString());
                //Console.WriteLine(result["client_ID"].ToString());
                //string r = result["client_ID"].ToString();

                c = new StationRoute { the_ID = int.Parse(result["the_ID"].ToString()), route_ID = result["route_ID"].ToString(), station_ID = result["station_ID"].ToString(), each_hours = result["each_hours"].ToString() };
                lst.Add(c);
            }
            cn.CloseConnection();
            return lst;
        }
        
        [Authorize(Roles = "Manager")]
        public static bool Delete(int the_ID)
        {
            string sql = "delete from Route_Stations where the_ID=" + the_ID;
            Connector cn = new Connector("data/FINALPROJECT.accdb");
            int result = cn.RunUpdateInsertDelete(sql);
            return result > 0;
        }

        [Authorize(Roles = "Manager")]
        public static bool DeleteByRouteID(string route_ID)
        {
            string sql = "delete from Route_Stations where route_ID like '%" + route_ID + "%'";
            Connector cn = new Connector("data/FINALPROJECT.accdb");
            int result = cn.RunUpdateInsertDelete(sql);
            return result > 0;
        }

        [Authorize(Roles = "Manager")]
        public static bool Edit(StationRoute st)
        {
            st.each_hours = st.hour + ":" + st.minute;
            string sql = "update Route_Stations set route_ID='" + st.route_ID + "', station_ID='" + st.station_ID + "', each_hours='" + st.each_hours + "' where the_ID=" + st.the_ID;
            Connector cn = new Connector("data/FINALPROJECT.accdb");
            int result = cn.RunUpdateInsertDelete(sql);
            return result > 0;
        }
               
        [Authorize(Roles = "Manager")]
        public static bool Add(StationRoute st)
        {
            st.each_hours = st.hour +":"+ st.minute;
            string sql = "insert into Route_Stations (route_ID, station_ID, each_hours) values ('" + st.route_ID + "', '" + st.station_ID + "', '"+st.each_hours+"')";
            Connector cn = new Connector("data/FINALPROJECT.accdb");
            int result = cn.RunUpdateInsertDelete(sql);

            return result > 0;
        }

        public static StationRoute StationTimeInRouteForTicket(string ID, string origin)
        {
            List<StationRoute> list = StationRoute.GetAllOrByRouteID(ID);
            List<station> list_stations = new List<station>();

            for (int j = 0; j < list.Count; j++)
                list_stations.Add(station.GetByID(list[j].station_ID)[0]);//to get the stations and all of their details 


            for (int j = 0; j < list_stations.Count; j++)
            {

                if (list_stations[j].station_location == origin)
                    return StationRouteForThisStationAndThisRoute(ID,list_stations[j].station_ID)[0];

            }
            return null;//just to run code
        }
                
        public static List<StationRoute> StationRouteForThisStationAndThisRoute (string route_ID, string station_ID)
        {
            //DOES NOT WOOOOORK EDIIT
            List<StationRoute> lst = new List<StationRoute>();
            string sql = "SELECT * FROM Route_Stations where route_ID like '%" + route_ID + "%' and station_ID like '%"+station_ID+"%'";
            Connector cn = new Connector("data/FINALPROJECT.accdb");
            OleDbDataReader result = cn.RunSelect(sql);
            StationRoute c;

            while (result.Read())
            {
             
                c = new StationRoute { the_ID = int.Parse(result["the_ID"].ToString()), route_ID = result["route_ID"].ToString(), station_ID = result["station_ID"].ToString(), each_hours = result["each_hours"].ToString() };
                lst.Add(c);
            }
            cn.CloseConnection();
            return lst;
        }
    }
}
