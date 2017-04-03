using BeaconGenerator.Models.Factories;
using BeaconGenerator.Models.Services;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeaconGenerator.Models
{
    public class GeneratedBeacon : BindableBase
    {
        #region Prop

        private string _Identifier;
        public string Identifier
        {
            get { return _Identifier; }
            set { SetProperty(ref _Identifier, value); }
        }

        private string _Uuid;
        public string Uuid
        {
            get { return _Uuid; }
            set { SetProperty(ref _Uuid, value); }
        }

        private ushort _Major;
        public ushort Major
        {
            get { return _Major; }
            set { SetProperty(ref _Major, value); }
        }

        private ushort _Minor;
        public ushort Minor
        {
            get { return _Minor; }
            set { SetProperty(ref _Minor, value); }
        }

        private byte _Power;
        public byte Power
        {
            get { return _Power; }
            set { SetProperty(ref _Power, value); }
        }

        private bool _IsStarted;
        public bool IsStarted
        {
            get { return _IsStarted; }
            set { SetProperty(ref _IsStarted, value); }
        }

        #endregion

        public IBeaconController BeaconController { get; set; }

        public GeneratedBeacon(IBeaconController beaconController = null)
        {
            if(beaconController == null)
                BeaconController = ServiceFactory.CreateBeaconController();
            else
                BeaconController = beaconController;

            BeaconController.Stopped += (sender, e) =>
            {
                IsStarted = false;
            };
        }
        
        #region Operation
        public void Start()
        {
            BeaconController.Start(
                Uuid, Major, Minor, Power);

            IsStarted = true;
        }

        public void Stop()
        {
            BeaconController.Stop();
        }

        public void Regist()
        {
            //TODO:Not Implemented.
        }

        public void Delete()
        {
            //TODO:Not Implemented.
        }

        #endregion

    }
}
