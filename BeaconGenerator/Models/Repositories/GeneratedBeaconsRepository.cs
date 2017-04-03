using BeaconGenerator.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeaconGenerator.Models.Repositories
{
    public class GeneratedBeaconsRepository
    {
        public List<Beacon> GetBeacons()
        {
            var list = new List<Beacon>
            {
                new Beacon { Identifier = "Beacon 1-1", Uuid = "12345678-1234-1234-1234-1234567890AB", Major = 1, Minor = 1, Power = 0x1E },
                new Beacon { Identifier = "Beacon 1-2", Uuid = "12345678-1234-1234-1234-1234567890AB", Major = 2, Minor = 1, Power = 0x1E },
                new Beacon { Identifier = "Beacon 2-1", Uuid = "12345678-1234-1234-1234-1234567890AB", Major = 1, Minor = 2, Power = 0x1E },
                new Beacon { Identifier = "Beacon 2-2", Uuid = "12345678-1234-1234-1234-1234567890AB", Major = 2, Minor = 2, Power = 0x1E },
            };
            
            return list;
        }
    }
}
