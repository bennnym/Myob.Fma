using System.Collections.Generic;

namespace Myob.Fma.KataComposition.Algorithm.Composition
{
    public class EmptyFilter : IMeasurementFilter
    {
        public IEnumerable<Measurement> Filter(IEnumerable<Measurement> measurements)
        {
            return measurements;
        }
    }
}