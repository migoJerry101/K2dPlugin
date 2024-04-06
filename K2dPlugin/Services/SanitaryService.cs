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
        private static List<SanitaryPipeDto> _pipeDtoList;

        public IEnumerable<SanitaryPipeDto> GetListOfPipeDto()
        {
            const string partial = "\\Addins\\2021\\Resources\\Lookup\\WASTE_SIZING.csv";
            var filePath = CsvPathGenerator.GetCsvFilePath();
            _pipeDtoList = LoadPipeDtoFromCsv(filePath + partial);

            return _pipeDtoList;
        }

        public IEnumerable<double> GetPipeSizes()
        {
            const string partial = "\\Addins\\2021\\Resources\\Lookup\\WASTE_SIZING.csv";
            var filePath = CsvPathGenerator.GetCsvFilePath();
            _pipeDtoList = LoadPipeDtoFromCsv(filePath + partial);
            var sizes = _pipeDtoList.Select(x => x.Diameter);
            
            return sizes;
        }

        private static List<SanitaryPipeDto> LoadPipeDtoFromCsv(string filePath)
        {
            var pipeDtoList = new List<SanitaryPipeDto>();

            using (var parser = new TextFieldParser(filePath))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");

                parser.TrimWhiteSpace = true;
                parser.ReadLine();

                while (!parser.EndOfData)
                {

                    var fields = parser.ReadFields();

                    var pipeDto = new SanitaryPipeDto
                    {
                        Diameter = double.Parse(fields[0]),
                        Vent = double.Parse(fields[2]),
                        WasteFixture = double.Parse(fields[1])
                    };

                    pipeDtoList.Add(pipeDto);
                }
            }

            return pipeDtoList;
        }
    }
}
