using System.Collections.Generic;

namespace Myob.Fma.Composition.Composition
{
    public interface IMeasurementFilter
    {
        IEnumerable<Measurement> Filter(IEnumerable<Measurement> measurements);
    }
}