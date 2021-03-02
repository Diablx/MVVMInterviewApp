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
            //DI for FakeDB
            _personFaker = PersonFaker;
            //Load people with fake data
            people = _personFaker.Generate(1000);
        }

        /// <summary>
        /// Get people by given filter
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public ICollection<BosmalPerson> Filter(string name)
        {
            return people.Where(p => p.FirstName.StartsWith(name)).ToList();
        }

        /// <summary>
        /// Get People from fake db
        /// </summary>
        /// <returns></returns>
        public ICollection<BosmalPerson> GetPeople()
        {
            return people;
        }

        /// <summary>
        /// Get person by id from collection
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BosmalPerson GetPersonByID(int id)
        {
            return people.Where(p => p.Pesel == id).FirstOrDefault();
        }
    }
}
