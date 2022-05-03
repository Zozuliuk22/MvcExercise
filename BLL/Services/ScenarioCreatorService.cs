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
        private Pub _pub;

        private bool _isPub;
        private string _currentMeetingResult;

        public ScenarioCreatorService(IUnitOfWork unitOfWork)
        {
            _thievesGuild = new ThievesGuild();
            _beggarsGuild = new BeggarsGuild(unitOfWork);
            _foolsGuild = new FoolsGuild(unitOfWork);
            _assassinsGuild = new AssassinsGuild(unitOfWork);
            _pub = new Pub();

            _methodsCreateGuild = typeof(ScenarioCreatorService)
                .GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(m => m.Name.StartsWith("Create"))
                .ToList();

            _currentPlayer = new Player("Viktor");
        }

        private void CreateRandomGuildMeetingOrBar()
        {            
            if(_currentPlayer.CurrentBeers < _currentPlayer.MaxBeers)
                _isPub = new Random().Next(2) == 0;
            else
                _isPub = false;

            _currentMeeting = CreateRandomGuildMeeting();
        }

        public MeetingDto GetModel()
        {
            CreateRandomGuildMeetingOrBar();

            var meetingDto = new MeetingDto();

            if (_isPub)
            {                
                meetingDto.Name = _pub.ToString();
                meetingDto.WelcomeWord = _pub.WelcomeMessage;               
                meetingDto.Color = _pub.Color.ToString();
                meetingDto.Image = _pub.Image;
                meetingDto.PlayerScore = _currentPlayer.ToString();
                meetingDto.PlayerIsAlive = _currentPlayer.IsAlive;
                meetingDto.PlayerCurrentBudget = _currentPlayer.CurrentBudget;
                meetingDto.PlayerCurrentBeers = _currentPlayer.CurrentBeers;
                meetingDto.ResultMeetingMessage = _currentMeetingResult;
            }
            else
            {
                meetingDto.Name = _currentMeeting.Guild.ToString();
                meetingDto.WelcomeWord = _currentMeeting.Guild.WelcomeMessage;
                meetingDto.WelcomeWord += _currentMeeting.Npc is not null ? _currentMeeting.Npc.ToString() : String.Empty;
                meetingDto.Color = _currentMeeting.Guild.GuildColor.ToString();
                meetingDto.Image = _currentMeeting.Guild.GuildImage;
                meetingDto.PlayerScore = _currentPlayer.ToString();
                meetingDto.PlayerIsAlive = _currentPlayer.IsAlive;
                meetingDto.PlayerCurrentBudget = _currentPlayer.CurrentBudget;
                meetingDto.PlayerCurrentBeers = _currentPlayer.CurrentBeers;
                meetingDto.ResultMeetingMessage = _currentMeetingResult;
            }

            return meetingDto;
        }

        private Meeting CreateRandomGuildMeeting()
        {
            return (Meeting)_methodsCreateGuild[new Random()
                                                    .Next(0, _methodsCreateGuild.Count)]
                                                    .Invoke(this, null);           
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
            if (_isPub)
                _currentMeetingResult = _pub.PlayGame(_currentPlayer);
            else
            {
                if (_currentMeeting.Guild is ThievesGuild)
                    _currentMeetingResult = _thievesGuild.PlayGame(_currentPlayer);

                if (_currentMeeting.Guild is BeggarsGuild)
                    _currentMeetingResult = _beggarsGuild.PlayGame(_currentPlayer);

                if (_currentMeeting.Guild is FoolsGuild)
                    _currentMeetingResult = _foolsGuild.PlayGame(_currentPlayer);

                /*if (_currentMeeting.Guild is AssassinsGuild)
                    _currentResult = _assassinsGuild.PlayGame(_currentPlayer);*/
            }

            //_currentResult = "This is unknown guild.";
        }

        public void Skip()
        {
            if(_isPub)
                _currentMeetingResult = _pub.LoseGame(_currentPlayer);
            _currentMeetingResult = _currentMeeting.Guild.LoseGame(_currentPlayer);
            
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
