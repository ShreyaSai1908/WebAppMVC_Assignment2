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
        public PeopleViewModel FindBy(PeopleViewModel pvm)
        {
            PeopleViewModel peopleViewModel = new PeopleViewModel();
            InMemoryPeopleRepo pr = new InMemoryPeopleRepo();

            List<Person> searchedPeople = new List<Person>();
            peopleViewModel.AllPeople = pr.Read();

            foreach (Person person in peopleViewModel.AllPeople)
            {
                if ((person.FirstName).Contains(pvm.Search) ||
                     (person.LastName).Contains(pvm.Search) ||
                      (person.Address).Contains(pvm.Search))
                { 
                     searchedPeople.Add(person);
                }
            }

            peopleViewModel.AllPeople = searchedPeople;

            return peopleViewModel;
        }
        public Person FindBy(int findID)
        {
            InMemoryPeopleRepo pr = new InMemoryPeopleRepo();

            List<Person> allPeople = new List<Person>();
            allPeople = pr.Read();

            Person searchedPerson = new Person();

            foreach (Person person in allPeople)
            {
                if (person.PersonID== findID)
                {
                    searchedPerson = person;
                }
            }

            return searchedPerson;
        }
        public bool Edit(int id, Person person)
        {
            return true;
        }
        public bool Remove(int findID) 
        {
            bool result = false;
            InMemoryPeopleRepo pr = new InMemoryPeopleRepo();
                        
            Person removePerson = pr.Read(findID);
            result = pr.Delete(removePerson);            
            return result;
        }
    }
}
