using BosmalInterviewApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BosmalInterviewApp.Logic.PeopleRepository
{
    public interface IPeopleRepository
    {
        ICollection<BosmalPerson> GetPeople();
        ICollection<BosmalPerson> Filter(string name);
    }
}
