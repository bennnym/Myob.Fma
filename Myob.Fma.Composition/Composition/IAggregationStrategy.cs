using System.Collections.Generic;

namespace Myob.Fma.Composition.Composition
{
    public interface IAggregationStrategy
    {
        Measurement Aggregate(IEnumerable<Measurement> measurements);
    }
}