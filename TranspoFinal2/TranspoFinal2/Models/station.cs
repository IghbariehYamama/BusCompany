using TranspoFinal2.Models;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace TranspoFinal2.Models
{
    public class station
    {
        public int the_ID { set; get; }
        public string station_ID { set; get; }
        public string station_location { set; get; }
        public string station_name { set; get; }
        public string station_photo { set; get; }
        public IFormFile file1 { set; get; }
        public bool check { set; get; }
        
        public static List<station> GetAllOrByName(string str)
        {
            List<station> lst = new List<station>();
            string sql = "SELECT * FROM Stations";
            if (str != null)
                sql += " where station_name like '%" + str + "%'";
            Connector cn = new Connector("data/FINALPROJECT.accdb");
            OleDbDataReader result = cn.RunSelect(sql);
            station c;

            while (result.Read())
            {
                //Console.WriteLine(result[0].ToString());
                //Console.WriteLine(result["client_ID"].ToString());
                //string r = result["client_ID"].ToString();

                c = new station { station_ID = result["station_ID"].ToString(), station_name = result["station_name"].ToString(), station_location = result["station_location"].ToString(), station_photo = result["station_photo"].ToString(), the_ID = int.Parse(result["the_ID"].ToString()) };
                lst.Add(c);
            }
            cn.CloseConnection();
            return lst;
        }
        
        public static List<station> GetByID(string str)
        {
            List<station> lst = new List<station>();
            string sql = "SELECT * FROM Stations where station_ID like '%" + str + "%'";
            Connector cn = new Connector("data/FINALPROJECT.accdb");
            OleDbDataReader result = cn.RunSelect(sql);
            station c;

            while (result.Read())
            {
                //Console.WriteLine(result[0].ToString());
                //Console.WriteLine(result["client_ID"].ToString());
                //string r = result["client_ID"].ToString();

                c = new station { station_ID = result["station_ID"].ToString(), station_name = result["station_name"].ToString(), station_location = result["station_location"].ToString(), station_photo = result["station_photo"].ToString(), the_ID=int.Parse(result["the_ID"].ToString())};
                lst.Add(c);
            }
            cn.CloseConnection();
            return lst;
        }

        public static List<station> GetByTheID(string str)
        {
            List<station> lst = new List<station>();
            string sql = "SELECT * FROM Stations";
            if (str != null)
                sql += " where the_ID=" + str;
            Connector cn = new Connector("data/FINALPROJECT.accdb");
            OleDbDataReader result = cn.RunSelect(sql);
            station c;

            while (result.Read())
            {
                //Console.WriteLine(result[0].ToString());
                //Console.WriteLine(result["client_ID"].ToString());
                //string r = result["client_ID"].ToString();

                c = new station { station_ID = result["station_ID"].ToString(), station_name = result["station_name"].ToString(), station_location = result["station_location"].ToString(), station_photo = result["station_photo"].ToString(), the_ID = int.Parse(result["the_ID"].ToString()) };
                lst.Add(c);
            }
            cn.CloseConnection();
            return lst;
        }

        [Authorize(Roles = "Manager")]
        public static bool DeleteByID(string station_ID)
        {
            string sql = "delete from Stations where station_ID='" + station_ID + "'";
            Connector cn = new Connector("data/FINALPROJECT.accdb");
            int result = cn.RunUpdateInsertDelete(sql);
            return result > 0;
        }

        [Authorize(Roles = "Manager")]
        public static bool Edit(station st)
        {
            string sql = "update Stations set station_location='" + st.station_location + "', station_name='" + st.station_name + "', station_photo='"+st.station_photo+"', station_ID='"+st.station_ID+"' where the_ID=" + st.the_ID;
            Connector cn = new Connector("data/FINALPROJECT.accdb");
            int result = cn.RunUpdateInsertDelete(sql);
            return result > 0;
        }

        [Authorize(Roles = "Manager")]
        public static bool Add(station st)
        {
            string sql = "insert into Stations (station_ID, station_name, station_location, station_photo) values ('" + st.station_ID + "', '" + st.station_name + "', '" + st.station_location + "', '"+st.station_photo+"')";
            Connector cn = new Connector("data/FINALPROJECT.accdb");
            int result = cn.RunUpdateInsertDelete(sql);
            return result > 0;
        }

        [Authorize(Roles = "Manager")]
        public static List<route> BusesPassingBy(station st)
        {
            List<StationRoute> lists = StationRoute.GetByStationID(st.station_ID);
            List<route> buses = new List<route>();
            route rt;
            for(int i=0; i<lists.Count; i++)
            {
                rt = route.GetByID(lists[i].route_ID)[0];
                buses.Add(rt);
            }

            return buses;
        }

    }
  
}
