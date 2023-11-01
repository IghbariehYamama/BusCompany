using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TranspoFinal2.Models;

namespace TranspoFinal2.Controllers
{
    public class TicketController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    
        
        public IActionResult BuyTicket(route st)
        {
            List<Transactions> tr=Transactions.GetByPassID(User.Identity.Name);
            for(int i=0; i<tr.Count; i++)//the user cannot reserve twice, so this for is to check if he's already reserved in this bus
            {
                if (tr[i].route_ID == st.route_ID)
                    return View("CannotBuy");
            }


            Ticket tick = Ticket.GetByRouteID(st.route_ID);

            ViewBag.bus = st.route_ID;
            ViewBag.seats = Bus_Seats.GetByRouteID(st.route_ID);

            return View("BuyTicket");
        }

        [HttpPost]
        public IActionResult DoneBuying(Bus_Seats bu)
        {
            Bus_Seats.Add(bu);
            Credit_Card card = Credit_Card.GetByPassID(bu.pass_ID)[0];
            Ticket tick = Ticket.GetByRouteID(bu.route_ID);//we've brought the ticket and the credi card info from the database to fill the transaction's info
            card.money_amount = (double.Parse(card.money_amount) - double.Parse(tick.price)).ToString();//since he bought a ticket we need to take money from his account
            Passenger pass = Passenger.GetAllOrByPassID(User.Identity.Name)[0];
            pass.pass_money = card.money_amount;
            Passenger.Edit(pass);
            Credit_Card.Edit(card);
            Transactions st = new Transactions { buy_date=DateTime.Now.ToShortDateString(), pass_ID=bu.pass_ID, route_ID=bu.route_ID, money_amount=tick.price, card_ID=card.card_ID};
            Transactions.Add(st);
            ViewBag.seat = bu.seat_num;
            return View("ConfirmedPurchase", st);
        }
 
        public IActionResult GetAllTickets()
        {
            List<Transactions> transaction = Transactions.GetByPassID(User.Identity.Name);
            ViewBag.l2 = 1;
            ViewBag.transaction = transaction;
            return View("AllMyTickets");
        }

        [HttpPost]
        public IActionResult SearchTicket(Transactions st)
        {
            ViewBag.l1 = Transactions.GetByRouteID(st.route_ID);

            ViewBag.l2 = 1;
            return View("AllMyTickets");
        }

        public IActionResult DeleteTicket(Transactions st)
        {
            Transactions.DeleteByID(st.the_ID);
            Bus_Seats bu = Bus_Seats.GetByPassIDAndRouteID(st.route_ID, st.pass_ID)[0];
            Bus_Seats.DeleteByTheID(bu.the_ID);
            List<Transactions> transaction = Transactions.GetByPassID(User.Identity.Name);
            ViewBag.l2 = 1;
            ViewBag.transaction = transaction;
            return View("AllMyTickets");
        }

        public IActionResult GetThisTicketInfo(Transactions st)
        {
            Bus_Seats bu = Bus_Seats.GetByPassIDAndRouteID(st.route_ID, st.pass_ID)[0];
            ViewBag.seat = bu.seat_num;
            return View("ThisTicketInfo", st);
        }

        public IActionResult BusInfo(Ticket st)
        {
            route rt = route.GetByID(st.route_ID)[0];
            return RedirectToAction("BusInfo", "Route", rt);
        }
    }
}