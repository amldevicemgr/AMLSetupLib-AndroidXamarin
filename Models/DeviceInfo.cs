using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AMLSetupLib.Models
{
    public class DeviceInfo
    {
        private string SerialNumber;
        private string Model;
        private string Name;
        private string Build;
        private CurrentNetwork ActiveNetwork;
        private BatteryStatus Battery;
        private long AvailableStorage;
        private string DeviceUpTime;
        private string IpAddress;
        private string WifiMacAddress;
        private string EthernetMacAddress;
        private string BtMacAddress;

        public string GetSerialNumber()
        {
            return SerialNumber;
        }

        void SetSerialNumber(string serialNumber)
        {
            SerialNumber = serialNumber;
        }

        public string GetModel()
        {
            return Model;
        }

        void SetModel(string model)
        {
            Model = model;
        }

        public string GetName()
        {
            return Name;
        }

        void SetName(string name)
        {
            Name = name;
        }

        public string GetBuild()
        {
            return Build;
        }

        void SetBuild(string build)
        {
            Build = build;
        }

        public CurrentNetwork GetActiveNetwork()
        {
            return ActiveNetwork;
        }

        void SetActiveNetwork(CurrentNetwork activeNetwork)
        {
            ActiveNetwork = activeNetwork;
        }

        public BatteryStatus GetBattery()
        {
            return Battery;
        }

        void SetBattery(BatteryStatus battery)
        {
            Battery = battery;
        }

        public long GetAvailableStorage()
        {
            return AvailableStorage;
        }

        void SetAvailableStorage(long availableStorage)
        {
            AvailableStorage = availableStorage;
        }

        public string GetDeviceUpTime()
        {
            return DeviceUpTime;
        }

        void SetDeviceUpTime(string deviceUpTime)
        {
            DeviceUpTime = deviceUpTime;
        }

        public string GetIpAddress()
        {
            return IpAddress;
        }

        void SetIpAddress(string ipAddress)
        {
            IpAddress = ipAddress;
        }

        public string GetWifiMacAddress()
        {
            return WifiMacAddress;
        }

        void SetWifiMacAddress(string wifiMacAddress)
        {
            WifiMacAddress = wifiMacAddress;
        }

        public string GetEthernetMacAddress()
        {
            return EthernetMacAddress;
        }

        void SetEthernetMacAddress(string ethernetMacAddress)
        {
            EthernetMacAddress = ethernetMacAddress;
        }

        public string GetBtMacAddress()
        {
            return BtMacAddress;
        }

        void SetBtMacAddress(string btMacAddress)
        {
            BtMacAddress = btMacAddress;
        }
    }
}