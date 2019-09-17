using System;
using System.Collections.Generic;
using Xunit;

namespace Myob.Fma.RefactoringKata.Algorithm.Tests
{    
    public class FinderTests
    {
        [Fact]
        public void Returns_Empty_Results_When_Given_Empty_List()
        {
            var list = new List<Person>();
            var finder = new PersonGroup(list);

            var result = finder.SearchForCouple(AgeSearchFilter.SmallestAgeDifference);

            Assert.Null(result.YoungerPerson);
            Assert.Null(result.OlderPerson);
        }

        [Fact]
        public void Returns_Empty_Results_When_Given_One_Person()
        {
            var list = new List<Person>() { sue };
            var finder = new PersonGroup(list);

            var result = finder.SearchForCouple(AgeSearchFilter.SmallestAgeDifference);

            Assert.Null(result.YoungerPerson);
            Assert.Null(result.OlderPerson);
        }

        [Fact]
        public void Returns_Closest_Two_For_Two_People()
        {
            var list = new List<Person>() { sue, greg };
            var finder = new PersonGroup(list);

            var result = finder.SearchForCouple(AgeSearchFilter.SmallestAgeDifference);

            Assert.Same(sue, result.YoungerPerson);
            Assert.Same(greg, result.OlderPerson);
        }

        [Fact]
        public void Returns_Furthest_Two_For_Two_People()
        {
            var list = new List<Person>() { greg, mike };
            var finder = new PersonGroup(list);

            var result = finder.SearchForCouple(AgeSearchFilter.LargestAgeDifference);

            Assert.Same(greg, result.YoungerPerson);
            Assert.Same(mike, result.OlderPerson);
        }

        [Fact]
        public void Returns_Furthest_Two_For_Four_People()
        {
            var list = new List<Person>() { greg, mike, sarah, sue };
            var finder = new PersonGroup(list);

            var result = finder.SearchForCouple(AgeSearchFilter.LargestAgeDifference);

            Assert.Same(sue, result.YoungerPerson);
            Assert.Same(sarah, result.OlderPerson);
        }

        [Fact]
        public void Returns_Closest_Two_For_Four_People()
        {
            var list = new List<Person>() { greg, mike, sarah, sue };
            var finder = new PersonGroup(list);

            var result = finder.SearchForCouple(AgeSearchFilter.SmallestAgeDifference);

            Assert.Same(sue, result.YoungerPerson);
            Assert.Same(greg, result.OlderPerson);
        }

        Person sue = new Person() {Name = "Sue", BirthDate = new DateTime(1950, 1, 1)};
        Person greg = new Person() {Name = "Greg", BirthDate = new DateTime(1952, 6, 1)};
        Person sarah = new Person() { Name = "Sarah", BirthDate = new DateTime(1982, 1, 1) };
        Person mike = new Person() { Name = "Mike", BirthDate = new DateTime(1979, 1, 1) };
    }
}