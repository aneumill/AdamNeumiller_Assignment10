using AdamNeumiller_BowlingLeague.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdamNeumiller_BowlingLeague.Components
{
    //View component for the team selector
    public class TeamNameViewComponent : ViewComponent
    {
        private BowlingLeagueContext context;
        public TeamNameViewComponent(BowlingLeagueContext ctx)
        {
            context = ctx;
        }
        //Component 
        public IViewComponentResult Invoke()
        {
            //Set the view bag
            ViewBag.SelectedTeam = RouteData?.Values["teamname"];
            return View(context.Teams.Distinct().OrderBy(x => x));


        }

    }
}
