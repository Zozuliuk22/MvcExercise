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
    public class ScenarioCreator : IScenarioCreator
    {
        private readonly ThievesGuild _thievesGuild;
        private readonly BeggarsGuild _beggarsGuild;
        private readonly FoolsGuild _foolsGuild;
        private readonly AssassinsGuild _assassinsGuild;

        private Meeting _currentMeeting;
        private List<MethodInfo> _methodsCreateGuild;

        private Player _currentPlayer;
        private int test = 0;


        public ScenarioCreator(IUnitOfWork unitOfWork)
        {
            _thievesGuild = new ThievesGuild();
            _beggarsGuild = new BeggarsGuild(unitOfWork);
            _foolsGuild = new FoolsGuild(unitOfWork);
            _assassinsGuild = new AssassinsGuild(unitOfWork);

            _methodsCreateGuild = typeof(ScenarioCreator)
                .GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(m => m.Name.StartsWith("Create"))
                .ToList();

            _currentPlayer = new Player("Viktor");
        }

        /// <summary>
        /// Initialise all exist guilds by data from Json files in the InputData folder.
        /// </summary>
        //public void InitialiseAllGuilds()
        //{
        //    var dataLoader = new DataLoader();

        //    _assassinsGuild.CreateNpcs(
        //        dataLoader.LoadNpcsFromJson(
        //            Paths.pathToAssassinsJsonFile));

        //    _beggarsGuild.CreateNpcs(
        //        dataLoader.LoadNpcsFromJson(
        //            Paths.pathToBeggarsJsonFile));

        //    _foolsGuild.CreateNpcs(
        //        dataLoader.LoadNpcsFromJson(
        //            Paths.pathToFoolsJsonFile));
        //}

        /// <summary>
        /// Create a meeting with the random Guild.
        /// </summary>
        /// <returns>The created Meeting object.</returns>
        public MeetingDto CreateRandomGuildMeeting()
        {
            _currentMeeting = (Meeting)_methodsCreateGuild[new Random()
                                                    .Next(0, _methodsCreateGuild.Count)]
                                                    .Invoke(this, null);

            var meetingDto = new MeetingDto()
            {
                WelcomeGuildsWord = _currentMeeting.Guild.WelcomeMessage,
                Color = _currentMeeting.Guild.GuildColor.ToString(),                
                GuildName = _currentMeeting.Guild.ToString()
            };

            if (_currentMeeting.Npc is null)
                meetingDto.WelcomeNpcsWord = "";
            else
                meetingDto.WelcomeNpcsWord = _currentMeeting.Npc.ToString();

            test = 12;

            return meetingDto;
        }

        /// <summary>
        /// Create a meeting with the Thieves' Guild.
        /// </summary>
        /// <returns>The created Meeting object with the Thieves' Guild.</returns>
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

        /// <summary>
        /// Create a meeting with the Beggars' Guild.
        /// </summary>
        /// <returns>The created Meeting object with the Beggars' Guild.</returns>
        private Meeting CreateBeggarsGuildMeeting()
        {
            _currentMeeting = new Meeting(_beggarsGuild, _beggarsGuild.GetActiveNpc());
            return _currentMeeting;
        }

        /// <summary>
        /// Create a meeting with the Assassins' Guild.
        /// </summary>
        /// <returns>The created Meeting object with the Assassins' Guild.</returns>
        private Meeting CreateAssassinsGuildMeeting()
        {
            _currentMeeting = new Meeting(_assassinsGuild);
            return _currentMeeting;
        }

        /// <summary>
        /// Create a meeting with the Fools' Guild.
        /// </summary>
        /// <returns>The created Meeting object with the Fools' Guild.</returns>
        private Meeting CreateFoolsGuildMeeting()
        {
            _currentMeeting = new Meeting(_foolsGuild, _foolsGuild.GetActiveNpc());
            return _currentMeeting;
        }

        /// <summary>
        /// Accept the current meeting with some Guild and play a game with them.
        /// </summary>
        /// <param name="player">The Player object.</param>
        /// <returns>The text-result of accepting a meeting with the exist guild.</returns>
        public string Accept(Player player)
        {
            if (_currentMeeting.Guild is ThievesGuild)
                return _thievesGuild.PlayGame(player);

            if (_currentMeeting.Guild is BeggarsGuild)
                return _beggarsGuild.PlayGame(player);

            if (_currentMeeting.Guild is FoolsGuild)
                return _foolsGuild.PlayGame(player);

            if (_currentMeeting.Guild is AssassinsGuild)
                return _assassinsGuild.PlayGame(player);

            return "This is unknown guild.";
        }

        /// <summary>
        /// Skip the current meeting with some Guild.
        /// </summary>
        /// <param name="player">The Player object.</param>
        /// <returns>The text-result of skipping a meeting with the exist guild.</returns>
        public string Skip(Player player)
        {
            if (_currentMeeting.Guild is ThievesGuild)
                return _thievesGuild.LoseGame(player);

            if (_currentMeeting.Guild is BeggarsGuild)
                return _beggarsGuild.LoseGame(player);

            if (_currentMeeting.Guild is FoolsGuild)
                return _foolsGuild.LoseGame(player);

            if (_currentMeeting.Guild is AssassinsGuild)
                return _assassinsGuild.LoseGame(player);

            return "This is unknown guild.";
        }

        /// <summary>
        /// Use the entered fee by a player.
        /// If the current meeting with a guild that is the Assassins' Guild, try to get a NPC for the meeting.
        /// </summary>
        /// <param name="fee">The entered fee by a player.</param>
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
