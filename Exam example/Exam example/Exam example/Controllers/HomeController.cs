using business.Services.Abstracts;
using core.Model;
using Exam_example.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Exam_example.Controllers
{
    public class HomeController : Controller
    {
       private readonly ITeamServices _teamServices;

        public HomeController(ITeamServices teamServices)
        {
            _teamServices = teamServices;
        }

        public IActionResult Index()
        {
            List<Team> teams = _teamServices.GetAllTeams(); 
            return View(teams);
        }

        
    }
}
