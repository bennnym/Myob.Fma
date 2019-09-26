using System;

namespace Myob.Fma.RefactoringKata.Algorithm
{
    public class SearchResult
    {
        public Person YoungerPerson { get; set; }
        public Person OlderPerson { get; set; }
        public TimeSpan AgeDifference { get; set; }
    }
}