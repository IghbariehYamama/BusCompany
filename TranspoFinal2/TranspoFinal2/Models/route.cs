using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Threading.Tasks;

namespace TranspoFinal2.Models
{
    public class route
    {
        public string route_ID { set; get; }
        public string route_name { set; get; }
        public string route_company { set; get; }
        public List<station> stations { set; get; }
        public int capacity { set; get; }
        public int the_ID { set; get; }
        
        public static List<route> GetAll(string str)
        {
            List<route> lst = new List<route>();
            string sql = "SELECT * FROM Route";
            if (str != null)
                sql += " where route_name like '%" + str + "%'";
            Connector cn = new Connector("data/FINALPROJECT.accdb");
            OleDbDataReader result = cn.RunSelect(sql);
            route c;

            while (result.Read())
            {
                //Console.WriteLine(result[0].ToString());
                //Console.WriteLine(result["client_ID"].ToString());
                //string r = result["client_ID"].ToString();

                c = new route { route_ID = result["route_ID"].ToString(), route_name = result["route_name"].ToString(), route_company = result["route_company"].ToString(), capacity=int.Parse(result["capacity"].ToString()), the_ID=int.Parse(result["the_ID"].ToString()) };
                lst.Add(c);
            }
            cn.CloseConnection();
            return lst;
        }
        
        public static List<route> GetByID(string str)
        {
            List<route> lst = new List<route>();
            string sql = "SELECT * FROM Route where route_ID like '%" + str + "%'";
            Connector cn = new Connector("data/FINALPROJECT.accdb");
            OleDbDataReader result = cn.RunSelect(sql);
            route c;

            while (result.Read())
            {
              
                c = new route { route_ID = result["route_ID"].ToString(), route_name = result["route_name"].ToString(), route_company = result["route_company"].ToString(), capacity = int.Parse(result["capacity"].ToString()), the_ID=int.Parse(result["the_ID"].ToString()) };
                lst.Add(c);
            }
            cn.CloseConnection();

            //lets add some code after the c is not null
            //that fill the current route with its station
            return lst;
        }

        public static route GetBytheID(int str)
        {
            string sql = "SELECT * FROM Route where the_ID =" + str;
            Connector cn = new Connector("data/FINALPROJECT.accdb");
            OleDbDataReader result = cn.RunSelect(sql);
            route c=new route();

            while (result.Read())
            {

                c = new route { route_ID = result["route_ID"].ToString(), route_name = result["route_name"].ToString(), route_company = result["route_company"].ToString(), capacity = int.Parse(result["capacity"].ToString()), the_ID = int.Parse(result["the_ID"].ToString()) };
            }
            cn.CloseConnection();

            //lets add some code after the c is not null
            //that fill the current route with its station
            return c;
        }

        [Authorize(Roles ="Manager")]
        public static bool DeleteByID(string route_ID)
        {
            string sql = "delete from Route where route_ID='" + route_ID + "'";
            Connector cn = new Connector("data/FINALPROJECT.accdb");
            int result = cn.RunUpdateInsertDelete(sql);
            return result > 0;
        }

        [Authorize(Roles = "Manager")]
        public static bool Edit(route st)
        {
            //edit function before apply!!!!!!!!!!!!!!!!!!!!!

            string sql = "update Route set route_ID='" + st.route_ID + "', route_name='" + st.route_name + "', route_company='" + st.route_company + "', capacity="+st.capacity+", route_ID='"+st.route_ID+"' where the_ID='" + st.the_ID + "'";
            Connector cn = new Connector("data/FINALPROJECT.accdb");
            int result = cn.RunUpdateInsertDelete(sql);
            return result > 0;
        }

        [Authorize(Roles = "Manager")]
        public static bool Add(route st)
        {
            string sql = "insert into Route (route_ID, route_name, route_company, capacity) values ('" + st.route_ID + "', '" + st.route_name + "', '" + st.route_company + "', "+st.capacity+")";
            Connector cn = new Connector("data/FINALPROJECT.accdb");
            int result = cn.RunUpdateInsertDelete(sql);
            return result > 0;
        }

        public static int LastAddedRoute()
        {
            string sql = "SELECT max (the_ID) from Route";
            Connector cn = new Connector("data/FINALPROJECT.accdb");
            int x = cn.RunScalar(sql);
            return x;
        }
    }
}
