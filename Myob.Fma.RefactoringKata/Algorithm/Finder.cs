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
            if (IsOnlySearchingThroughOneOrLessPeople())
            {
                return new Couple();
            }

            if (IsSearchingForLargestDifference(birthdaySearch))
            {
                return GetLargestDifferenceOfAge();
            }

            return GetSmallestDifferenceOfAge();
        }

        private bool IsOnlySearchingThroughOneOrLessPeople()
        {
            return _people.Count() <= 1;
        }

        private bool IsSearchingForLargestDifference(BirthdaySearch birthdaySearchCriteria)
        {
            return birthdaySearchCriteria == BirthdaySearch.LargestDifference;
        }

        private bool IsListEmpty(IEnumerable<Couple> searchFindings)
        {
            return searchFindings.Any() == false;
        }

        private Couple GetLargestDifferenceOfAge()
        {
            var youngestToOldestPeople = _people.OrderBy(d => d.BirthDate).ToList();
            var youngest = youngestToOldestPeople.First();
            var eldest = youngestToOldestPeople.Last();

            return new Couple()
            {
                YoungerPerson = youngest,
                OlderPerson = eldest,
                AgeDifference = eldest.BirthDate - youngest.BirthDate
            };
        }

        private Couple GetSmallestDifferenceOfAge()
        {
            var youngestToOldestPeople = _people.OrderBy(d => d.BirthDate).ToList();
            var smallestAgeDifference = TimeSpan.MaxValue;
            var youngest = new Person();
            var eldest = new Person();

            for (int i = 1; i < youngestToOldestPeople.Count; i++)
            {
                var ageDifference = youngestToOldestPeople[i].BirthDate - youngestToOldestPeople[i - 1].BirthDate;

                if (IsAgeDifferenceSmaller(smallestAgeDifference, ageDifference))
                {
                    smallestAgeDifference = ageDifference;
                    youngest = GetYoungest(youngestToOldestPeople[i], youngestToOldestPeople[i - 1]);
                    eldest = GetEldests(youngestToOldestPeople[i], youngestToOldestPeople[i - 1]);
                }
            }

            return new Couple()
            {
                YoungerPerson = youngest,
                OlderPerson = eldest,
                AgeDifference = eldest.BirthDate - youngest.BirthDate
            };
        }


        private bool IsAgeDifferenceSmaller(TimeSpan currentMinimum, TimeSpan comparingSpan)
        {
            return currentMinimum > comparingSpan;
        }

        private Person GetYoungest(Person person1, Person person2)
        {
            if (person1.BirthDate < person2.BirthDate)
            {
                return person1;
            }

            return person2;
        }

        private Person GetEldests(Person person1, Person person2)
        {
            if (person1.BirthDate > person2.BirthDate)
            {
                return person1;
            }

            return person2;
        }
    }
}