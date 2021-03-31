using AdamNeumiller_BowlingLeague.Models;
using AdamNeumiller_BowlingLeague.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AdamNeumiller_BowlingLeague.Controllers
{
    //Home controller
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //Bring in the context file
        private BowlingLeagueContext context { get; set; }
        //Bring the Bowling league context into the project
        public HomeController(ILogger<HomeController> logger, BowlingLeagueContext ctx)
        {
            _logger = logger;
            context = ctx;
        }

        //This is the Index action
        public IActionResult Index(long teamID, string teamname,int pageNum = 0)
        {
            //Set the items per page
            int pageSize = 5;

            return View(new IndexViewModel
            {
                Bowlers = (context.Bowlers
            .Where(x => x.TeamId == teamID || teamID == 0)
            .OrderBy(x => x.BowlerLastName)
            .Skip((pageNum - 1) * pageSize)
            .Take(pageSize)
            .ToList()),

                //Create the page numbering info dynamically
                PageNumberingInfo = new PagingNumberingInfo
                {
                    NumItemsPerPage = pageSize,
                    CurrentPage = pageNum,
                    TotalNumItems = (teamID == 0 ? context.Bowlers.Count() :
                        context.Bowlers.Where(x => x.TeamId == teamID).Count())

                },

                TeamName = teamname

            }) ; 
            
        }

      

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
