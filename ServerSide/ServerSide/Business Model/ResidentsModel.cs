using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerSide
{
    public class ResidentsModel
    {
        public int CitySymbol { get; set; }
        public string CityName { get; set; }
        public int RegionSymbol { get; set; }
        public string RegionName { get; set; }
        public int CodeOfManacaMana { get; set; }
        public string ChangeMana { get; set; }
        public int RegionalCode { get; set; }
        public int Total { get; set; }
        public int Age_0_5 { get; set; }
        public int Age_6_18 { get; set; }
        public int Age_19_45 { get; set; }
        public int Age_46_55 { get; set; }
        public int Age_56_64 { get; set; }
        public int Age_65Plus { get; set; }

    }
}
