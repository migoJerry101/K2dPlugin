using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K2dPlugin.Features.GenerateReport.Dto
{
    internal class WaterDemandTotalDto
    {
        public double FixtureUnitTotal { get; set; }
        public int FixtureUnitTotalGpm { get; set; }
        public double OtherWaterRequiredFu { get; set; }
        public int OtherWaterRequiredGpm { get; set; }
        public double ExistWaterRequiredFu { get; set; }
        public int ExistWaterRequiredGpm { get; set; }
    }
}
