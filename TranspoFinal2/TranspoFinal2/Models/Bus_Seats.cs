using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Threading.Tasks;

namespace TranspoFinal2.Models
{
    public class Bus_Seats
    {
        public int the_ID { set; get; }
        public string pass_ID { set; get; }
        public string route_ID { set; get; }
        public string seat_num { set; get; }
               
       public static List<Bus_Seats> GetAllOrByTheID(string str)
        {
            List<Bus_Seats> lst = new List<Bus_Seats>();
            string sql = "SELECT * FROM Bus_Seats";
            if (str != null)
                sql += " where the_ID =" + str;
            Connector cn = new Connector("data/FINALPROJECT.accdb");
            OleDbDataReader result = cn.RunSelect(sql);
            Bus_Seats c;

            while (result.Read())
            {
                c = new Bus_Seats { route_ID = result["route_ID"].ToString(), pass_ID = result["pass_ID"].ToString(), seat_num = result["seat_num"].ToString(), the_ID=int.Parse(result[""].ToString()) };
                lst.Add(c);
            }
            cn.CloseConnection();
            return lst;
        }
        
       public static List<Bus_Seats> GetByPassID(string str)
        {
            List<Bus_Seats> lst = new List<Bus_Seats>();
            string sql = "SELECT * FROM Bus_Seats where pass_ID like '%" + str + "%'";
            Connector cn = new Connector("data/FINALPROJECT.accdb");
            OleDbDataReader result = cn.RunSelect(sql);
            Bus_Seats c;

            while (result.Read())
            {

                c = new Bus_Seats { route_ID = result["route_ID"].ToString(), pass_ID = result["pass_ID"].ToString(), seat_num = result["seat_num"].ToString(), the_ID = int.Parse(result["the_ID"].ToString()) };
                lst.Add(c);
            }
            cn.CloseConnection();
                     
            return lst;
        }

        public static List<Bus_Seats> GetByRouteID(string str)
        {
            List<Bus_Seats> lst = new List<Bus_Seats>();
            string sql = "SELECT * FROM Bus_Seats where route_ID like '%" + str + "%'";
            Connector cn = new Connector("data/FINALPROJECT.accdb");
            OleDbDataReader result = cn.RunSelect(sql);
            Bus_Seats c;

            while (result.Read())
            {

                c = new Bus_Seats { route_ID = result["route_ID"].ToString(), pass_ID = result["pass_ID"].ToString(), seat_num = result["seat_num"].ToString(), the_ID = int.Parse(result["the_ID"].ToString()) };
                lst.Add(c);
            }
            cn.CloseConnection();

            //lets add some code after the c is not null
            //that fill the current route with its station
            return lst;
        }

        public static List<Bus_Seats> GetByPassIDAndRouteID(string route_ID, string pass_ID)
        {
            List<Bus_Seats> lst = new List<Bus_Seats>();
            string sql = "SELECT * FROM Bus_Seats where pass_ID like '%" + pass_ID + "%' and route_ID like '%" + route_ID + "%'";
            Connector cn = new Connector("data/FINALPROJECT.accdb");
            OleDbDataReader result = cn.RunSelect(sql);
            Bus_Seats c;

            while (result.Read())
            {

                c = new Bus_Seats { route_ID = result["route_ID"].ToString(), pass_ID = result["pass_ID"].ToString(), seat_num = result["seat_num"].ToString(), the_ID = int.Parse(result["the_ID"].ToString()) };
                lst.Add(c);
            }
            cn.CloseConnection();

            return lst;
        }

        [Authorize(Roles = "Manager")]
        public static bool DeleteByTheID(int the_ID)
        {
            string sql = "delete from Bus_Seats where the_ID=" + the_ID;
            Connector cn = new Connector("data/FINALPROJECT.accdb");
            int result = cn.RunUpdateInsertDelete(sql);
            return result > 0;
        }

        [Authorize(Roles = "Manager")]
        public static bool Edit(Bus_Seats st)
        {

            string sql = "update Bus_Seats set route_ID='" + st.route_ID + "', pass_ID='" + st.pass_ID + "', seat_num='" + st.seat_num + "' where the_ID=" + st.the_ID;
            Connector cn = new Connector("data/FINALPROJECT.accdb");
            int result = cn.RunUpdateInsertDelete(sql);
            return result > 0;
        }

        [Authorize(Roles ="Manager")]
        public static bool Add(Bus_Seats st)
        {
            string sql = "insert into Bus_Seats (route_ID, pass_ID, seat_num) values ('" + st.route_ID + "', '" + st.pass_ID + "', '" + st.seat_num + "')";
            Connector cn = new Connector("data/FINALPROJECT.accdb");
            int result = cn.RunUpdateInsertDelete(sql);
            return result > 0;
        }
    }
}
