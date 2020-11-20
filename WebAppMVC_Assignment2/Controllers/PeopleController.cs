using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAppMVC_Assignment2.Models;

namespace WebAppMVC_Assignment2.Controllers
{
    public class PeopleController : Controller
    {
        [HttpGet]
        public IActionResult ViewPeople()
        {
            PeopleService ps = new PeopleService();
            PeopleViewModel peopleViewModel = ps.All();
            return View(peopleViewModel);
        }

        [HttpPost]
        public IActionResult ViewPeople(PeopleViewModel pvm)
        {
            PeopleService ps = new PeopleService();
            PeopleViewModel peopleViewModel = new PeopleViewModel();

            peopleViewModel = ps.FindBy(pvm);

            return View(peopleViewModel);
        }

        [HttpGet]
        public IActionResult AddPeople()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddPeople(CreatePersonViewModel objModel)
        {
            CreatePersonViewModel createPersonModelView = new CreatePersonViewModel();
            createPersonModelView = objModel;
            PeopleService ps = new PeopleService();
            ps.Add(createPersonModelView);

            return RedirectToAction(nameof(ViewPeople));
        }

        public IActionResult DeletePeople(string id)
        {
            PeopleService ps = new PeopleService();
            ps.Remove(Convert.ToInt32(id));

            PeopleViewModel peopleViewModel = ps.All();
            return RedirectToAction(nameof(ViewPeople));
        }
    }
}
