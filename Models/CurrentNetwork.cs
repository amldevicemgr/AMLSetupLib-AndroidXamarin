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
    public class CurrentNetwork
    {
        private string SSID;
        private string RSSI;
        private string BSSID;
        private bool Connected;
        private string LinkSpeed;

        public string GetLinkSpeed()
        {
            return LinkSpeed;
        }

        void SetLinkSpeed(string linkSpeed)
        {
            LinkSpeed = linkSpeed;
        }

        public bool IsConnected()
        {
            return Connected;
        }

        void SetConnected(bool connected)
        {
            Connected = connected;
        }

        public string GetSSID()
        {
            return SSID;
        }

        void SetSSID(string SSID)
        {
            this.SSID = SSID;
        }

        public string GetRSSI()
        {
            return RSSI;
        }

        void SetRSSI(string RSSI)
        {
            this.RSSI = RSSI;
        }

        public string GetBSSID()
        {
            return BSSID;
        }

        void SetBSSID(string BSSID)
        {
            this.BSSID = BSSID;
        }
    }
}