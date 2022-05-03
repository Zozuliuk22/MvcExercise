using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using PL.Models;
using BLL;
using BLL.DTOs;

namespace PL.Controllers
{
    public class MeetingController : Controller
    {
        private IScenarioCreatorService _scenarioCreator;
        private IMapper _mapper;

        public MeetingController(IScenarioCreatorService scenarioCreator)
        {
            _scenarioCreator = scenarioCreator;
            _mapper = new MapperConfiguration(x => x.CreateMap<MeetingDto, MeetingModel>()).CreateMapper();
        }

        public IActionResult Index()
        {
            var model = new MeetingModel();
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
    }
}
