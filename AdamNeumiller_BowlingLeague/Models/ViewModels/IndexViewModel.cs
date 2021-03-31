using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdamNeumiller_BowlingLeague.Models.ViewModels
{
    //The view model for the the bowler model and the pagination
    public class IndexViewModel
    {
        public IEnumerable<Bowler> Bowlers {get;set;}
        public PagingNumberingInfo PageNumberingInfo { get; set; }

        public string TeamName { get; set; }

        
   
    }
}
