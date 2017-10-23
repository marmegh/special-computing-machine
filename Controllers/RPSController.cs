using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;

namespace rps.Controllers
{
    public class RPSController : Controller
    {
        public static Random rand = new Random();
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            if(TempData["name"] != null)
            {
                if(TempData["count"] ==null)
                {
                    TempData["count"] = 0;
                    TempData["wins"] = 0;
                }
                else
                {
                    ViewBag.result = TempData["result"];
                }
                ViewBag.name = TempData["name"];
                ViewBag.count = TempData["count"];
                ViewBag.wins = TempData["wins"];
                return View("~/Views/RPS/game.cshtml", ViewBag);
            }
            else{
                return View();
            }
        }
        [HttpPost]
        [Route("process")]
        public IActionResult Process(string name)
        {
            TempData["name"] = name;
            return RedirectToAction("Index");
        }
        [HttpPost]
        [Route("game")]
        public IActionResult Game(string result, string wins, string count, string name)
        {
            TempData["game"] = result;
            int winhx = Convert.ToInt32(wins);
            int counthx = Convert.ToInt32(count) + 1;
            if(rand.Next(0,4) == 1)//rock
            {
                if (result == "rock")
                {
                    TempData["result"] = "tie";
                }
                else if (result == "paper")
                {
                    TempData["result"] = "win";
                    winhx++;
                }
                else
                {
                    TempData["result"] = "lose";
                }
            }
            else if(rand.Next(0,4) == 2)//paper
            {
                if (result == "paper")
                {
                    TempData["result"] = "tie";
                }
                else if (result == "rock")
                {
                    TempData["result"] = "win";
                    winhx++;
                }
                else
                {
                    TempData["result"] = "lose";
                }
            }
            else//scissors
            {
                if (result == "scissors")
                {
                    TempData["result"] = "tie";
                }
                else if (result == "rock")
                {
                    TempData["result"] = "win";
                    winhx++;
                }
                else
                {
                    TempData["result"] = "lose";
                }
            }
            TempData["name"] = name;
            TempData["count"] = counthx;
            TempData["wins"] = winhx;
            return RedirectToAction("Index");
        }
        [HttpPost]
        [Route("reset")]
        public IActionResult Reset(string name)
        {
            TempData["name"] = name;
            return RedirectToAction("Index");
        }
        [HttpPost]
        [Route("again")]
        public IActionResult Again(string name, string count, string wins)
        {
            TempData["name"] = name;
            int counthx = Convert.ToInt32(count) + 1;
            TempData["count"] = counthx;
            int winhx = Convert.ToInt32(wins);
            TempData["wins"] = winhx;
            return RedirectToAction("Index");
        }
    }
}