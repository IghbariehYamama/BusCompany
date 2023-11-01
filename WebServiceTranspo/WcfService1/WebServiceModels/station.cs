using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace WcfService1.Models
{
    public class station
    {
        public string station_ID { set; get; }
        public string station_location { set; get; }
        public string station_name { set; get; }
        public string station_photo { set; get; }
                  
        public static List<station> GetByLocation(string str)
        {
            List<station> lst = new List<station>();
            string sql = "SELECT * FROM Stations where station_location like '%" + str + "%'";
            Connector cn = new Connector("C:\\Users\\yamama\\Desktop\\projects\\TranspoFinal2\\TranspoFinal2\\data\\FINALPROJECT.accdb");
            OleDbDataReader result = cn.RunSelect(sql);
            station c;

            while (result.Read())
            {
              
                c = new station { station_ID = result["station_ID"].ToString(), station_name = result["station_name"].ToString(), station_location = result["station_location"].ToString(), station_photo = result["station_photo"].ToString() };
                lst.Add(c);
            }
            cn.CloseConnection();
            return lst;
        }
               
    }

}
