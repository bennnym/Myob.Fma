using System.Collections.Generic;

namespace Myob.Fma.KataComposition.Algorithm.Composition
{
    public interface IAggregationStrategy
    {
        Measurement Aggregate(IEnumerable<Measurement> measurements);
    }
}