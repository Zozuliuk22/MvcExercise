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

        public string Name { get; set; }

        public int Score => _score;

        public bool IsAlive { get; private set; }

        public decimal CurrentBudget { get; private set; }

        public Player(string name)
        {
            if (String.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException("The Player's name must consist of symbols.");

            Name = name;
            CurrentBudget = _startBudget;
            IsAlive = true;
        }

        /// <summary>
        /// Add to the current budget the bonus value.
        /// </summary>
        /// <param name="bonus">The bonus value.</param>
        /// <exception cref="ArgumentException">The bonus must be bigger or equal then zero.</exception>
        public void EarnMoney(decimal bonus)
        {
            if (bonus < 0)
                throw new ArgumentException("Bonus must be bigger or equal then zero.");
            CurrentBudget += bonus;
            _score += 1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fee"></param>
        /// <exception cref="ArgumentException"></exception>
        public void LoseMoney(decimal fee)
        {
            if (fee < 0 || fee > CurrentBudget)
                throw new ArgumentException("Fee must be bigger or equal then zero " +
                                            "and less or equal than current budget.");
            CurrentBudget -= fee;
            _score += 1;
        }

        /// <summary>
        /// A player dies that means game is over.
        /// </summary>
        /// <returns>The "You were killed!" message.</returns>
        public string ToDie()
        {
            IsAlive = false;
            return "You were killed!";
        }

        public override string ToString() => $"Player {Name} have survived {Score} meetings.";
    }
}
