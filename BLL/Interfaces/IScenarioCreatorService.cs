using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTOs;

namespace BLL
{
    public interface IScenarioCreatorService
    {
        MeetingDto CreateRandomGuildMeeting();
        void Accept();
        void Skip();
        void UseEnteredFee(decimal fee);
    }
}
