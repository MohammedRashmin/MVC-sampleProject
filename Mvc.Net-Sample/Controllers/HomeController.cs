using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mvc.Net_Sample.Models;

namespace Mvc.Net_Sample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TrilasDbContext _context;

        public HomeController(ILogger<HomeController> logger, TrilasDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Trials()
        {
            var allTrials = _context.MVC_Trials.ToList();
            var totalExpenses = allTrials.Sum(x => x.Id);

            ViewBag.Trials = totalExpenses;  

            return View(allTrials);
        }

        public IActionResult CreateTrials(int? id)
        {
            if (id != null)
            {
                var trial = _context.MVC_Trials.SingleOrDefault(x => x.Id == id);
                return View(trial);
            }   

            return View();
        }

        public IActionResult DeleteTrial(int id)
        {

            var trialInDb = _context.MVC_Trials.SingleOrDefault(x => x.Id == id);
            _context.MVC_Trials.Remove(trialInDb);
            _context.SaveChanges();
            return RedirectToAction("Trials");
        }
        public IActionResult CreateTrialsForm(Trial model)
        {
            if (model.Id == 0)
            {
                //Create a trial 

                _context.MVC_Trials.Add(model);

            }
            else
            {
                _context.MVC_Trials.Update(model);

            }


            _context.SaveChanges();

            return RedirectToAction("Trials");

        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
