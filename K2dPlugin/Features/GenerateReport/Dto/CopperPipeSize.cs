using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K2dPlugin.Features.GenerateReport.Dto
{
    internal class CopperPipeSize
    {
        public double Nominal { get; set; }
        public double OuterDiameter { get; set; } // OD - Outer Diameter
        public double InnerDiameter { get; set; } // ID - Inner Diameter

        // Constructor to initialize values
        public CopperPipeSize(double nominal, double outerDiameter, double innerDiameter)
        {
            Nominal = nominal;
            OuterDiameter = outerDiameter;
            InnerDiameter = innerDiameter;
        }
    }
}
