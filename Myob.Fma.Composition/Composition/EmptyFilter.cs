using System.Collections.Generic;

namespace Myob.Fma.Composition.Composition
{
    public class EmptyFilter : IMeasurementFilter
    {
        public IEnumerable<Measurement> Filter(IEnumerable<Measurement> measurements)
        {
            return measurements;
        }
    }
}