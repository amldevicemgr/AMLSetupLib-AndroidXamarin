using AMLSetupLib.Models;
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

namespace AMLSetupLib
{
    /**
     * Reusable helper classes below, for minimizing code.
     */

    class BroadcastReceiverHelp : BroadcastReceiver
    {
        Action<Intent> Receive;
        public BroadcastReceiverHelp(Action<Intent> receive) { Receive = receive; }
        public override void OnReceive(Context context, Intent intent)
        {
            Receive?.Invoke(intent);
        }
    }

    class ResultReceiverHelp : ResultReceiver
    {
        Action<Bundle> Receive;
        Action<DeviceInfo> ReceiveDeviceInfo;
        Action<ProcessConfigResult> ReceiveConfigResult;
        public ResultReceiverHelp(Action<Bundle> onReceive)
            : base(new Handler())
        {
            Receive = onReceive;
        }
        public ResultReceiverHelp(Action<DeviceInfo> onReceive)
            : base(new Handler())
        {
            ReceiveDeviceInfo = onReceive;
        }
        public ResultReceiverHelp(Action<ProcessConfigResult> onReceive)
            : base(new Handler())
        {
            ReceiveConfigResult = onReceive;
        }
        protected override void OnReceiveResult(int resultCode, Bundle resultData)
        {
            if (Receive != null)
                Receive?.Invoke(resultData);

            if (ReceiveDeviceInfo != null)
            {
                string deviceInfoString = resultData.GetString(Values.SDK_EXTRA_DEVICE_INFO);
                DeviceInfo info = Newtonsoft.Json.JsonConvert.DeserializeObject<DeviceInfo>(deviceInfoString);
                ReceiveDeviceInfo?.Invoke(info);
            }

            if (ReceiveConfigResult != null)
            {
                string resultString = resultData.GetString(Values.SDK_EXTRA_CONFIG_JSON_RESULT);
                ProcessConfigResult result = Newtonsoft.Json.JsonConvert.DeserializeObject<ProcessConfigResult>(resultString);
                ReceiveConfigResult?.Invoke(result);
            }
        }

        public static ResultReceiver CreateNewFromParcel(Action<Bundle> onReceive)
        {
            ResultReceiver r = new ResultReceiverHelp(onReceive);
            var p = Parcel.Obtain();
            r.WriteToParcel(p, 0);
            p.SetDataPosition(0);
            r = Creator.CreateFromParcel(p) as ResultReceiver;
            p.Recycle();
            return r;
        }

        public static ResultReceiver CreateNewFromParcel(Action<DeviceInfo> onReceive)
        {
            ResultReceiver r = new ResultReceiverHelp(onReceive);
            var p = Parcel.Obtain();
            r.WriteToParcel(p, 0);
            p.SetDataPosition(0);
            r = Creator.CreateFromParcel(p) as ResultReceiver;
            p.Recycle();
            return r;
        }

        public static ResultReceiver CreateNewFromParcel(Action<ProcessConfigResult> onReceive)
        {
            ResultReceiver r = new ResultReceiverHelp(onReceive);
            var p = Parcel.Obtain();
            r.WriteToParcel(p, 0);
            p.SetDataPosition(0);
            r = Creator.CreateFromParcel(p) as ResultReceiver;
            p.Recycle();
            return r;
        }
    }
}