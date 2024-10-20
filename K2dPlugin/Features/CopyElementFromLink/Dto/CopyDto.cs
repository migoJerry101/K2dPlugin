using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;

namespace K2dPlugin.Features.CopyElementFromLink.Dto
{
    public class CopyDto
    {
        public IEnumerable<Element> Elements { get; set; }
        public Document Doc { get; set; }
    }
}
