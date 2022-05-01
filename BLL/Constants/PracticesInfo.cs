using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Enums;

namespace BLL.Constants
{
    internal static class PracticesInfo
    {
        internal static readonly Dictionary<BeggarsPractice, (string, decimal)> BeggarsPracticeInfo =
                             new Dictionary<BeggarsPractice, (string, decimal)>()
        {
            { BeggarsPractice.Twitchers, ("Twitchers", 3) },
            { BeggarsPractice.Droolers, ("Droolers", 2) },
            { BeggarsPractice.Dribblers, ("Dribblers", 1) },
            { BeggarsPractice.Mumblers, ("Mumblers", 1) },
            { BeggarsPractice.Mutterers, ("Mutterers", 0.9m) },
            { BeggarsPractice.WalkingAlongShouters, ("Walking-Along-Shouters", 0.8m) },
            { BeggarsPractice.Demanders, ("Demanders of a Chip", 0.6m) },
            { BeggarsPractice.JimmyCaller, ("People Who Call Other People Jimmy", 0.5m) },
            { BeggarsPractice.EightpenceForMeal, ("People Who Need Eightpence For A Meal", 0.08m) },
            { BeggarsPractice.TwopenceForTea, ("People Who Need Tuppence For A Cup Of Tea", 0.02m) },
            { BeggarsPractice.BeerNeeders, ("People With Placards Saying \"Why lie ? I need a beer.\"", 0) }
        };

        internal static readonly Dictionary<FoolsPractice, (string, decimal)> FoolsPracticeInfo =
                             new Dictionary<FoolsPractice, (string, decimal)>()
        {
            { FoolsPractice.Muggins, ("Muggins", 0.5m) },
            { FoolsPractice.Gull, ("Gull", 1) },
            { FoolsPractice.Dupe, ("Dupe", 2) },
            { FoolsPractice.Butt, ("Butt", 3) },
            { FoolsPractice.Fool, ("Fool", 5) },
            { FoolsPractice.Tomfool, ("Tomfool", 6) },
            { FoolsPractice.StupidFool, ("Stupid Fool", 7) },
            { FoolsPractice.ArchFool, ("Arch Fool", 8) },
            { FoolsPractice.CompleteFool, ("Complete Fool", 10) }
        };
    }
}
