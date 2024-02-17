using CST_323_Milestone.Models;
using CST_323_Milestone.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CST_323_Milestone.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private DataAccessDAO _dataAccessService;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _dataAccessService = new DataAccessDAO();
        }

        public IActionResult Index()
        {
            return View("Index");
        }

        public IActionResult Superheroes()
        {
            return View("Superheroes", _dataAccessService.Read());
        }

        public IActionResult Create()
        {
            return View("CreateSuperhero");
        }

        /// <summary>
        /// Creating a superhero and add it to the database
        /// </summary>
        /// <param name="superhero"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateSuperhero(SuperheroModel superhero)
        {
            bool success = _dataAccessService.Create(superhero);
            if (success)
            {
                return RedirectToAction("Superheroes"); // Success!
            }
            else
            {
                return View("CreateSuperhero"); // Faulure!
            }
        }


        public IActionResult Update(SuperheroModel superhero)
        {
            return View("UpdateSuperhero", superhero);
        }

        /// <summary>
        /// Update a particular superhero from the database
        /// </summary>
        /// <param name="superhero"></param>
        /// <returns></returns>
        public IActionResult UpdateSuperhero(SuperheroModel superhero)
        {
            _dataAccessService.Update(superhero);
            return RedirectToAction("Superheroes", _dataAccessService.Read());
        }

        /// <summary>
        /// Delete a superhero from the database by their id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult DeleteSuperhero(SuperheroModel superhero)
        {
            bool success = _dataAccessService.Delete(superhero.SuperheroID);

            if(success)
            {
                return RedirectToAction("Superheroes"); // Success!
            }
            else
            {
                return RedirectToAction("Index"); // Faulure!
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}