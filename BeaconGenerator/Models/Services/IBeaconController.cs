using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeaconGenerator.Models.Services
{
    public interface IBeaconController
    {
        void Start(string uuid, ushort major, ushort minor, byte power);
        void Stop();

        event EventHandler Stopped;
    }
}
