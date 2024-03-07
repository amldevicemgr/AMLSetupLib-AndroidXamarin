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
    public class SdkError
    {
        private string PackageName;
        private int Type;
        private string Reason;

        public string GetPackageName()
        {
            return PackageName;
        }

        void SetPackageName(string packageName)
        {
            PackageName = packageName;
        }

        public int GetTypeInt()
        {
            return Type;
        }

        void SetType(int type)
        {
            Type = type;
        }

        public string GetReason()
        {
            return Reason;
        }

        void SetReason(string reason)
        {
            Reason = reason;
        }
    }
}