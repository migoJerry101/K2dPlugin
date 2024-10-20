using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using K2dPlugin.Features.GenerateReport.Dto;
using K2dPlugin.Features.PipeSum.Dto;

namespace K2dPlugin.Services
{
    public class FixtureUnitGpmService
    {
        private static readonly List<FixtureUnitGpmDto> FixtureUnitGpmDtoList = new List<FixtureUnitGpmDto>()
        {
            new FixtureUnitGpmDto { FlushTank = 0, FlushValve = 0, GPM = 1 },
            new FixtureUnitGpmDto { FlushTank = 1, FlushValve = 0, GPM = 2 },
            new FixtureUnitGpmDto { FlushTank = 3, FlushValve = 0, GPM = 3 },
            new FixtureUnitGpmDto { FlushTank = 4, FlushValve = 0, GPM = 4 },
            new FixtureUnitGpmDto { FlushTank = 6, FlushValve = 0, GPM = 5 },
            new FixtureUnitGpmDto { FlushTank = 7, FlushValve = 0, GPM = 6 },
            new FixtureUnitGpmDto { FlushTank = 8, FlushValve = 0, GPM = 7 },
            new FixtureUnitGpmDto { FlushTank = 10, FlushValve = 0, GPM = 8 },
            new FixtureUnitGpmDto { FlushTank = 12, FlushValve = 0, GPM = 9 },
            new FixtureUnitGpmDto { FlushTank = 13, FlushValve = 0, GPM = 10 },
            new FixtureUnitGpmDto { FlushTank = 15, FlushValve = 0, GPM = 11 },
            new FixtureUnitGpmDto { FlushTank = 16, FlushValve = 0, GPM = 12 },
            new FixtureUnitGpmDto { FlushTank = 18, FlushValve = 0, GPM = 13 },
            new FixtureUnitGpmDto { FlushTank = 20, FlushValve = 0, GPM = 14 },
            new FixtureUnitGpmDto { FlushTank = 21, FlushValve = 0, GPM = 15 },
            new FixtureUnitGpmDto { FlushTank = 23, FlushValve = 0, GPM = 16 },
            new FixtureUnitGpmDto { FlushTank = 24, FlushValve = 0, GPM = 17 },
            new FixtureUnitGpmDto { FlushTank = 26, FlushValve = 0, GPM = 18 },
            new FixtureUnitGpmDto { FlushTank = 28, FlushValve = 0, GPM = 19 },
            new FixtureUnitGpmDto { FlushTank = 30, FlushValve = 0, GPM = 20 },
            new FixtureUnitGpmDto { FlushTank = 32, FlushValve = 0, GPM = 21 },
            new FixtureUnitGpmDto { FlushTank = 34, FlushValve = 5, GPM = 22 },
            new FixtureUnitGpmDto { FlushTank = 36, FlushValve = 6, GPM = 23 },
            new FixtureUnitGpmDto { FlushTank = 39, FlushValve = 7, GPM = 24 },
            new FixtureUnitGpmDto { FlushTank = 42, FlushValve = 8, GPM = 25 },
            new FixtureUnitGpmDto { FlushTank = 44, FlushValve = 9, GPM = 26 },
            new FixtureUnitGpmDto { FlushTank = 46, FlushValve = 10, GPM = 27 },
            new FixtureUnitGpmDto { FlushTank = 49, FlushValve = 11, GPM = 28 },
            new FixtureUnitGpmDto { FlushTank = 51, FlushValve = 12, GPM = 29 },
            new FixtureUnitGpmDto { FlushTank = 54, FlushValve = 13, GPM = 30 },
            new FixtureUnitGpmDto { FlushTank = 56, FlushValve = 14, GPM = 31 },
            new FixtureUnitGpmDto { FlushTank = 58, FlushValve = 15, GPM = 32 },
            new FixtureUnitGpmDto { FlushTank = 60, FlushValve = 16, GPM = 33 },
            new FixtureUnitGpmDto { FlushTank = 63, FlushValve = 18, GPM = 34 },
            new FixtureUnitGpmDto { FlushTank = 66, FlushValve = 20, GPM = 35 },
            new FixtureUnitGpmDto { FlushTank = 69, FlushValve = 21, GPM = 36 },
            new FixtureUnitGpmDto { FlushTank = 75, FlushValve = 23, GPM = 37 },
            new FixtureUnitGpmDto { FlushTank = 78, FlushValve = 25, GPM = 38 },
            new FixtureUnitGpmDto { FlushTank = 83, FlushValve = 26, GPM = 39 },
            new FixtureUnitGpmDto { FlushTank = 86, FlushValve = 28, GPM = 40 },
            new FixtureUnitGpmDto { FlushTank = 90, FlushValve = 30, GPM = 41 },
            new FixtureUnitGpmDto { FlushTank = 95, FlushValve = 31, GPM = 42 },
            new FixtureUnitGpmDto { FlushTank = 99, FlushValve = 33, GPM = 43 },
            new FixtureUnitGpmDto { FlushTank = 103, FlushValve = 35, GPM = 44 },
            new FixtureUnitGpmDto { FlushTank = 107, FlushValve = 37, GPM = 45 },
            new FixtureUnitGpmDto { FlushTank = 111, FlushValve = 39, GPM = 46 },
            new FixtureUnitGpmDto { FlushTank = 115, FlushValve = 42, GPM = 47 },
            new FixtureUnitGpmDto { FlushTank = 119, FlushValve = 44, GPM = 48 },
            new FixtureUnitGpmDto { FlushTank = 123, FlushValve = 46, GPM = 49 },
            new FixtureUnitGpmDto { FlushTank = 127, FlushValve = 48, GPM = 50 },
            new FixtureUnitGpmDto { FlushTank = 130, FlushValve = 50, GPM = 51 },
            new FixtureUnitGpmDto { FlushTank = 135, FlushValve = 52, GPM = 52 },
            new FixtureUnitGpmDto { FlushTank = 141, FlushValve = 54, GPM = 53 },
            new FixtureUnitGpmDto { FlushTank = 146, FlushValve = 57, GPM = 54 },
            new FixtureUnitGpmDto { FlushTank = 151, FlushValve = 60, GPM = 55 },
            new FixtureUnitGpmDto { FlushTank = 155, FlushValve = 63, GPM = 56 },
            new FixtureUnitGpmDto { FlushTank = 160, FlushValve = 66, GPM = 57 },
            new FixtureUnitGpmDto { FlushTank = 165, FlushValve = 69, GPM = 58 },
            new FixtureUnitGpmDto { FlushTank = 170, FlushValve = 73, GPM = 59 },
            new FixtureUnitGpmDto { FlushTank = 175, FlushValve = 76, GPM = 60 },
            new FixtureUnitGpmDto { FlushTank = 185, FlushValve = 82, GPM = 62 },
            new FixtureUnitGpmDto { FlushTank = 195, FlushValve = 88, GPM = 64 },
            new FixtureUnitGpmDto { FlushTank = 205, FlushValve = 95, GPM = 66 },
            new FixtureUnitGpmDto { FlushTank = 215, FlushValve = 102, GPM = 68 },
            new FixtureUnitGpmDto { FlushTank = 225, FlushValve = 108, GPM = 70 },
            new FixtureUnitGpmDto { FlushTank = 236, FlushValve = 116, GPM = 72 },
            new FixtureUnitGpmDto { FlushTank = 245, FlushValve = 124, GPM = 74 },
            new FixtureUnitGpmDto { FlushTank = 254, FlushValve = 132, GPM = 76 },
            new FixtureUnitGpmDto { FlushTank = 264, FlushValve = 140, GPM = 78 },
            new FixtureUnitGpmDto { FlushTank = 284, FlushValve = 158, GPM = 82 },
            new FixtureUnitGpmDto { FlushTank = 294, FlushValve = 168, GPM = 84 },
            new FixtureUnitGpmDto { FlushTank = 305, FlushValve = 176, GPM = 86 },
            new FixtureUnitGpmDto { FlushTank = 315, FlushValve = 186, GPM = 88 },
            new FixtureUnitGpmDto { FlushTank = 326, FlushValve = 195, GPM = 90 },
            new FixtureUnitGpmDto { FlushTank = 337, FlushValve = 205, GPM = 92 },
            new FixtureUnitGpmDto { FlushTank = 348, FlushValve = 214, GPM = 94 },
            new FixtureUnitGpmDto { FlushTank = 359, FlushValve = 223, GPM = 96 },
            new FixtureUnitGpmDto { FlushTank = 370, FlushValve = 234, GPM = 98 },
            new FixtureUnitGpmDto { FlushTank = 380, FlushValve = 245, GPM = 100 },
            new FixtureUnitGpmDto { FlushTank = 406, FlushValve = 270, GPM = 105 },
            new FixtureUnitGpmDto { FlushTank = 431, FlushValve = 295, GPM = 110 },
            new FixtureUnitGpmDto { FlushTank = 455, FlushValve = 329, GPM = 115 },
            new FixtureUnitGpmDto { FlushTank = 479, FlushValve = 365, GPM = 120 },
            new FixtureUnitGpmDto { FlushTank = 506, FlushValve = 396, GPM = 125 },
            new FixtureUnitGpmDto { FlushTank = 533, FlushValve = 430, GPM = 130 },
            new FixtureUnitGpmDto { FlushTank = 559, FlushValve = 460, GPM = 135 },
            new FixtureUnitGpmDto { FlushTank = 585, FlushValve = 490, GPM = 140 },
            new FixtureUnitGpmDto { FlushTank = 611, FlushValve = 521, GPM = 145 },
            new FixtureUnitGpmDto { FlushTank = 638, FlushValve = 559, GPM = 150 },
            new FixtureUnitGpmDto { FlushTank = 665, FlushValve = 596, GPM = 155 },
            new FixtureUnitGpmDto { FlushTank = 692, FlushValve = 631, GPM = 160 },
            new FixtureUnitGpmDto { FlushTank = 719, FlushValve = 666, GPM = 165 },
            new FixtureUnitGpmDto { FlushTank = 748, FlushValve = 700, GPM = 170 },
            new FixtureUnitGpmDto { FlushTank = 778, FlushValve = 739, GPM = 175 },
            new FixtureUnitGpmDto { FlushTank = 809, FlushValve = 775, GPM = 180 },
            new FixtureUnitGpmDto { FlushTank = 840, FlushValve = 811, GPM = 185 },
            new FixtureUnitGpmDto { FlushTank = 874, FlushValve = 850, GPM = 190 },
            new FixtureUnitGpmDto { FlushTank = 945, FlushValve = 931, GPM = 200 },
            new FixtureUnitGpmDto { FlushTank = 1018, FlushValve = 1009, GPM = 210 },
            new FixtureUnitGpmDto { FlushTank = 1091, FlushValve = 1091, GPM = 220 },
            new FixtureUnitGpmDto { FlushTank = 1173, FlushValve = 1173, GPM = 230 },
            new FixtureUnitGpmDto { FlushTank = 1254, FlushValve = 1254, GPM = 240 },
            new FixtureUnitGpmDto { FlushTank = 1335, FlushValve = 1335, GPM = 250 },
            new FixtureUnitGpmDto { FlushTank = 1418, FlushValve = 1418, GPM = 260 },
            new FixtureUnitGpmDto { FlushTank = 1500, FlushValve = 1500, GPM = 270 },
            new FixtureUnitGpmDto { FlushTank = 1583, FlushValve = 1583, GPM = 280 },
            new FixtureUnitGpmDto { FlushTank = 1668, FlushValve = 1668, GPM = 290 },
            new FixtureUnitGpmDto { FlushTank = 1755, FlushValve = 1755, GPM = 300 },
            new FixtureUnitGpmDto { FlushTank = 1845, FlushValve = 1845, GPM = 310 },
            new FixtureUnitGpmDto { FlushTank = 1926, FlushValve = 1926, GPM = 320 },
            new FixtureUnitGpmDto { FlushTank = 2018, FlushValve = 2018, GPM = 330 },
            new FixtureUnitGpmDto { FlushTank = 2110, FlushValve = 2110, GPM = 340 },
            new FixtureUnitGpmDto { FlushTank = 2204, FlushValve = 2204, GPM = 350 },
            new FixtureUnitGpmDto { FlushTank = 2298, FlushValve = 2298, GPM = 360 },
            new FixtureUnitGpmDto { FlushTank = 2388, FlushValve = 2388, GPM = 370 },
            new FixtureUnitGpmDto { FlushTank = 2480, FlushValve = 2480, GPM = 380 },
            new FixtureUnitGpmDto { FlushTank = 2575, FlushValve = 2575, GPM = 390 },
            new FixtureUnitGpmDto { FlushTank = 2670, FlushValve = 2670, GPM = 400 },
            new FixtureUnitGpmDto { FlushTank = 2765, FlushValve = 2765, GPM = 410 },
            new FixtureUnitGpmDto { FlushTank = 2862, FlushValve = 2862, GPM = 420 },
            new FixtureUnitGpmDto { FlushTank = 2960, FlushValve = 2960, GPM = 430 },
            new FixtureUnitGpmDto { FlushTank = 3060, FlushValve = 3060, GPM = 440 },
            new FixtureUnitGpmDto { FlushTank = 3150, FlushValve = 3150, GPM = 450 },
            new FixtureUnitGpmDto { FlushTank = 3620, FlushValve = 3620, GPM = 500 },
            new FixtureUnitGpmDto { FlushTank = 4070, FlushValve = 4070, GPM = 550 },
            new FixtureUnitGpmDto { FlushTank = 4480, FlushValve = 4480, GPM = 600 },
            new FixtureUnitGpmDto { FlushTank = 5380, FlushValve = 5380, GPM = 700 },
            new FixtureUnitGpmDto { FlushTank = 6280, FlushValve = 6280, GPM = 800 },
            new FixtureUnitGpmDto { FlushTank = 7280, FlushValve = 7280, GPM = 900 },
            new FixtureUnitGpmDto { FlushTank = 8300, FlushValve = 8300, GPM = 1000 },
            new FixtureUnitGpmDto { FlushTank = 9320, FlushValve = 9320, GPM = 1100 },
            new FixtureUnitGpmDto { FlushTank = 10340, FlushValve = 10340, GPM = 1200 },
            new FixtureUnitGpmDto { FlushTank = 11360, FlushValve = 11360, GPM = 1300 },
            new FixtureUnitGpmDto { FlushTank = 12380, FlushValve = 12380, GPM = 1400 },
            new FixtureUnitGpmDto { FlushTank = 13400, FlushValve = 13400, GPM = 1500 },
            new FixtureUnitGpmDto { FlushTank = 14420, FlushValve = 14420, GPM = 1600 },
            new FixtureUnitGpmDto { FlushTank = 15440, FlushValve = 15440, GPM = 1700 },
            new FixtureUnitGpmDto { FlushTank = 16460, FlushValve = 16460, GPM = 1800 },
            new FixtureUnitGpmDto { FlushTank = 17480, FlushValve = 17480, GPM = 1900 },
            new FixtureUnitGpmDto { FlushTank = 18500, FlushValve = 18500, GPM = 2000 },
            new FixtureUnitGpmDto { FlushTank = 19520, FlushValve = 19520, GPM = 2100 },
            new FixtureUnitGpmDto { FlushTank = 20540, FlushValve = 20540, GPM = 2200 },
            new FixtureUnitGpmDto { FlushTank = 21560, FlushValve = 21560, GPM = 2300 },
            new FixtureUnitGpmDto { FlushTank = 22580, FlushValve = 22580, GPM = 2400 },
            new FixtureUnitGpmDto { FlushTank = 23600, FlushValve = 23600, GPM = 2500 },
            new FixtureUnitGpmDto { FlushTank = 24620, FlushValve = 24620, GPM = 2600 },
            new FixtureUnitGpmDto { FlushTank = 25640, FlushValve = 25640, GPM = 2700 },
        };

        public IEnumerable<FuGpmConversionDto> GetListConversionDtoFlashTank()
        {
            var dtos = new List<FuGpmConversionDto>();
            var count = FixtureUnitGpmDtoList.Count();

            for (int i = 0; i < count -1; i++)
            {
                var dto = new FuGpmConversionDto()
                {
                    Gpm = FixtureUnitGpmDtoList[i].GPM,
                    Max = FixtureUnitGpmDtoList[i + 1].FlushTank,
                    Min = FixtureUnitGpmDtoList[i ].FlushTank
                };

                dtos.Add(dto);
            }

            return dtos;
        }

        public IEnumerable<FuGpmConversionDto> GetListConversionDtoFlashValve()
        {
            var dtos = new List<FuGpmConversionDto>();
            var count = FixtureUnitGpmDtoList.Count();

            for (int i = 0; i < count - 1; i++)
            {
                var dto = new FuGpmConversionDto()
                {
                    Gpm = FixtureUnitGpmDtoList[i].GPM,
                    Max = FixtureUnitGpmDtoList[i + 1].FlushValve,
                    Min = FixtureUnitGpmDtoList[i].FlushValve
                };

                dtos.Add(dto);
            }

            return dtos;
        }

    }
}
    