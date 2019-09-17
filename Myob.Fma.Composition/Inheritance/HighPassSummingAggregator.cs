using System.Collections.Generic;
using System.Linq;

namespace Myob.Fma.Composition.Inheritance
{
    /// <summary>
    /// Should filter out measurements with an X or Y that are less than or equal to 2
    /// You'll need to inherit and override methods from other classes in the inheritance folder
    /// </summary>
    public class HighPassSummingAggregator : PointsAggregator
    {
        private readonly IEnumerable<Measurement> _measurements;

        public HighPassSummingAggregator(IEnumerable<Measurement> measurements) : base(measurements)
        {
            _measurements = measurements;
        }

        protected override IEnumerable<Measurement> FilterMeasurements(IEnumerable<Measurement> measurements)
        {
            return measurements.Where(p => p.X > 2 && p.Y > 2); // this is what I added
        }

        public override Measurement Aggregate() // this is what I added
        {
            var filteredMeasurements = FilterMeasurements(_measurements).ToList();

            return AggregateMeasurements(filteredMeasurements);
        }

        protected override Measurement AggregateMeasurements(IEnumerable<Measurement> measurements)
        {
            return new Measurement {X = measurements.Sum(m => m.X), Y = measurements.Sum(m => m.Y)};
        }
    }    
}