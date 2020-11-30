using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAppMVC_Assignment2.Models;

namespace WebAppMVC_Assignment2.Controllers
{
    public class PeopleOneViewController : Controller
    {
        private static PeopleService ps = new PeopleService();
        private static PeopleViewModel peopleViewModel;

        [HttpGet]
        public IActionResult Add_View_People()
        {
            if (peopleViewModel == null)
            {
                peopleViewModel = ps.All();
            }
            return View(peopleViewModel);
        }


        [HttpPost]
        public IActionResult Add_View_People(PeopleViewModel objModel)
        {
            CreatePersonViewModel createPersonModelView = new CreatePersonViewModel();
            if (objModel.AddPerson != null)
            {
                createPersonModelView = objModel.AddPerson;
                ps.Add(createPersonModelView);
            }

            if (objModel.Search != null)
            {
                peopleViewModel = ps.FindBy(objModel);
            }

            return RedirectToAction(nameof(Add_View_People));
        }

        public IActionResult DeletePeople(string id)
        {
            ps.Remove(Convert.ToInt32(id));
            peopleViewModel = ps.All();
            return RedirectToAction(nameof(Add_View_People));
        }
    }
}
