using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppMVC_Assignment2.Models
{
    interface IPeopleRepo
    {
        public bool Create(Person person);
        public List<Person> Read();
        public Person Read(int id);
        public Person Update(Person person);
        public bool Delete(Person person);
    }
}
