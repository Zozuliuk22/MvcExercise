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
        EventDto GetModel();
        void Accept();
        void Skip();
        void UseEnteredFee(decimal fee);

        void Reset();
    }
}
