using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using K2dPlugin.Features.PipeSum.Dto;

namespace K2dPlugin.Interface
{
    public interface ISanitary
    {
        IEnumerable<SanitaryPipeDto> GetListOfPipeDto();
        IEnumerable<double> GetPipeSizes();
        IEnumerable<double> GetPipeVents();
        IEnumerable<double> GetPipeWasteFixture();

    }
}
