using Microsoft.AspNetCore.Mvc;
using PL.Models;
using BLL;

namespace PL.Controllers
{
    public class MeetingController : Controller
    {
        private IScenarioCreator _scenarioCreator;

        public MeetingController(IScenarioCreator scenarioCreator)
        {
            _scenarioCreator = scenarioCreator;
        }

        public IActionResult Index()
        {
            var model = new MeetingModel();
            var item = _scenarioCreator.CreateRandomGuildMeeting();
            model.WelcomeNpcsWord = item.WelcomeNpcsWord;
            model.WelcomeGuildsWord = item.WelcomeGuildsWord;
            model.Color = item.Color;
            model.GuildName = item.GuildName;
            return View(model);
        }

        public IActionResult Accept()
        {
            return RedirectToAction("Index");
        }

        public IActionResult Skip()
        {
            return RedirectToAction("Index");
        }
    }
}
