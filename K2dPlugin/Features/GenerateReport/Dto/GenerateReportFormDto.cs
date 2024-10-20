using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K2dPlugin.Features.GenerateReport.Dto
{
    public class GenerateReportFormDto
    {
        public string SystemType { get; set; } = string.Empty;
        public string SystemLoss { get; set; } = string.Empty;
        public double TotalFixtureUnit { get; set; }
        public double ConvertedFuToGpm { get; set; }

        public double PressureCityHigh { get; set; }
        public double PressureCityLow { get; set; }
        public double CityElevation { get; set; }

        public double PressurePropertyHigh { get; set; }
        public double PressurePropertyLow { get; set; }
        public double PropertyElevation { get; set; }


        public double WaterMeterSize { get; set; }
        public double WaterMeterSizeLoss { get; set; }
        public double SubMeterFrictionLoss { get; set; }
        public double FiltrationFrictionLoss { get; set; }
        public double RequiredFixturePressure { get; set; }
        public double BuildingHeight { get; set; }
        public double PressureLossTmv { get; set; }

        public string MakeAndModelTmv { get; set; } = string.Empty;
        public string MakeModelGpm { get; set; } = string.Empty;
        public string MakeModel { get; set; } = string.Empty;
        public double DevelopedPipeLength { get; set; }

        public string SarDate { get; set; }
        public string Source { get; set; }
        public string ContactInfo { get; set; }

        public double ManualPsi { get; set; }

    }
}
