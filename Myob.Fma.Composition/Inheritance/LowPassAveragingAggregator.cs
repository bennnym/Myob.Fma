using System.Collections.Generic;
using System.Linq;

namespace Myob.Fma.Composition.Inheritance
{
    public class LowPassAveragingAggregator : AveragingAggregator
    {
        public LowPassAveragingAggregator(IEnumerable<Measurement> measurements) : base(measurements)
        {
        }

        protected override IEnumerable<Measurement> FilterMeasurements(IEnumerable<Measurement> measurements)
        {
            return measurements.Where(m => m.X < 100 && m.Y < 100);
        }
    }
}