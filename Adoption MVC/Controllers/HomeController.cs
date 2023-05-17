using Adoption_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using System.Diagnostics;

namespace Adoption_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public static AdoptionDbContext dbContext = new AdoptionDbContext();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        public IActionResult Index()
        {
            List<Animal> result= dbContext.Animals.ToList();
            return View(result);
        }

        public IActionResult AddAnimal()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddAnimal(Animal a)
        {
            dbContext.Animals.Add(a);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult AdoptAnimal(int Id)
        {
            Animal a = dbContext.Animals.FirstOrDefault(a => a.Id == Id);
            if(a!=null)
            {
              dbContext.Remove(a);
              dbContext.SaveChanges();
            }
            
            return RedirectToAction("Index");
        }

        public IActionResult AnimalDetails(int id)
        {
            Animal result = dbContext.Animals.FirstOrDefault(a=>a.Id == id);
            return View(result);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Testimonials()
        {
            List<Testimonial> testimonials = dbContext.Testimonials.ToList();
            return View(testimonials);
        }

        [HttpPost]
        public IActionResult AddTestimonial(Testimonial t)
        {
            t.DateTimeColumn= DateTime.Now;

            dbContext.Testimonials.Add(t);
            dbContext.SaveChanges();
            return RedirectToAction("Testimonials");
        }

        [HttpPost]
        public IActionResult Results(string breed)
        {
            var animals = dbContext.Animals.Where(a => a.Breed.ToLower().Trim() == breed.ToLower().Trim()).ToList();
            ViewBag.Animals = animals;
            ViewBag.Breed = breed;
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}