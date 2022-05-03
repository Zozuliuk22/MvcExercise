using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using BLL.Properties;

namespace BLL
{
    public class Pub
    {
        private const decimal _beerPrice = 2;

        public string WelcomeMessage
        {
            get 
            { 
                return "You are in a bar. 1 pint of beer = 2$ AM."; 
            }
        }

        public ConsoleColor Color => ConsoleColor.DarkRed;

        public Bitmap Image => GuildsImages.Pub;

        public string PlayGame(Player player)
        {
            if (player.CurrentBudget >= _beerPrice && player.CurrentBeers < player.MaxBeers)
            {
                player.LoseMoney(_beerPrice);
                return player.BuyBeer();
            }
            else
                return player.ToDie();
        }

        public string LoseGame()
        {
            return "That's strange. You lost a chance to survive.\n*These players, sometimes, are so illogical.";
        }

        public override string ToString()
        {
            return "\"The Mended Drum\" pub";
        }
    }
}
