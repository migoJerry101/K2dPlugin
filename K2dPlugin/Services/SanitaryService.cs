using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using K2dPlugin.Features.PipeSum.Dto;
using K2dPlugin.Helper;
using K2dPlugin.Interface;
using Microsoft.VisualBasic.FileIO;

namespace K2dPlugin.Services
{
    public class SanitaryService
    {
        private static readonly List<SanitaryPipeDto> PipeDtoList = new List<SanitaryPipeDto>()
        {
            new SanitaryPipeDto()
            {
                Vent = 0,
                Diameter = 0,
                WasteFixture = 0
            },
            new SanitaryPipeDto()
            {
                Vent = 0,
                Diameter = 2,
                WasteFixture = 0
            },
            new SanitaryPipeDto()
            {
                Vent =24,
                Diameter = 2,
                WasteFixture = 16
            },
            new SanitaryPipeDto()
            {
                Vent =84,
                Diameter = 3,
                WasteFixture = 48
            },
            new SanitaryPipeDto()
            {
                Vent =256,
                Diameter = 4,
                WasteFixture = 172
            },
            new SanitaryPipeDto()
            {
                Vent =1380,
                Diameter = 6,
                WasteFixture = 576
            },
            new SanitaryPipeDto()
            {
                Vent =3600,
                Diameter = 8,
                WasteFixture = 2112
            },
            new SanitaryPipeDto()
            {
                Vent =5600,
                Diameter = 10,
                WasteFixture = 3744
            },
            new SanitaryPipeDto()
            {
                Vent =8400,
                Diameter = 12,
                WasteFixture = 6560
            },
        };

        public IEnumerable<SanitaryPipeDto> GetListOfPipeDto()
        {
            return PipeDtoList.OrderBy(x => x.Diameter);
        }

        public IEnumerable<double> GetPipeSizes()
        {
            var sizes = PipeDtoList
                .OrderBy(x => x.Diameter)
                .Select(x => x.Diameter);

            return sizes;
        }
    }
}
