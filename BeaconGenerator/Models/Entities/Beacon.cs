using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeaconGenerator.Models.Entities
{
    public class Beacon
    {
        public string Identifier { get; set; }
        public string Uuid { get; set; }
        public ushort Major { get; set; }
        public ushort Minor { get; set; }
        public byte Power { get; set; }
    }
}
