using BosmalInterviewApp.Logic.PeopleRepository;
using BosmalInterviewApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace BosmalInterviewApp.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        readonly IPeopleRepository _peopleRepository;
        public MainViewModel(IPeopleRepository peopleRepository)
        {
            _peopleRepository = peopleRepository;
            People = _peopleRepository.GetPeople();
        }

        public IEnumerable<BosmalPerson> _people { get; private set; }
        public IEnumerable<BosmalPerson> People
        {
            get => _people;
            set
            {
                if (_people != value)
                {
                    _people = value;
                }
                OnPropertyChanged(nameof(People));
            }
                
        }

        public string _filterName { get; set; }

        public string FilterName
        {
            get => _filterName;
            set
            {
                if (_filterName != value)
                {
                    _filterName = value;
                    People = _peopleRepository.Filter(FilterName);
                }
            }
        }

        public BosmalPerson _selectedPerson;
        public BosmalPerson SelectedPerson
        {
            get => _selectedPerson;
            set
            {
                if (_selectedPerson != value)
                {
                    _selectedPerson = value;
                }
                OnPropertyChanged(nameof(SelectedPerson));
            }
        }

    }
}
