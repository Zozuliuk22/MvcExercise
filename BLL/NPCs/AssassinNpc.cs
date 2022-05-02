using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.NPCs
{
    public class AssassinNpc : Npc
    {
        private DateTime _startingDataOccupied = DateTime.Now.AddSeconds(-300);

        public decimal MinReward { get; set; }

        public decimal MaxReward { get; set; }

        public bool IsOccupied
        {
            get
            {
                if (DateTime.Now.Subtract(_startingDataOccupied).TotalSeconds <= 180)
                    return true;
                else
                    return false;
            }
        }

        public void TakeContract()
        {
            if (IsOccupied)
                throw new Exception("Assassin is already occupied.");
            else
                _startingDataOccupied = DateTime.Now;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as AssassinNpc);
        }

        private bool Equals(AssassinNpc other)
        {
            if (other is null)
                return false;
            else
            {
                if (other.Name.Equals(Name)
                    && other.MinReward.Equals(MinReward)
                    && other.MaxReward.Equals(MaxReward))
                    return true;
                return false;
            }
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, MinReward, MaxReward);
        }
    }
}
