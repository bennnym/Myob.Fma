using System.Collections.Generic;
using System.Linq;

namespace Myob.Fma.Composition.Composition
{
    public class AveragingStrategy : IAggregationStrategy
    {
        public Measurement Aggregate(IEnumerable<Measurement> measurements)
        {
            return new Measurement
                       {
                           X = (int)measurements.Average(m => m.X),
                           Y = (int)measurements.Average(m => m.Y)
                       };
        }
    }
}