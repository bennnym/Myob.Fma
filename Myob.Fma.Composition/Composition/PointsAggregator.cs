using System.Collections.Generic;

namespace Myob.Fma.Composition.Composition
{
    public class PointsAggregator
    {
        private readonly IEnumerable<Measurement> _measurements;
        private readonly IMeasurementFilter _filter;
        private readonly IAggregationStrategy _aggregator;
        
        public PointsAggregator(
            IEnumerable<Measurement> measurements,
            IMeasurementFilter filter,
            IAggregationStrategy aggregator)
        {
            _measurements = measurements;
            _filter = filter;
            _aggregator = aggregator;
        }

        public virtual Measurement Aggregate()
        {
            var measurements = _measurements;
            measurements = _filter.Filter(measurements);
            return _aggregator.Aggregate(measurements);
        }
        
    }
}