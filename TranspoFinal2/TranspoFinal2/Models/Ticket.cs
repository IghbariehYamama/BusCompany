using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Threading.Tasks;

namespace TranspoFinal2.Models
{
    public class Ticket
    {
        public int the_ID { set; get; }
        public string route_ID { set; get; }
        public int time{ set; get; }
        public string price { set; get; }
        public string from_destination { set; get; }
        public string to_destination { set; get; }
        
        public static Ticket GetByTheID(int the_ID)
        {
            List<Ticket> lst = new List<Ticket>();
            string sql = "SELECT * FROM Ticket where the_ID=" + the_ID;
            Connector cn = new Connector("data/FINALPROJECT.accdb");
            OleDbDataReader result = cn.RunSelect(sql);
            Ticket c;

            while (result.Read())
            {
               
                c = new Ticket { the_ID = int.Parse(result["the_ID"].ToString()), route_ID = result["route_ID"].ToString(), time = int.Parse(result["tick_time"].ToString()), price = result["tick_price"].ToString(), from_destination= result["from_destination"].ToString() , to_destination= result["to_destination"].ToString() };
                lst.Add(c);
            }
            cn.CloseConnection();
            return lst[0];
        }
            
        public static Ticket GetByRouteID(string str)
        {
            List<Ticket> lst = new List<Ticket>();
            string sql = "SELECT * FROM Ticket where route_ID like '%" + str + "%'";
            Connector cn = new Connector("data/FINALPROJECT.accdb");
            OleDbDataReader result = cn.RunSelect(sql);
            Ticket c;

            while (result.Read())
            {

                c = new Ticket { the_ID = int.Parse(result["the_ID"].ToString()), route_ID = result["route_ID"].ToString(), time = int.Parse(result["tick_time"].ToString()), price =result["tick_price"].ToString(), from_destination = result["from_destination"].ToString(), to_destination = result["to_destination"].ToString() };
                lst.Add(c);
            }
            cn.CloseConnection();
            return lst[0];
        }

        [Authorize(Roles = "Manager")]
        public static bool DeleteByTheID(int the_ID)
        {
            string sql = "delete from Ticket where the_ID=" + the_ID;
            Connector cn = new Connector("data/FINALPROJECT.accdb");
            int result = cn.RunUpdateInsertDelete(sql);
            return result > 0;
        }

        [Authorize(Roles ="Manager")]
        public static bool Edit(Ticket st)
        {
            string sql = "update Ticket set route_ID='" + st.route_ID + "', tick_time=" + st.time + ", tick_price='" + st.price + "', from_destination='" + st.from_destination+"', to_destination='"+st.to_destination+"' where the_ID=" + st.the_ID;
            Connector cn = new Connector("data/FINALPROJECT.accdb");
            int result = cn.RunUpdateInsertDelete(sql);
            return result > 0;
        }

        [Authorize(Roles = "Manager")]
        public static bool Add(Ticket st)
        {
            string sql = "insert into Ticket (route_ID, tick_price, tick_time, from_destination, to_destination) values ('" + st.route_ID + "', '" + st.price + "', " + st.time + ", '"+st.from_destination+"', '"+st.to_destination+"')";
            Connector cn = new Connector("data/FINALPROJECT.accdb");
            int result = cn.RunUpdateInsertDelete(sql);
            return result > 0;
        }
               
    }
}
