using BeaconGenerator.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeaconGenerator.Models.Services
{
    public class BeaconManageService
    {
        public List<GeneratedBeacon> GetBeacons()
        {
            var repo = new GeneratedBeaconsRepository();

            var list = new List<GeneratedBeacon>();
            foreach(var current in repo.GetBeacons())
            {
                list.Add(new GeneratedBeacon
                {
                    Identifier = current.Identifier,
                    Uuid = current.Uuid,
                    Major = current.Major,
                    Minor = current.Minor,
                    Power = current.Power,
                });
            }
            return list;
        }
        
        public GeneratedBeacon Generate(string uuid = null, ushort major = 1, ushort minor = 1, byte power = 0x1E)
        {
            if (uuid == null)
            {
                uuid = Guid.NewGuid().ToString();
            }

            var generate = new GeneratedBeacon
            {
                Uuid = uuid,
                Major = major,
                Minor = minor,
                Power = power
            };

            return generate;
        }
    }
}
