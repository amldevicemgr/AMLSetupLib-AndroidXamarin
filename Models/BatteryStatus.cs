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
    public class BatteryStatus
    {
        private bool IsCharging;
        private int BatteryPercent;

        public bool BatteryCharging()
        {
            return IsCharging;
        }

        void SetCharging(bool charging)
        {
            IsCharging = charging;
        }

        public int GetBatteryPercent()
        {
            return BatteryPercent;
        }

        void SetBatteryPercent(int batteryPercent)
        {
            BatteryPercent = batteryPercent;
        }
    }
}