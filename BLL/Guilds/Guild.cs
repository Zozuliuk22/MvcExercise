using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.NPCs;

namespace BLL.Guilds
{
    public abstract class Guild
    {
        public virtual string WelcomeMessage => String.Empty;

        public virtual ConsoleColor GuildColor => ConsoleColor.White;

        public abstract string PlayGame(Player player);

        public virtual string LoseGame(Player player)
        {
            if (player is null)
                throw new ArgumentNullException(nameof(player), "The player value cannot be null.");

            return player.ToDie();
        }
    }
}
