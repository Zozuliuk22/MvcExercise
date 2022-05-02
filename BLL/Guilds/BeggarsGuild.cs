using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.NPCs;
using DAL.Enums;

namespace BLL.Guilds
{
    public class BeggarsGuild : Guild
    {
        private BeggarNpc _activeNpc;

        public override string WelcomeMessage
        {
            get => $"Please, donate some money.. Save your soul." +
                $"\nAccept to donate a fix sum of money and make a good deed." +
                $"\nOr if you skip us, you will chase you to death..";
        }

        public override ConsoleColor GuildColor => ConsoleColor.DarkGreen;

        public override Npc GetActiveNpc()
        {
            _activeNpc = (BeggarNpc)base.GetActiveNpc();
            return _activeNpc;
        }

        public override string PlayGame(Player player)
        {
            if (player is null)
                throw new ArgumentNullException(nameof(player), "The player value cannot be null.");

            if (_activeNpc.Practice.Equals(BeggarsPractice.BeerNeeders))
                return player.ToDie() + "Lack of beer is sometimes fatal.";
            else if (player.CurrentBudget >= _activeNpc.Fee)
            {
                player.LoseMoney(_activeNpc.Fee);
                return $"You donated some money. Good deeds come back like a boomerang. Therefore, live on.";
            }
            else
                return player.ToDie() + $" Unfortunately, you didn't have enough money to donate. " +
                    $"And {_activeNpc.Name} chased you to death.";
        }

        public override string LoseGame(Player player)
        {
            return base.LoseGame(player) + $" Unfortunately, beggars don't forgive deeds like this.";
        }

        public override string ToString() => $"Beggars' Guild";
    }
}
