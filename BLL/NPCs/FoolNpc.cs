using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Enums;

namespace BLL.NPCs
{
    public class FoolNpc : Npc
    {
        public FoolsPractice Practice { get; set; }

        public decimal Bonus { get; set; }

        public string FullPracticeName { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as FoolNpc);
        }

        private bool Equals(FoolNpc other)
        {
            if (other is null)
                return false;
            else
            {
                return other.Name.Equals(Name) && other.Practice.Equals(Practice);
            }
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Practice);
        }

        public override string ToString()
        {
            return Bonus >= 1 ?
                $"I'm {Name} from {FullPracticeName}s. And I can give you {Bonus} AM$" :
                $"I'm {Name} from {FullPracticeName}s. And I can give you {Math.Truncate(Bonus * 100)} pence";
        }
    }
}
