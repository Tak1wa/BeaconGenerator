using BeaconGenerator.Models.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Bluetooth.Advertisement;

namespace BeaconGenerator.Infrastructures
{
    public class WindowsBeaconController : IBeaconController
    {
        private BluetoothLEAdvertisementPublisher publisher;

        public WindowsBeaconController()
        {
        }

        public event EventHandler Stopped;

        public void Start(string uuid, ushort major, ushort minor, byte power)
        {
            Stop();

            publisher = new BluetoothLEAdvertisementPublisher();
            var manufacturerData = new BluetoothLEManufacturerData();

            //Bluetooth SIG に登録している　企業識別子
            //manufacturerData.CompanyId = 0x0000;
            
            var guildArray = Guid.Parse(uuid).ToByteArray();
            var majorArray = BitConverter.GetBytes(major);
            var minorArray = BitConverter.GetBytes(minor);
            
            byte[] dataArray = new byte[] {
                // お決まり
                0x02, 0x15,
                // UUID 8-4-4 => LE, 4-12 => BE
                guildArray[3], guildArray[2], guildArray[1], guildArray[0],
                guildArray[5], guildArray[4], guildArray[7], guildArray[6],
                guildArray[8], guildArray[9], guildArray[10], guildArray[11],
                guildArray[12], guildArray[13], guildArray[14], guildArray[15],
                // Major LE
                majorArray[1], majorArray[0],
                // Minor LE
                minorArray[1], minorArray[0],
                // TX power
                power
            };
            manufacturerData.Data = dataArray.AsBuffer();

            publisher.Advertisement.ManufacturerData.Add(manufacturerData);
            
            publisher?.Start();
            Debug.WriteLine("Start.");
        }

        public void Stop()
        {
            if(publisher != null)
            {
                publisher.Stop();
                Stopped?.Invoke(this, EventArgs.Empty);
                publisher = null;
                Debug.WriteLine("Stop.");
            }

        }
    }
}
