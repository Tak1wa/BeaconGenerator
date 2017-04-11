using BeaconGenerator.Models.Entities;
using LiteDB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace BeaconGenerator.Models.Repositories
{
    public class GeneratedBeaconsRepository
    {
        //Install-Package LiteDB
        private static readonly string DATA_FILE = Path.Combine(ApplicationData.Current.LocalFolder.Path, "BeaconData.db");
        private const string TABLE_NAME = "Beacons";

        public List<Beacon> GetBeacons()
        {
            using (var db = new LiteDatabase(DATA_FILE))
            {
                var beacons = db.GetCollection<Beacon>(TABLE_NAME);
                return beacons.FindAll().ToList();
            }
        }

        public void RegistBeacon(Beacon beacon)
        {
            using (var db = new LiteDatabase(DATA_FILE))
            {
                var beacons = db.GetCollection<Beacon>(TABLE_NAME);
                beacons.Insert(beacon);
            }
        }

        public void DeleteBeacon(string identifier)
        {
            using (var db = new LiteDatabase(DATA_FILE))
            {
                var beacons = db.GetCollection<Beacon>(TABLE_NAME);
                beacons.Delete(beacon => beacon.Identifier == identifier);
            }
        }
    }
}
