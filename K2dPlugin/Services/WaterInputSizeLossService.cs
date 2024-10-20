using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using K2dPlugin.Features.GenerateReport.Dto;

namespace K2dPlugin.Services
{
    public class WaterInputSizeLossService
    {
        public static readonly List<WaterInputSizeLossDto> DiameterLossList = new List<WaterInputSizeLossDto>()
        {
            new WaterInputSizeLossDto() { Diameter = 1, Loss = 3 },
            new WaterInputSizeLossDto() { Diameter = 1.5, Loss = 0.9 },
            new WaterInputSizeLossDto() { Diameter = 2, Loss = 0.3 },
            new WaterInputSizeLossDto() { Diameter = 3, Loss = 0.2 },
            new WaterInputSizeLossDto() { Diameter = 4, Loss = 3.9 },
            new WaterInputSizeLossDto() { Diameter = 6, Loss = 2.4 },
            new WaterInputSizeLossDto() { Diameter = 8, Loss = 2.7 },
            new WaterInputSizeLossDto() { Diameter = 10, Loss = 2.2 },
        };

        public IEnumerable<double> GetDiameters()
        {
            var diameters = DiameterLossList.Select(x => x.Diameter);

            return diameters;
        }

        public double GetLossByDiameter(double dia)
        {
            var dto = DiameterLossList.SingleOrDefault(x => x.Diameter == dia);

            return dto.Loss;
        }
    }
}
