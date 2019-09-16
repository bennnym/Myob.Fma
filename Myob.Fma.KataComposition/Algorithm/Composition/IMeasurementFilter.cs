using System.Collections.Generic;

namespace Myob.Fma.KataComposition.Algorithm.Composition
{
    public interface IMeasurementFilter
    {
        IEnumerable<Measurement> Filter(IEnumerable<Measurement> measurements);
    }
}