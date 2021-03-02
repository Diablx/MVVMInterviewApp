using BosmalInterviewApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BosmalInterviewApp.Logic.PeopleRepository
{
    public class MockPeopleRepository : IPeopleRepository
    {
        private readonly ICollection<BosmalPerson> people;
        private readonly PersonFaker _personFaker;
        public MockPeopleRepository(PersonFaker PersonFaker)
        {
            _personFaker = PersonFaker;
            people = _personFaker.Generate(1000);
        }

        public ICollection<BosmalPerson> Filter(string name)
        {
            return people.Where(p => p.FirstName.StartsWith(name)).ToList();
        }

        public ICollection<BosmalPerson> GetPeople()
        {
            return people;
        }

        public BosmalPerson GetPersonByID(int id)
        {
            return people.Where(p => p.Pesel == id).FirstOrDefault();
        }
    }
}
