using BeaconGenerator.Models.Entities;
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

        public void RegistBeacon(GeneratedBeacon beacon)
        {
            var regist = new Beacon
            {
                Identifier = beacon.Identifier,
                Uuid = beacon.Uuid,
                Major = beacon.Major,
                Minor = beacon.Minor,
                Power = beacon.Power,
            };

            var repo = new GeneratedBeaconsRepository();
            repo.RegistBeacon(regist);
        }

        public void DeleteBeacon(GeneratedBeacon beacon)
        {
            var repo = new GeneratedBeaconsRepository();
            repo.DeleteBeacon(beacon.Identifier);
        }
    }
}
