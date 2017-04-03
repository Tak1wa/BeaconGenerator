using BeaconGenerator.Models;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeaconGenerator.ViewModels
{
    public class AdvertisementViewModel
    {
        public ReadOnlyReactiveCollection<AdvertisementItemViewModel> Items { get; set; }

        public ReactiveCommand CommandRefresh { get; set; }

        public AdvertisementViewModel()
        {
            var model = new BeaconList();
            Items = model.Beacons.ToReadOnlyReactiveCollection(item => new AdvertisementItemViewModel(item));
            CommandRefresh = new ReactiveCommand();
            CommandRefresh.Subscribe(_ => model.RefreshBeacons());
        }
    }

    public class AdvertisementItemViewModel
    {
        public ReactiveProperty<string> Identifier { get; set; }
        public ReactiveProperty<string> Uuid { get; set; }
        public ReactiveProperty<string> Major { get; set; }
        public ReactiveProperty<string> Minor { get; set; }
        public ReactiveProperty<string> Power { get; set; }

        public ReactiveProperty<bool> IsOn { get; set; }

        public ReactiveCommand<bool> CommandSwitch { get; set; }

        public AdvertisementItemViewModel(GeneratedBeacon beacon)
        {
            Identifier = beacon.ToReactivePropertyAsSynchronized(b => b.Identifier);
            Uuid = beacon.ToReactivePropertyAsSynchronized(b => b.Uuid);
            Major = beacon.ToReactivePropertyAsSynchronized(b => b.Major, 
                modelValue => modelValue.ToString(), viewValue => ushort.Parse(viewValue));
            Minor = beacon.ToReactivePropertyAsSynchronized(b => b.Minor,
                modelValue => modelValue.ToString(), viewValue => ushort.Parse(viewValue));
            Power = beacon.ToReactivePropertyAsSynchronized(b => b.Power,
                modelValue => modelValue.ToString(), viewValue => byte.Parse(viewValue));

            IsOn = beacon.ToReactivePropertyAsSynchronized(b => b.IsStarted);

            CommandSwitch = new ReactiveCommand<bool>();
            CommandSwitch.Subscribe(isOn =>
            {
                if (isOn)
                    beacon.Start();
                else
                    beacon.Stop();
            });
        }
    }
}
