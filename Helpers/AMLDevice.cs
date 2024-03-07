using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AMLSetupLib.Helpers
{
    public class AMLDevice
    {
        /// <summary>
        /// Checks whether the device is an AML device.
        /// Returns true if the device is AML, otherwise false.
        /// </summary>
        public static bool IsAMLDevice()
        {
            string model = Build.Model;
            return model.Equals("M7700") || model.Equals("M7800") || model.Equals("M6500") || model.Equals("KDT7") || model.Equals("M7800 BATCH");
        }

        /// <summary>
        /// Checks whether the device supports AMLSetupClient.
        /// Returns true if the device supports AMLSetupClient, otherwise false.
        /// </summary>
        public static bool IsAMLSetupClientSupported(Context context)
        {
            try
            {
                PackageInfo packageInfo = context.PackageManager.GetPackageInfo("com.amltd.amlsetup", 0);
                return packageInfo.VersionCode >= 103 && IsAMLDevice();
            }
            catch (Exception e)
            {
                Log.Debug("AMLSetupClient", e.StackTrace);
            }
            return false;
        }

        /// <summary>
        /// Checks the device AMLSetupClient version.
        /// Returns the AMLSetupClient version or 0 if AML Setup is not found on the device.
        /// </summary>
        public static int GetAMLSetupClientVersion(Context context)
        {
            try
            {
                PackageInfo packageInfo = context.PackageManager.GetPackageInfo("com.amltd.amlsetup", 0);
                return packageInfo.VersionCode;
            }
            catch (Exception e)
            {
                Log.Debug("AMLSetupClient", e.StackTrace);
            }
            return 0;
        }
    }
}