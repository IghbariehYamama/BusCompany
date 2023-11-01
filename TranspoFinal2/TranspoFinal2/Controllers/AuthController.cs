using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TranspoFinal2.Models;

namespace TranspoFinal2.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(Credit_Card cr)
        {
            cr.expired_date = cr.month + cr.year;//we add year and month separately then we connect them
            int x = Passenger.LastAddedPass();
            Passenger st = Passenger.GetBytheID(x);
            st.pass_money = cr.money_amount;

            cr.pass_ID = st.pass_ID;
            Credit_Card.Add(cr);
            Passenger.Edit(st);
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, st.pass_ID),
            new Claim(ClaimTypes.Role,"Passenger")
        };
                var userIdentity = new ClaimsIdentity(claims, "SecureLogin");
                var userPrincipal = new ClaimsPrincipal(userIdentity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    userPrincipal,
                    new AuthenticationProperties
                    {
                        ExpiresUtc = DateTime.UtcNow.AddMinutes(20),
                        IsPersistent = false,
                        AllowRefresh = false
                    });

                return Redirect("~/Passenger"); ///logged as passenger
            
        }


        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginAsync(Passenger st)
        {
            if (st.pass_ID == "212001267" && st.pass_psw == "123")
            {
                Passenger mn = Passenger.GetAllOrByPassID(st.pass_ID)[0];
                mn.pass_active = true;
                Passenger.Edit(mn);//logged in so he's active (update it)

                var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, st.pass_ID),
            new Claim(ClaimTypes.Role,"Manager")
        };
                var userIdentity = new ClaimsIdentity(claims, "SecureLogin");
                var userPrincipal = new ClaimsPrincipal(userIdentity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    userPrincipal,
                    new AuthenticationProperties
                    {
                        ExpiresUtc = DateTime.UtcNow.AddMinutes(20),
                        IsPersistent = false,
                        AllowRefresh = false
                    });

                return Redirect("~/Passenger");
            }


            Passenger ps = Passenger.CheckUser(st.pass_ID, st.pass_psw);//to return the passenger details from the database
            if (ps != null)
            {
                Passenger mn = Passenger.GetAllOrByPassID(st.pass_ID)[0];
                mn.pass_active = true;
                Passenger.Edit(mn);//logged in so he's active (update it)

                var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, st.pass_ID),
            new Claim(ClaimTypes.Role,"Passenger")
        };
                var userIdentity = new ClaimsIdentity(claims, "SecureLogin");
                var userPrincipal = new ClaimsPrincipal(userIdentity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    userPrincipal,
                    new AuthenticationProperties
                    {
                        ExpiresUtc = DateTime.UtcNow.AddMinutes(20),
                        IsPersistent = false,
                        AllowRefresh = false
                    });

                return Redirect("~/Passenger"); ///logged as passenger
            }

            return RedirectToAction("ViewRejected", "Passenger", st);
        }

                              
        private async Task<string> UploadPhoto(IFormFile f1, string folder)
        {
            var baseFolder = "wwwroot";
            var newFileName = DateTime.Now.Ticks.ToString() + "_" + f1.FileName;
            var filepath = baseFolder + "/" + folder + "/" + newFileName;

            using (var stream = new FileStream(filepath, FileMode.Create))
            {
                await f1.CopyToAsync(stream);
            }
            return newFileName;
        }

        
        public async Task<IActionResult> Logout()
        {
            Passenger mn = Passenger.GetAllOrByPassID(User.Identity.Name)[0];
            mn.pass_active = false;
            Passenger.Edit(mn);//logged out so he's not active (update it)

            await HttpContext.SignOutAsync();
            return Redirect("~/Passenger");
        }


    }
}