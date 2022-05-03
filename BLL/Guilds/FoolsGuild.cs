using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.NPCs;
using BLL.Constants;
using DAL.Interfaces;
using System.Drawing;
using BLL.Properties;

namespace BLL.Guilds
{
    public class FoolsGuild : Guild
    {
        private IUnitOfWork _unitOfWork;

        private List<FoolNpc> _npcs = new List<FoolNpc>();
        private FoolNpc _activeNpc;

        public FoolsGuild(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            InitializeGuild();
        }

        public override string WelcomeMessage
        {
            get => $"Hi! I'm your friend in Ankh-Morpork!" +
                $"\nAccept to earn some money in this city. If you skip, you get nothing.";
        }

        public override ConsoleColor GuildColor => ConsoleColor.Yellow;

        public override Bitmap GuildImage => GuildsImages.FoolsGuild;

        public Npc GetActiveNpc()
        {
            if (!_npcs.Equals(null) && _npcs.Count > 0)
                _activeNpc = _npcs[new Random().Next(0, _npcs.Count)];
            else
                throw new ArgumentNullException("No one NPC was created.");

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

            player.HasIneffectualMeeting();

            return $"That's strange. You lost easy money.\n*These players, sometimes, are so illogical.";
        }

        public override string ToString() => $"Fools' Guild";

        private void InitializeGuild()
        {
            var npcs = _unitOfWork.FoolNpcs.GetAll();
            foreach (var npc in npcs)
            {
                _npcs.Add(new FoolNpc()
                {
                    Name = npc.Name,
                    Practice = npc.Practice,
                    Bonus = PracticesInfo.FoolsPracticeInfo[npc.Practice].Item2,
                    FullPracticeName = PracticesInfo.FoolsPracticeInfo[npc.Practice].Item1
                });
            }
        }

        public override void Reset()
        {
            _activeNpc = null;
        }
    }
}
