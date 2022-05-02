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
        protected List<Npc> Npcs;

        public Guild() => Npcs = new List<Npc>();

        public virtual string WelcomeMessage => String.Empty;

        public virtual ConsoleColor GuildColor => ConsoleColor.White;

        public virtual Npc GetActiveNpc()
        {
            if (!Npcs.Equals(null) && Npcs.Count > 0)
                return Npcs[new Random().Next(0, Npcs.Count)];
            else
                throw new ArgumentNullException("No one NPC was created.");
        }

        public abstract string PlayGame(Player player);

        public virtual string LoseGame(Player player)
        {
            if (player is null)
                throw new ArgumentNullException(nameof(player), "The player value cannot be null.");

            return player.ToDie();
        }
    }
}
