using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppMVC_Assignment2.Models
{
    public class InMemoryPeopleRepo : IPeopleRepo
    {
        private static List<Person> people = new List<Person>();
        private static int idCounter = 0;
        public bool Create(Person newPerson) 
        {
            Person person = newPerson;

            idCounter++;
            person.PersonID = idCounter;
            people.Add(person);

            return true;
        }
        public List<Person> Read() 
        {
            return people;
        }
        public Person Read(int id) 
        {
            return null;
        }
        public Person Update(Person person) 
        {
            return null;
        }
        public bool Delete(Person person) 
        {
            return true;
        }

    }
}
