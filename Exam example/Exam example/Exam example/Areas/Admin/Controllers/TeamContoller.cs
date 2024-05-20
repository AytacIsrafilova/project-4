using business.Exceptions;
using business.Services.Abstracts;
using core.Model;
using data.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Exam_example.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class TeamContoller : Controller
    {
        private readonly ITeamServices _teamServices;

        public TeamContoller(ITeamServices teamServices)
        {
            _teamServices = teamServices;
        }

        public IActionResult Index()
        {
            var teams = _teamServices.GetAllTeams();
            return View(teams);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Team team)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                _teamServices.AddTeam(team);
            }
            catch (DublicateTeamException ex)
            {

                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View();
            }
            catch (Exception ex)
            {
                throw;
            }
            
            return RedirectToAction("Index");
        }

    }
}
