using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Player
    {
        private const decimal _startBudget = 100;
        private int _score = 0;
        private const byte _maxBeers = 2;

        public string Name { get; set; }

        public int Score => _score;

        public bool IsAlive { get; private set; }

        public decimal CurrentBudget { get; private set; }

        public int CurrentBeers { get; private set; }

        public int MaxBeers { get { return _maxBeers; } }

        public Player(string name)
        {
            if (String.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException("The Player's name must consist of symbols.");

            Name = name;
            CurrentBudget = _startBudget;
            CurrentBeers = 0;
            IsAlive = true;
        }

        public void EarnMoney(decimal bonus)
        {
            if (bonus < 0)
                throw new ArgumentException("Bonus must be bigger or equal then zero.");
            CurrentBudget += bonus;
            _score += 1;
        }

        public void LoseMoney(decimal fee)
        {
            if (fee < 0 || fee > CurrentBudget)
                throw new ArgumentException("Fee must be bigger or equal then zero " +
                                            "and less or equal than current budget.");
            CurrentBudget -= fee;
            _score += 1;
        }

        public string FindBeer()
        {
            CurrentBeers += 1;
            return "";
        }

        public string LoseBeer()
        {
            CurrentBeers -= 1;
            return "You donated a bottle of beer.";
        }

        public void HasIneffectualMeeting() => _score += 1;

        public string ToDie()
        {
            IsAlive = false;
            return "You were killed!";
        }

        public override string ToString() => $"Player {Name} have survived {Score} meetings.";
    }
}
