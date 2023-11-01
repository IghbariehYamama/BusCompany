using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Threading.Tasks;

namespace TranspoFinal2.Models
{
    public class Transactions
    {
        public int the_ID { set; get; }
        public string card_ID { set; get; }
        public string pass_ID { set; get; }
        public string route_ID { set; get; }
        public string money_amount { set; get; }
        public string buy_date { set; get; }

         public static List<Transactions> GetAllOrByTheID(string str)
         {
             List<Transactions> lst = new List<Transactions>();
             string sql = "SELECT * FROM Transactions";
             if (str != null)
                 sql += " where the_ID =" + str;
             Connector cn = new Connector("data/FINALPROJECT.accdb");
             OleDbDataReader result = cn.RunSelect(sql);
            Transactions c;

             while (result.Read())
             {
                 //Console.WriteLine(result[0].ToString());
                 //Console.WriteLine(result["client_ID"].ToString());
                 //string r = result["client_ID"].ToString();

                 c = new Transactions { the_ID = int.Parse(result["the_ID"].ToString()), route_ID = result["route_ID"].ToString(), card_ID = result["card_ID"].ToString(), pass_ID = result["pass_ID"].ToString(), buy_date=result["buy_date"].ToString(), money_amount=result["money_amount"].ToString()};
                 lst.Add(c);
             }
             cn.CloseConnection();
             return lst;
         }

         public static List<Transactions> GetByPassID(string str)
         {
             List<Transactions> lst = new List<Transactions>();
             string sql = "SELECT * FROM Transactions where pass_ID like '%" + str + "%'";
             Connector cn = new Connector("data/FINALPROJECT.accdb");
             OleDbDataReader result = cn.RunSelect(sql);
             Transactions c;

             while (result.Read())
             {

                c = new Transactions { the_ID = int.Parse(result["the_ID"].ToString()), route_ID = result["route_ID"].ToString(), card_ID = result["card_ID"].ToString(), pass_ID = result["pass_ID"].ToString(), buy_date = result["buy_date"].ToString(), money_amount = result["money_amount"].ToString() };
                lst.Add(c);
             }
             cn.CloseConnection();

             //lets add some code after the c is not null
             //that fill the current route with its station
             return lst;
         }

        public static List<Transactions> GetByRouteID(string str)
        {
            List<Transactions> lst = new List<Transactions>();
            string sql = "SELECT * FROM Transactions where route_ID like '%" + str + "%'";
            Connector cn = new Connector("data/FINALPROJECT.accdb");
            OleDbDataReader result = cn.RunSelect(sql);
            Transactions c;

            while (result.Read())
            {

                c = new Transactions { the_ID = int.Parse(result["the_ID"].ToString()), route_ID = result["route_ID"].ToString(), card_ID = result["card_ID"].ToString(), pass_ID = result["pass_ID"].ToString(), buy_date = result["buy_date"].ToString(), money_amount = result["money_amount"].ToString() };
                lst.Add(c);
            }
            cn.CloseConnection();

           
            return lst;
        }


     /*   public static List<Transactions> GetByRouteIDAndPassID(string pass_ID, string route_ID)
        {
            List<Transactions> lst = new List<Transactions>();
            string sql = "SELECT * FROM Transactions where route_ID like '%" + route_ID + "%' and pass_ID like '%" + route_ID + "%'";

            Connector cn = new Connector("data/FINALPROJECT.accdb");
            OleDbDataReader result = cn.RunSelect(sql);
            Transactions c;

            while (result.Read())
            {
                //Console.WriteLine(result[0].ToString());
                //Console.WriteLine(result["client_ID"].ToString());
                //string r = result["client_ID"].ToString();

                c = new Transactions { the_ID = int.Parse(result["the_ID"].ToString()), route_ID = result["route_ID"].ToString(), card_ID = result["card_ID"].ToString(), pass_ID = result["pass_ID"].ToString(), buy_date = result["buy_date"].ToString(), money_amount = result["money_amount"].ToString() };
                lst.Add(c);
            }
            cn.CloseConnection();
            return lst;
        }*/


        [Authorize(Roles = "Manager")]
         public static bool DeleteByID(int the_ID)
         {
             string sql = "delete from Transactions where the_ID=" + the_ID;
             Connector cn = new Connector("data/FINALPROJECT.accdb");
             int result = cn.RunUpdateInsertDelete(sql);
             return result > 0;
         }

         [Authorize(Roles = "Manager")]
         public static bool Edit(Transactions st)
         {
             //edit function before apply!!!!!!!!!!!!!!!!!!!!!

             string sql = "update Transactions set route_ID='" + st.route_ID + "', pass_ID='" + st.pass_ID + "', money_amount='" + st.money_amount + "', card_ID='" + st.card_ID + "', buy_date='" + st.buy_date + "' where the_ID=" + st.the_ID;
             Connector cn = new Connector("data/FINALPROJECT.accdb");
             int result = cn.RunUpdateInsertDelete(sql);
             return result > 0;
         }

         [Authorize(Roles ="Manager")]
         public static bool Add(Transactions st)
         {
             string sql = "insert into Transactions (route_ID, card_ID, pass_ID, money_amount, buy_date) values ('" + st.route_ID + "', '" + st.card_ID + "', '" + st.pass_ID + "', '" + st.money_amount + "', '"+st.buy_date+"')";
             Connector cn = new Connector("data/FINALPROJECT.accdb");
             int result = cn.RunUpdateInsertDelete(sql);
             return result > 0;
         }
    }
}
