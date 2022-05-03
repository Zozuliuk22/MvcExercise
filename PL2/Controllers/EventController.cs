using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using PL.Models;
using BLL;
using BLL.DTOs;

namespace PL.Controllers
{
    public class EventController : Controller
    {
        private IScenarioCreatorService _scenarioCreator;
        private IMapper _mapper;

        public EventController(IScenarioCreatorService scenarioCreator)
        {
            _scenarioCreator = scenarioCreator;
            _mapper = new MapperConfiguration(x => x.CreateMap<MeetingDto, EventModel>()).CreateMapper();
        }

        public IActionResult Index()
        {
            var model = new EventModel();
            var item = _scenarioCreator.GetModel();
            model = _mapper.Map(item, model);
            return View(model);
        }

        public IActionResult Accept()
        {            
            _scenarioCreator.Accept();
            return RedirectToAction("Index");
        }

        public IActionResult Skip()
        {
            _scenarioCreator.Skip();
            return RedirectToAction("Index");
        }

        public IActionResult EnterFee(EventModel model)
        {
            _scenarioCreator.UseEnteredFee(model.EnteredFee);
            _scenarioCreator.Accept();
            return RedirectToAction("Index");
        }
    }
}
