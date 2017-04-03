using BeaconGenerator.Models.Services;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeaconGenerator.Models
{
    public class BeaconList : BindableBase
    {
        public ObservableCollection<GeneratedBeacon> Beacons { get; set; } =
            new ObservableCollection<GeneratedBeacon>();

        public void RefreshBeacons()
        {
            Beacons.Clear();
            var service = new BeaconManageService();
            foreach(var current in service.GetBeacons())
            {
                Beacons.Add(current);
            }
        }
    }
}
