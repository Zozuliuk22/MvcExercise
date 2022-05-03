using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Guilds;
using System.Reflection;
using DAL.Interfaces;
using BLL.DTOs;

namespace BLL
{
    public class ScenarioCreatorService : IScenarioCreatorService
    {
        private readonly ThievesGuild _thievesGuild;
        private readonly BeggarsGuild _beggarsGuild;
        private readonly FoolsGuild _foolsGuild;
        private readonly AssassinsGuild _assassinsGuild;

        private Meeting _currentMeeting;
        private List<MethodInfo> _methodsCreateGuild;

        private Player _currentPlayer;
        private string _currentMeetingResult;

        public ScenarioCreatorService(IUnitOfWork unitOfWork)
        {
            _thievesGuild = new ThievesGuild();
            _beggarsGuild = new BeggarsGuild(unitOfWork);
            _foolsGuild = new FoolsGuild(unitOfWork);
            _assassinsGuild = new AssassinsGuild(unitOfWork);

            _methodsCreateGuild = typeof(ScenarioCreatorService)
                .GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(m => m.Name.StartsWith("Create"))
                .ToList();

            _currentPlayer = new Player("Viktor");
        }

        public MeetingDto CreateRandomGuildMeetingOrBar()
        {
            return null;
        }

        public MeetingDto CreateBar()
        {
            return null;
        }

        public MeetingDto CreateRandomGuildMeeting()
        {
            _currentMeeting = (Meeting)_methodsCreateGuild[new Random()
                                                    .Next(0, _methodsCreateGuild.Count)]
                                                    .Invoke(this, null);

            var meetingDto = new MeetingDto()
            {
                WelcomeGuildsWord = _currentMeeting.Guild.WelcomeMessage,
                Color = _currentMeeting.Guild.GuildColor.ToString(),
                GuildName = _currentMeeting.ToString(),
                PlayerCurrentBudget = _currentPlayer.CurrentBudget,
                PlayerIsAlive = _currentPlayer.IsAlive,
                PlayerScore = _currentPlayer.ToString(),
                ResultMeetingMessage = _currentMeetingResult,
                Image = _currentMeeting.Guild.GuildImage
            };

            if (_currentMeeting.Npc is null)
                meetingDto.WelcomeNpcsWord = "";
            else
                meetingDto.WelcomeNpcsWord = _currentMeeting.Npc.ToString();

            return meetingDto;
        }

        private Meeting CreateThievesGuildMeeting()
        {
            _thievesGuild.AddTheft();

            if (_thievesGuild.CurrentNumberThefts > _thievesGuild.MaxNumberThefts)
            {
                var method = _methodsCreateGuild.First(m => m.Name.Contains("Thieves"));
                _methodsCreateGuild.Remove(method);
                CreateRandomGuildMeeting();
                return _currentMeeting;
            }
            else
            {
                _currentMeeting = new Meeting(_thievesGuild);
                return _currentMeeting;
            }
        }

        private Meeting CreateBeggarsGuildMeeting()
        {
            _currentMeeting = new Meeting(_beggarsGuild, _beggarsGuild.GetActiveNpc());
            return _currentMeeting;
        }

        private Meeting CreateAssassinsGuildMeeting()
        {
            _currentMeeting = new Meeting(_assassinsGuild);
            return _currentMeeting;
        }

        private Meeting CreateFoolsGuildMeeting()
        {
            _currentMeeting = new Meeting(_foolsGuild, _foolsGuild.GetActiveNpc());
            return _currentMeeting;
        }

        public void Accept()
        {
            if (_currentMeeting.Guild is ThievesGuild)
                _currentMeetingResult = _thievesGuild.PlayGame(_currentPlayer);

            if (_currentMeeting.Guild is BeggarsGuild)
                _currentMeetingResult = _beggarsGuild.PlayGame(_currentPlayer);

            if (_currentMeeting.Guild is FoolsGuild)
                _currentMeetingResult = _foolsGuild.PlayGame(_currentPlayer);

            /*if (_currentMeeting.Guild is AssassinsGuild)
                _currentResult = _assassinsGuild.PlayGame(_currentPlayer);*/

            //_currentResult = "This is unknown guild.";
        }

        public void Skip()
        {
            _currentMeetingResult = _currentMeeting.Guild.LoseGame(_currentPlayer);

            //if (_currentMeeting.Guild is ThievesGuild)
            //    _currentMeeting.Result = _thievesGuild.LoseGame(_currentPlayer);

            //if (_currentMeeting.Guild is BeggarsGuild)
            //    _currentMeeting.Result = _beggarsGuild.LoseGame(_currentPlayer);

            //if (_currentMeeting.Guild is FoolsGuild)
            //    _currentMeeting.Result = _foolsGuild.LoseGame(_currentPlayer);

            //if (_currentMeeting.Guild is AssassinsGuild)
            //    _currentMeeting.Result = _assassinsGuild.LoseGame(_currentPlayer);

            //_currentResult = "This is unknown guild.";
        }


        public void UseEnteredFee(decimal fee)
        {
            if (_currentMeeting.Guild is AssassinsGuild)
            {
                if (((AssassinsGuild)_currentMeeting.Guild).CheckContract(fee))
                    ((AssassinsGuild)_currentMeeting.Guild).GetActiveNpc();
            }
        }
    }
}
