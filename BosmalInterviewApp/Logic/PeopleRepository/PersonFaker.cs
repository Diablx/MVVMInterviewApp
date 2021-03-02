using Bogus;
using BosmalInterviewApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BosmalInterviewApp.Logic.PeopleRepository
{
    public class PersonFaker : Faker<BosmalPerson>
    {
        public PersonFaker()
        {
            StrictMode(true);
            RuleFor(p => p.Pesel, f => f.IndexFaker);
            RuleFor(p => p.FirstName, f => f.Person.FirstName);
            RuleFor(p => p.LastName, f => f.Person.LastName);
            RuleFor(p => p.Age, f => f.Random.Int(15,70));
        }
    }
}
