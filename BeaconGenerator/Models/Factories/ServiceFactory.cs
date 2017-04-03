using Autofac;
using BeaconGenerator.Models.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeaconGenerator.Models.Factories
{
    public class ServiceFactory
    {
        private static IContainer _Container;
        private static ContainerBuilder _Builder = new ContainerBuilder();

        public static void RegisterType<implementType, abstractType>()
        {
            _Builder.RegisterType<implementType>().As<abstractType>();
        }

        private static IBeaconController _BeaconController;
        public static IBeaconController CreateBeaconController()
        {
            if (_BeaconController == null)
            {
                if (_Container == null)
                {
                    _Container = _Builder.Build();
                }
                _BeaconController = _Container.Resolve<IBeaconController>();
            }
            return _BeaconController;
        }
    }
}
