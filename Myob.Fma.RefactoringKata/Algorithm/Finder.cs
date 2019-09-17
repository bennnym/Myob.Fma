using System;
using System.Collections.Generic;
using System.Linq;

namespace Myob.Fma.RefactoringKata.Algorithm
{
    public class AgeComparison
    {
        private readonly List<Person> _people;

        public AgeComparison(List<Person> people)
        {
            _people = people;
        }

        public Couple SearchFor(AgeSearchFilter birthdaySearch)
        {
            if (IsOnlySearchingThroughOneOrLessPeople())
            {
                return new Couple();
            }

            if (IsSearchingForLargestDifferenceOfAges(birthdaySearch))
            {
                return GetLargestDifferenceOfAge();
            }

            return GetSmallestDifferenceOfAge();
        }

        private bool IsOnlySearchingThroughOneOrLessPeople()
        {
            return _people.Count() <= 1;
        }

        private bool IsSearchingForLargestDifferenceOfAges(AgeSearchFilter birthdaySearchCriteria)
        {
            return birthdaySearchCriteria == AgeSearchFilter.LargestDifference;
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
                var ageDifference = GetAgeDifferenceOfPeople(youngestToOldestPeople[i], youngestToOldestPeople[i - 1]);

                if (IsAgeDifferenceSmaller(smallestAgeDifference, ageDifference))
                {
                    smallestAgeDifference = ageDifference;
                    youngest = GetYoungest(youngestToOldestPeople[i], youngestToOldestPeople[i - 1]);
                    eldest = GetEldest(youngestToOldestPeople[i], youngestToOldestPeople[i - 1]);
                }
            }

            return new Couple()
            {
                YoungerPerson = youngest,
                OlderPerson = eldest,
                AgeDifference = smallestAgeDifference
            };
        }

        private TimeSpan GetAgeDifferenceOfPeople(Person firstPerson, Person secondPerson)
        {
            return firstPerson.BirthDate - secondPerson.BirthDate;
        }


        private bool IsAgeDifferenceSmaller(TimeSpan currentMinimum, TimeSpan comparisonValue)
        {
            return comparisonValue < currentMinimum;
        }

        private Person GetYoungest(Person person1, Person person2)
        {
            if (person1.BirthDate < person2.BirthDate)
            {
                return person1;
            }

            return person2;
        }

        private Person GetEldest(Person person1, Person person2)
        {
            if (person1.BirthDate > person2.BirthDate)
            {
                return person1;
            }

            return person2;
        }
    }
}