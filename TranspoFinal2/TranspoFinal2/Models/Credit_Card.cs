using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Threading.Tasks;

namespace TranspoFinal2.Models
{
    public class Credit_Card
    {
        public int the_ID { set; get; }
        public int card_CVV { set; get; }
        public string card_ID { set; get; }
        public string pass_ID { set; get; }
        public string money_amount { set; get; }
        public string month { set; get; }
        public string year { set; get; }

        public string expired_date { set; get; }
        
        public static List<Credit_Card> GetAllOrBytheID(string str)
        {
            List<Credit_Card> lst = new List<Credit_Card>();
            string sql = "SELECT * FROM Credit_Card";
            if (str != null)
                sql += " where the_ID =" + str;
            Connector cn = new Connector("data/FINALPROJECT.accdb");
            OleDbDataReader result = cn.RunSelect(sql);
            Credit_Card c;

            while (result.Read())
            {
                c = new Credit_Card { the_ID = int.Parse(result["the_ID"].ToString()), card_CVV = int.Parse(result["card_CVV"].ToString()), card_ID = result["card_ID"].ToString(), expired_date = result["expired_date"].ToString(), money_amount=result["money_amount"].ToString(), pass_ID=result["pass_ID"].ToString()  };
                lst.Add(c);
            }
            cn.CloseConnection();
            return lst;
        }
        
        public static List<Credit_Card> GetByCardID(string str)
        {
            List<Credit_Card> lst = new List<Credit_Card>();
            string sql = "SELECT * FROM Credit_Card where card_ID like '%" + str + "%'";
            Connector cn = new Connector("data/FINALPROJECT.accdb");
            OleDbDataReader result = cn.RunSelect(sql);
            Credit_Card c;

            while (result.Read())
            {

                c = new Credit_Card { the_ID = int.Parse(result["the_ID"].ToString()), card_CVV = int.Parse(result["card_CVV"].ToString()), card_ID = result["card_ID"].ToString(), expired_date = result["expired_date"].ToString(), money_amount = result["money_amount"].ToString(), pass_ID = result["pass_ID"].ToString() };
                lst.Add(c);
            }
            cn.CloseConnection();
                       
            return lst;
        }

        public static List<Credit_Card> GetByPassID(string str)
        {
            List<Credit_Card> lst = new List<Credit_Card>();
            string sql = "SELECT * FROM Credit_Card where pass_ID like '%" + str + "%'";
            Connector cn = new Connector("data/FINALPROJECT.accdb");
            OleDbDataReader result = cn.RunSelect(sql);
            Credit_Card c;

            while (result.Read())
            {

                c = new Credit_Card { the_ID = int.Parse(result["the_ID"].ToString()), card_CVV = int.Parse(result["card_CVV"].ToString()), card_ID = result["card_ID"].ToString(), expired_date = result["expired_date"].ToString(), money_amount = result["money_amount"].ToString(), pass_ID = result["pass_ID"].ToString() };
                lst.Add(c);
            }
            cn.CloseConnection();

            return lst;
        }

        [Authorize(Roles = "Manager")]
        public static bool DeleteByTheID(string the_ID)
        {
            string sql = "delete from Credit_Card where the_ID=" + the_ID;
            Connector cn = new Connector("data/FINALPROJECT.accdb");
            int result = cn.RunUpdateInsertDelete(sql);
            return result > 0;
        }

        [Authorize(Roles = "Manager")]
        public static bool Edit(Credit_Card st)
        {
            string sql = "update Credit_Card set card_ID='" + st.card_ID + "', pass_ID='" + st.pass_ID + "', money_amount='" + st.money_amount + "', expired_date='" + st.expired_date + "', card_CVV="+st.card_CVV+" where the_ID=" + st.the_ID;
            Connector cn = new Connector("data/FINALPROJECT.accdb");
            int result = cn.RunUpdateInsertDelete(sql);
            return result > 0;
        }

        [Authorize(Roles = "Manager")]
        public static bool Add(Credit_Card st)
        {
            string sql = "insert into Credit_Card (card_ID, pass_ID, card_CVV, money_amount, expired_date) values ('" + st.card_ID + "', '" + st.pass_ID + "', " + st.card_CVV + ", '" + st.money_amount + "', '"+st.expired_date+"')";
            Connector cn = new Connector("data/FINALPROJECT.accdb");
            int result = cn.RunUpdateInsertDelete(sql);
            return result > 0;
        }
    }
}
