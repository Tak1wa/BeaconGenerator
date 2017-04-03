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
                var beacon = new GeneratedBeacon
                {
                    Identifier = current.Identifier,
                    Uuid = current.Uuid,
                    Major = current.Major,
                    Minor = current.Minor,
                    Power = current.Power,
                };
                beacon.InitializeController();
                list.Add(beacon);
            }
            return list;
        }

    }
}
