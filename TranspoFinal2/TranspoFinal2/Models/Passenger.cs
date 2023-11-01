using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Threading.Tasks;

namespace TranspoFinal2.Models
{
    public class Passenger
    {
        public int the_ID { set; get; }
        public string pass_ID { set; get; }
        public string pass_name { set; get; }
        public string pass_email { set; get; }
        public string pass_money { set; get; }
        public string pass_birthday { set; get; }
        public string pass_last_update_profile { set; get; }
        public string pass_photo { set; get; }
        public bool pass_active { set; get; }
        public string pass_psw { set; get; }
        public IFormFile file1 { set; get; }
        public DateTime brth { set; get; }

        public static List<Passenger> GetAllOrByPassID(string str)
        {
            List<Passenger> lst = new List<Passenger>();
            string sql = "SELECT * FROM Passengers";
            if (str != null)
                sql += " where pass_ID like '%" + str + "%'";
            Connector cn = new Connector("data/FINALPROJECT.accdb");
            OleDbDataReader result = cn.RunSelect(sql);
            Passenger c;

            while (result.Read())
            {
                c = new Passenger { pass_ID = result["pass_ID"].ToString(), pass_name = result["pass_name"].ToString(), pass_active = bool.Parse(result["pass_active"].ToString()), pass_photo = result["pass_photo"].ToString(), pass_psw=result["pass_psw"].ToString(), pass_email= result["pass_email"].ToString(), pass_money= result["pass_money"].ToString(), pass_birthday= result["pass_birthday"].ToString(), pass_last_update_profile= result["pass_last_update_profile"].ToString(), the_ID=int.Parse(result["the_ID"].ToString()) };
                lst.Add(c);
            }
            cn.CloseConnection();
            return lst;
        }

        public static List<Passenger> GetByPassName(string str)
        {
            List<Passenger> lst = new List<Passenger>();
            string sql = "SELECT * FROM Passengers where pass_ID like '%" + str + "%'";

            Connector cn = new Connector("data/FINALPROJECT.accdb");
            OleDbDataReader result = cn.RunSelect(sql);
            Passenger c;

            while (result.Read())
            {
                c = new Passenger { pass_ID = result["pass_ID"].ToString(), pass_name = result["pass_name"].ToString(), pass_active = bool.Parse(result["pass_active"].ToString()), pass_photo = result["pass_photo"].ToString(), pass_psw = result["pass_psw"].ToString(), pass_email = result["pass_email"].ToString(), pass_money = result["pass_money"].ToString(), pass_birthday = result["pass_birthday"].ToString(), pass_last_update_profile = result["pass_last_update_profile"].ToString(), the_ID = int.Parse(result["the_ID"].ToString()) };
                lst.Add(c);
            }
            cn.CloseConnection();
            return lst;
        }

        public static Passenger GetBytheID(int the_ID)
        {
            string sql = "SELECT * FROM Passengers where the_ID =" + the_ID;
            Connector cn = new Connector("data/FINALPROJECT.accdb");
            OleDbDataReader result = cn.RunSelect(sql);
            Passenger c=new Passenger();

            while (result.Read())
            {
                c = new Passenger { pass_ID = result["pass_ID"].ToString(), pass_name = result["pass_name"].ToString(), pass_active = bool.Parse(result["pass_active"].ToString()), pass_photo = result["pass_photo"].ToString(), pass_psw = result["pass_psw"].ToString(), pass_email = result["pass_email"].ToString(), pass_money = result["pass_money"].ToString(), pass_birthday = result["pass_birthday"].ToString(), pass_last_update_profile = result["pass_last_update_profile"].ToString(), the_ID = int.Parse(result["the_ID"].ToString()) };
            }
            cn.CloseConnection();
            return c;
        }

        [Authorize(Roles = "Manager")]
        public static bool DeleteByID(Passenger st)
        {
            string sql = "delete from Passengers where pass_ID='" + st.pass_ID + "'";
            Connector cn = new Connector("data/FINALPROJECT.accdb");
            int result = cn.RunUpdateInsertDelete(sql);
            return result > 0;
        }

        [Authorize(Roles ="Manager")]
        public static bool Edit(Passenger st)
        {
            string sql = "update Passengers set pass_name='"+st.pass_name+"', pass_email='"+st.pass_email+"', pass_money="+st.pass_money+", pass_birthday='"+st.pass_birthday+"', pass_last_update_profile='"+st.pass_last_update_profile+"', pass_photo='"+st.pass_photo+"', pass_active="+st.pass_active+", pass_psw='"+st.pass_psw+"' where pass_ID='"+st.pass_ID+"'" ;
            Connector cn = new Connector("data/FINALPROJECT.accdb");
            int result = cn.RunUpdateInsertDelete(sql);
            return result > 0;
        }

        [Authorize(Roles = "Manager")]
        public static bool Add(Passenger st)
        {
            string sql = "insert into Passengers (pass_ID, pass_name, pass_email, pass_money, pass_birthday, pass_last_update_profile, pass_photo, pass_active, pass_psw) values ('" + st.pass_ID + "', '" + st.pass_name + "', '" + st.pass_email + "', "+st.pass_money+" ,'" + st.pass_birthday + "', '"+st.pass_last_update_profile+"', '"+st.pass_photo+"', "+st.pass_active+", '"+st.pass_psw+"')";
            Connector cn = new Connector("data/FINALPROJECT.accdb");
            int result = cn.RunUpdateInsertDelete(sql);
            return result > 0;
        }

        public static int LastAddedPass()
        {
            string sql = "SELECT max (the_ID) from Passengers";
            Connector cn = new Connector("data/FINALPROJECT.accdb");
            int x = cn.RunScalar(sql);
            return x;
        }

        public static Passenger CheckUser(string UserID, string UserPassword)
        {

            List<Passenger> users = Passenger.GetAllOrByPassID(null);
            for(int i=0; i<users.Count; i++)
            {
                if (users[i].pass_ID.CompareTo(UserID) == 0 && users[i].pass_psw.CompareTo(UserPassword) == 0)
                    return users[i];
            }

            return null;
        }
    }
}
