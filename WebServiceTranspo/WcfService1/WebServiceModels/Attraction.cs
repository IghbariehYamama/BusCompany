using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using WcfService1.Models;

namespace WcfService1.WebServiceModels
{
    public class Attraction
    {
        public int attraction_ID { set; get; }
        public string attraction_location { set; get; }
        public string attraction_name { set; get; }
        public string attraction_photo { set; get; }
              
        public static List<Attraction> GetAll(string str)
        {
            List<Attraction> lst = new List<Attraction>();
            string sql = "SELECT * FROM Attractions";
            if (str != null)
                sql += " where attraction_location like '%" + str + "%'";
            Connector cn = new Connector("C:\\Users\\yamama\\Desktop\\projects\\WebServiceTranspo\\WcfService1\\App_Data\\WebServiceData.accdb");
            OleDbDataReader result = cn.RunSelect(sql);
            Attraction c;

            while (result.Read())
            {
                c = new Attraction { attraction_ID = int.Parse(result["attraction_ID"].ToString()), attraction_name = result["attraction_name"].ToString(), attraction_location = result["attraction_location"].ToString(), attraction_photo = result["attraction_photo"].ToString()};
                lst.Add(c);
            }
            cn.CloseConnection();
            return lst;
        }

        public static List<Attraction> GetByAttraction_name(string str)
        {
            List<Attraction> lst = new List<Attraction>();
            string sql = "SELECT * FROM Attractions where attraction_name like '%" + str + "%'";
            Connector cn = new Connector("C:\\Users\\yamama\\Desktop\\projects\\WebServiceTranspo\\WcfService1\\App_Data\\WebServiceData.accdb");
            OleDbDataReader result = cn.RunSelect(sql);
            Attraction c;

            while (result.Read())
            {

                c = new Attraction { attraction_ID = int.Parse(result["attraction_ID"].ToString()), attraction_name = result["attraction_name"].ToString(), attraction_location = result["attraction_location"].ToString(), attraction_photo = result["attraction_photo"].ToString() };
                lst.Add(c);
            }
            cn.CloseConnection();
            return lst;
        }

        public static bool DeleteByAttractionID(string attraction_ID)
        {
            string sql = "delete from Attractions where attraction_ID=" + attraction_ID;
            Connector cn = new Connector("C:\\Users\\yamama\\Desktop\\projects\\WebServiceTranspo\\WcfService1\\App_Data\\WebServiceData.accdb");
            int result = cn.RunUpdateInsertDelete(sql);
            return result > 0;
        }

        public static bool Edit (Attraction st)
        {
            string sql = "update Attractions set attraction_location='" + st.attraction_location + "', attraction_name='" + st.attraction_name + "', attraction_photo='" + st.attraction_photo + "' where attraction_ID=" + st.attraction_ID;
            Connector cn = new Connector("C:\\Users\\yamama\\Desktop\\projects\\WebServiceTranspo\\WcfService1\\App_Data\\WebServiceData.accdb");
            int result = cn.RunUpdateInsertDelete(sql);
            return result > 0;
        }

        public static bool Add(Attraction st)
        {
            string sql = "insert into Attractions (attraction_name, attraction_location, attraction_photo) values ('" + st.attraction_name + "', '" + st.attraction_location + "', '" + st.attraction_photo + "')";
            Connector cn = new Connector("C:\\Users\\yamama\\Desktop\\projects\\WebServiceTranspo\\WcfService1\\App_Data\\WebServiceData.accdb");
            int result = cn.RunUpdateInsertDelete(sql);
            return result > 0;
        }

    }
}