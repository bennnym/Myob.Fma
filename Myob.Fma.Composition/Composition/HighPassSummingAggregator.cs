using System.Collections.Generic;

namespace Myob.Fma.Composition.Composition
{
    public class HighPassSummingAggregator // I added this entire class
    {
        private readonly IEnumerable<Measurement> _measurements;
        private readonly IMeasurementFilter _filter = new HighPassFilter();
        private readonly IAggregationStrategy _aggregator = new SummingStrategy();
 
        public HighPassSummingAggregator(IEnumerable<Measurement> measurements)
        {
            _measurements = measurements;
        }
        
        public virtual Measurement Aggregate()
        {
            var measurements = _measurements;
            measurements = _filter.Filter(measurements);
            return _aggregator.Aggregate(measurements);
        }
        
        
    }
}