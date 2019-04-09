using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuotingDojo.Models;
using DbConnection;

namespace QuotingDojo.Controllers
{
    public class HomeController : Controller
    {
        [Route("")]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create(User user)
        {
            string query = $"INSERT INTO users (name, quote) VALUES ('{user.Name}', '{user.Quote}');";
            DbConnector.Execute(query);
            // other code
            return RedirectToAction("Result");
        }
        [Route("/result")]
        [HttpGet]
        public IActionResult Result()
        {
    	    List<Dictionary<string, object>> AllUsers = DbConnector.Query("SELECT * FROM users");
            // To provide this data, we could use ViewBag or a View Model.  ViewBag shown here:
            ViewBag.Users = AllUsers;
            return View("Result");
        }

    }
}
