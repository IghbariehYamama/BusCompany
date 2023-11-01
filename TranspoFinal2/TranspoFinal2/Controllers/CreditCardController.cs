using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TranspoFinal2.Models;

namespace TranspoFinal2.Controllers
{
    public class CreditCardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult ViewEditCardInfo(string pass_ID)
        {
            Credit_Card st = Credit_Card.GetByPassID(pass_ID)[0];
            int i = 0;
            while(st.expired_date[i] != '/')
            {
                st.month += st.expired_date[i];
                i++;
            }
            st.month += "/";
            i++;
            while (i<st.expired_date.Length)
            {
                st.year += st.expired_date[i];
                i++;
            }

            return View("EditCardInfo", st);
        }


        public IActionResult EditCardInfo(Credit_Card st)
        {
            Credit_Card test = Credit_Card.GetAllOrBytheID(st.the_ID.ToString())[0];
            List<Transactions> tr = Transactions.GetByPassID(st.pass_ID);
            Credit_Card.Edit(st);
            for(int i=0; i<tr.Count; i++)
            {
                tr[i].card_ID = st.card_ID;
                Transactions.Edit(tr[i]);
            }
            return RedirectToAction("ViewProfile", "Passenger");
        }
    }
}