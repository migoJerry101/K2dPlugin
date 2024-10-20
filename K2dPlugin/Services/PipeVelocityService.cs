using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using K2dPlugin.Features.GenerateReport.Dto;

namespace K2dPlugin.Services
{
    internal class PipeVelocityService
    {
        public readonly List<CopperPipeSize> PipeSizes = new List<CopperPipeSize>()
        {
            new CopperPipeSize(0.5, 0.625, 0.545),
            new CopperPipeSize(0.75, 0.875, 0.785),
            new CopperPipeSize(1, 1.125, 1.025),
            new CopperPipeSize(1.25, 1.375, 1.265),
            new CopperPipeSize(1.5, 1.625, 1.505),
            new CopperPipeSize(2, 2.125, 1.985),
            new CopperPipeSize(2.5, 2.625, 2.465),
            new CopperPipeSize(3, 3.125, 2.945),
            new CopperPipeSize(4, 4.125, 3.905),
            new CopperPipeSize(6, 6.125, 5.845),
            new CopperPipeSize(8, 8.125, 7.725),
            new CopperPipeSize(10, 10.125, 9.625),
            new CopperPipeSize(12, 12.125, 11.565)
        };

        public readonly List<CopperPipeSize> PipeSizesCpvc = new List<CopperPipeSize>()
        {
            new CopperPipeSize(0.5, 0.84, 0.622),
            new CopperPipeSize(0.75, 1.05, 0.824),
            new CopperPipeSize(1, 1.315, 1.049),
            new CopperPipeSize(1.25, 1.66, 1.38),
            new CopperPipeSize(1.5, 1.9, 1.61),
            new CopperPipeSize(2, 2.375, 2.067),
            new CopperPipeSize(2.5, 2.875, 2.469),
            new CopperPipeSize(3, 3.5, 3.068),
            new CopperPipeSize(4, 4.5, 4.026),
            new CopperPipeSize(6, 6.625, 6.065),
            new CopperPipeSize(8, 8.625, 7.981),
            new CopperPipeSize(10, 10.75, 10.02)
        };

        public readonly List<double> PipeDiameter = new List<double>()
        {
            0.5,
            0.75,
            1,
            1.25,
            1.5,
            2,
            2.5,
            3,
            4,
            6,
            //8
        };

        public readonly List<double> PipeDiameterCpvc = new List<double>()
        {
            0.5,
            0.75,
            1,
            1.25,
            1.5,
            2,
            2.5,
            3,
            4,
            6,
            8,
            10
        };
    }
}
