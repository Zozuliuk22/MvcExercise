using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Enums;

namespace BLL.NPCs
{
    public class BeggarNpc : Npc
    {
        public BeggarsPractice Practice { get; set; }

        public decimal Fee { get; set; }

        public string FullPracticeName { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as BeggarNpc);
        }

        private bool Equals(BeggarNpc other)
        {
            if (other is null)
                return false;
            else
            {
                if (other.Name.Equals(Name) && other.Practice.Equals(Practice))
                    return true;
                return false;
            }
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Practice);
        }

        public override string ToString()
        {
            return Practice.Equals(BeggarsPractice.BeerNeeders) ?
                $"Sorry, dear friend. But I really need only beer." :
                Fee >= 1 ?
                $"I'm {Name} from {FullPracticeName}. And I just need {Fee} AM$" :
                $"I'm {Name} from {FullPracticeName}. And I just need {Math.Truncate(Fee * 100)} pence";
        }
    }
}
