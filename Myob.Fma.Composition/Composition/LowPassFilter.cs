using System.Collections.Generic;
using System.Linq;

namespace Myob.Fma.Composition.Composition
{
    public class LowPassFilter : IMeasurementFilter
    {
        public IEnumerable<Measurement> Filter(IEnumerable<Measurement> measurements)
        {
            return measurements.Where(m => m.X < 100 & m.Y < 100);
        }
    }
}