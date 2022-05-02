using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.NPCs;

namespace BLL.Guilds
{
    public class FoolsGuild : Guild
    {
        private FoolNpc _activeNpc;

        public override string WelcomeMessage
        {
            get => $"Hi! I'm your friend in Ankh-Morpork!" +
                $"\nAccept to earn some money in this city. If you skip, you get nothing.";
        }

        public override ConsoleColor GuildColor => ConsoleColor.Yellow;

        public override Npc GetActiveNpc()
        {
            _activeNpc = (FoolNpc)base.GetActiveNpc();
            return _activeNpc;
        }

        public override string PlayGame(Player player)
        {
            if (player is null)
                throw new ArgumentNullException(nameof(player), "The player value cannot be null.");

            player.EarnMoney(_activeNpc.Bonus);
            return $"Our congratulations! You earned some money.\nBut remember, " +
                $"you have to pretend to be a fool, as your friend {_activeNpc.FullPracticeName}.";
        }

        public override string LoseGame(Player player)
        {
            if (player is null)
                throw new ArgumentNullException(nameof(player), "The player value cannot be null.");

            return $"That's strange. You lost easy money.\n*These players, sometimes, are so illogical.";
        }

        public override string ToString() => $"Fools' Guild";
    }
}
