using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTOs;

namespace BLL
{
    public interface IScenarioCreator
    {
        MeetingDto CreateRandomGuildMeeting();
        string Accept(Player player);
        string Skip(Player player);
        void UseEnteredFee(decimal fee);
    }
}
