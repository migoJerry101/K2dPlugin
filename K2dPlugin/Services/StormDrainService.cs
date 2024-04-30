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
        public IEnumerable<StormDrainDto> GetListOfPipeDto()
        {
            const string partial = "\\Addins\\2021\\Resources\\Lookup\\STORM_DRAIN_PIPE_SIZING.csv";
            var filePath = CsvPathGenerator.GetCsvFilePath();
            var pipeDtoList = LoadPipeDtoFromCsv(filePath + partial);

            return pipeDtoList;
        }

        public IEnumerable<double> GetPipeSizes()
        {
            const string partial = "\\Addins\\2021\\Resources\\Lookup\\STORM_DRAIN_PIPE_SIZING.csv";
            var filePath = CsvPathGenerator.GetCsvFilePath();
            var pipeDtoList = LoadPipeDtoFromCsv(filePath + partial);
            var sizes = pipeDtoList.Select(x => x.Diameter);

            return sizes;
        }

        private static IEnumerable<StormDrainDto> LoadPipeDtoFromCsv(string filePath)
        {
            var pipeDtoList = new List<StormDrainDto>();

            using (var parser = new TextFieldParser(filePath))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");

                parser.TrimWhiteSpace = true;
                parser.ReadLine();

                while (!parser.EndOfData)
                {

                    var fields = parser.ReadFields();

                    var pipeDto = new StormDrainDto
                    {
                        Diameter = double.Parse(fields[0]),
                        Area1Hr = double.Parse(fields[1]),
                        Area2Hr = double.Parse(fields[2]),
                        Area3Hr = double.Parse(fields[3])
                    };

                    pipeDtoList.Add(pipeDto);
                }
            }

            return pipeDtoList;
        }


    }
}
