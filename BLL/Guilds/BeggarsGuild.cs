using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.NPCs;
using BLL.Constants;
using DAL.Enums;
using DAL.Interfaces;
using System.Drawing;
using BLL.Properties;



namespace BLL.Guilds
{
    public class BeggarsGuild : Guild
    {
        private IUnitOfWork _unitOfWork;

        private List<BeggarNpc> _npcs = new List<BeggarNpc>();
        private BeggarNpc _activeNpc;

        public BeggarsGuild(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            InitializeGuild();
        }

        public override string WelcomeMessage
        {
            get => $"Please, donate some money.. Save your soul." +
                $"\nAccept to donate a fix sum of money and make a good deed." +
                $"\nOr if you skip us, you will chase you to death..";
        }

        public override ConsoleColor GuildColor => ConsoleColor.DarkGreen;

        public override Bitmap GuildImage => GuildsImages.BeggarsGuild;

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

            if (_activeNpc.Practice.Equals(BeggarsPractice.BeerNeeders))
            {
                return player.CurrentBeers > 0 ? player.LoseBeer() + " Thank you, my dear friend!" :
                                                 player.ToDie() + "Lack of beer is sometimes fatal.";
            }
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

        private void InitializeGuild()
        {
            var npcs = _unitOfWork.BeggarNpcs.GetAll();
            foreach (var npc in npcs)
            {
                _npcs.Add(new BeggarNpc()
                {
                    Name = npc.Name,
                    Practice = npc.Practice,
                    Fee = PracticesInfo.BeggarsPracticeInfo[npc.Practice].Item2,
                    FullPracticeName = PracticesInfo.BeggarsPracticeInfo[npc.Practice].Item1
                });
            }
        }
    }
}
