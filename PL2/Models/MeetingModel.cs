using System.Drawing;

namespace PL.Models
{
    public class MeetingModel
    {
        public string GuildName { get; set; }

        public string WelcomeGuildsWord { get; set; }

        public string WelcomeNpcsWord { get; set; }

        public string Color { get; set; }

        public string PlayerScore { get; set; }

        public bool PlayerIsAlive { get; set; }

        public decimal PlayerCurrentBudget { get; set; }

        public string ResultMeetingMessage { get; set; }

        public Bitmap Image { get; set; }
    }
}
