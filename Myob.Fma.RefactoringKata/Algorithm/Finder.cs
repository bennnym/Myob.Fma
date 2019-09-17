using System;
using System.Collections.Generic;
using System.Linq;

namespace Myob.Fma.RefactoringKata.Algorithm
{
    public class Finder
    {
        private readonly List<Person> _people;

        public Finder(List<Person> people)
        {
            _people = people;
        }

        public Couple Find(BirthdaySearch birthdaySearch)
        {
            var birthdayComparisonsOfPeople = new List<Couple>();

            if (IsSearchingForLargestDifference(birthdaySearch))
            {
                return GetLargestDifferenceOfPersonsBirthdays();
            }
            else
            {
                return GetSmallestDifferenceOfPersonsBirthdays();
            }

            for (var i = 0; i < _people.Count - 1; i++) // goes over the entire list
            {
                for (var j = i + 1; j < _people.Count; j++) // compares the others to the above
                {
                    var results = new Couple();

                    if (_people[i].BirthDate < _people[j].BirthDate)
                    {
                        results.YoungerPerson = _people[i];
                        results.OlderPerson = _people[j];
                    }
                    else
                    {
                        results.YoungerPerson = _people[j];
                        results.OlderPerson = _people[i];
                    }

                    results.DateDifference = results.OlderPerson.BirthDate - results.YoungerPerson.BirthDate;
                    
                    birthdayComparisonsOfPeople.Add(results);
                }
            }

            if (IsListEmpty(birthdayComparisonsOfPeople))
            {
                return new Couple();
            }

            Couple searchFindings = birthdayComparisonsOfPeople[0];
            
            foreach (var coupleComparison in birthdayComparisonsOfPeople)
            {
                switch (birthdaySearch)
                {
                    case BirthdaySearch.SmallestDifference:
                        if (coupleComparison.DateDifference < searchFindings.DateDifference)
                        {
                            searchFindings = coupleComparison;
                        }

                        break;
                }
            }
            
            return searchFindings;
        }

        private bool IsSearchingForLargestDifference(BirthdaySearch birthdaySearchCriteria)
        {
            return birthdaySearchCriteria == BirthdaySearch.LargestDifference;
        }
        private bool IsListEmpty(IEnumerable<Couple> searchFindings)
        {
            return searchFindings.Any() == false;
        }

        private Couple GetLargestDifferenceOfPersonsBirthdays()
        {
            var orderedPeople = _people.OrderBy(d => d.BirthDate).ToList();
            var youngest = orderedPeople.First();
            var eldest = orderedPeople.Last();

            return new Couple()
            {
                YoungerPerson = youngest,
                OlderPerson = eldest,
                DateDifference = eldest.BirthDate - youngest.BirthDate
            };
        }

        private Couple GetSmallestDifferenceOfPersonsBirthdays()
        {
            var orderedPeople = _people.OrderBy(d => d.BirthDate).ToList();
        }
    }
}