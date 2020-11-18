using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppMVC_Assignment2.Models
{
    public class PeopleService : IPeopleService
    {
        public bool Add(CreatePersonViewModel modelData)
        {
            InMemoryPeopleRepo pr = new InMemoryPeopleRepo();
            bool isPersonAdded=pr.Create(modelData.Person);

            return isPersonAdded;
        }

        public PeopleViewModel All()
        {
            PeopleViewModel peopleViewModel = new PeopleViewModel();
            InMemoryPeopleRepo pr = new InMemoryPeopleRepo();
            peopleViewModel.AllPeople=pr.Read();
            return peopleViewModel;
        }
        public PeopleViewModel FindBy(PeopleViewModel search)
        {
            return null;
        }
        public Person FindBy(int id)
        {
            return null;
        }
        public bool Edit(int id, Person person)
        {
            return true;
        }
        public bool Remove(int id) 
        {
            return true;
        }
    }
}
