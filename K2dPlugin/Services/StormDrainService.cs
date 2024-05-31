using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using K2dPlugin.Features.PipeSum.Dto;
using K2dPlugin.Helper;
using Microsoft.VisualBasic.FileIO;

namespace K2dPlugin.Services
{
    internal class StormDrainService
    {
        private static readonly List<StormDrainDto> PipeDtoList = new List<StormDrainDto>()
        {
            new StormDrainDto()
            {
                Diameter = 0,
                Area1Hr = 0,
                Area2Hr = 0,
                Area3Hr = 0,
            },
            new StormDrainDto()
            {
                Diameter = 3,
                Area1Hr = 3288,
                Area2Hr = 1644,
                Area3Hr = 1096,
            },
            new StormDrainDto()
            {
                Diameter = 4,
                Area1Hr = 7520,
                Area2Hr = 3760,
                Area3Hr = 2506,
            },
            new StormDrainDto()
            {
                Diameter = 6,
                Area1Hr = 21400,
                Area2Hr = 10700,
                Area3Hr = 7133,
            },
            new StormDrainDto()
            {
                Diameter = 8,
                Area1Hr = 46000,
                Area2Hr = 23000,
                Area3Hr = 15033,
            },
            new StormDrainDto()
            {
                Diameter = 10,
                Area1Hr = 82800,
                Area2Hr = 41400,
                Area3Hr = 27600,
            },
            new StormDrainDto()
            {
                Diameter = 12,
                Area1Hr = 133200,
                Area2Hr = 66600,
                Area3Hr = 44400,
            },
            new StormDrainDto()
            {
                Diameter = 15,
                Area1Hr = 238200,
                Area2Hr = 119000,
                Area3Hr = 79333,
            },
        };

        public IEnumerable<StormDrainDto> GetListOfPipeDto()
        {
            return PipeDtoList.OrderBy(x =>x.Diameter);
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
