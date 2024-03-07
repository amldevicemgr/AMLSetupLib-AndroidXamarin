using AMLSetupLib.Helpers;
using AMLSetupLib.Models;
using Android.Content;
using Android.OS;
using Android.Widget;
using Java.Lang;
using System;
using Newtonsoft.Json;
using Android.Security.Identity;
using Android.Util;

namespace AMLSetupLib
{
    public class AMLSetupClient
    {
        public event Action<SdkError> Error;
        public event Action<bool> Connected;
        public event Action<Bundle> ReceiveConnectionStatus;
        private bool mPermission = false;
        protected Context mContext { get; }
        private BroadcastReceiverHelp mReceiver;
        private string mFilter;
        private int mClientVersion;
        private string mPackage;

        /// <summary>
        /// Constructs an AMLSetupClient instance to configure the device and receive device hardware info.
        /// </summary>
        /// <param name="context">The context of the application.</param>
        public AMLSetupClient(Context context)
        {
            mContext = context;
            mPackage = context.PackageName;
            mFilter = mPackage + Values.SDK_RESULT_SEND;
            mClientVersion = AMLDevice.GetAMLSetupClientVersion(mContext);

            IntentFilter filter = new IntentFilter();
            filter.AddAction(mFilter);

            mReceiver = new BroadcastReceiverHelp(intent => {
                if (intent != null)
                {
                    string action = intent.Action;
                    if (!string.IsNullOrEmpty(action))
                    {
                        if (action.Equals(mFilter))
                        {
                            string errorString = intent.GetStringExtra(Values.SDK_ERROR_EXTRA);
                            SdkError error = JsonConvert.DeserializeObject<SdkError>(errorString);
                            Error?.Invoke(error);
                        }
                    }                  
                }
            });

            //Register!
            mContext.RegisterReceiver(mReceiver, filter);
            InitClient();
        }

        /// <summary>
        /// Closes the AMLSetupClient.
        /// </summary>
        public void Close()
        {
            if (mReceiver != null)
            {
                BroadcastReceiver br = mReceiver;
                mReceiver = null;
                //Make sure to unregister when we no longer needed.
                mContext.UnregisterReceiver(br);
            }
        }

        /// <summary>
        /// Requests the device info asynchronously. If permission is denied,
        /// this operation will fail and a SDKError will be sent to the error listener.
        /// </summary>
        /// <param name="receiver">The Action receiver to receive the device info object.</param>
        public void GetDeviceInfo(Action<DeviceInfo> receiver)
        {
            try
            {
                Intent intent = new Intent(Values.SDK_GET_DEVICE_INFO);
                var bundle = new Bundle();
                bundle.PutParcelable(Intent.ExtraResultReceiver, ResultReceiverHelp.CreateNewFromParcel(receiver));
                bundle.PutString(Values.SDK_SENDER_PACKAGE_EXTRA, mPackage);
                intent.PutExtras(bundle);
                StartService(intent);
            }
            catch (Java.Lang.Exception e)
            {
                Log.Debug("AMLSetupClient", e.StackTrace);
            }
            
        }

        /// <summary>
        /// Sends a aml setup config string to be processed. If permission is denied,
        /// this operation will fail and a SDKError will be sent to the error listener.
        /// Use the AML Setup Console application to generate the aml setup config string.
        /// </summary>
        /// <param name="receiver">The Action receiver to receive the result from the config processing.</param>
        /// <param name="configJson">The aml setup config string generated with AML Setup Console.</param>
        public void SendConfigJson(Action<ProcessConfigResult> receiver, string configJson)
        {
            try
            {
                Intent intent = new Intent(Values.SDK_PROCESS_CONFIG_JSON);
                var bundle = new Bundle();

                if (receiver != null)
                    bundle.PutParcelable(Intent.ExtraResultReceiver, ResultReceiverHelp.CreateNewFromParcel(receiver));

                bundle.PutString(Values.SDK_SENDER_PACKAGE_EXTRA, mPackage);
                bundle.PutString(Values.SDK_TASK_EXTRA, configJson);
                intent.PutExtras(bundle);
                StartService(intent);
            }
            catch (Java.Lang.Exception e)
            {
                Log.Debug("AMLSetupClient", e.StackTrace);
            }

        }

        /// <summary>
        /// Reboots the device immediately. If permission is denied,
        /// this operation will fail and a SDKError will be sent to the error listener.
        /// </summary>
        public void RebootDevice()
        {
            Intent intent = new Intent(Values.SDK_REBOOT);
            var bundle = new Bundle();
            bundle.PutString(Values.SDK_SENDER_PACKAGE_EXTRA, mPackage);
            intent.PutExtras(bundle);
            StartService(intent);
        }

        /// <summary>
        /// Forces the device to preform an OTA. If permission is denied or the battery is low,
        /// this operation will fail and a SDKError will be sent to the error listener.
        /// </summary>
        public void ForceOTA()
        {
            Intent intent = new Intent(Values.SDK_FORCE_OTA);
            var bundle = new Bundle();
            bundle.PutString(Values.SDK_SENDER_PACKAGE_EXTRA, mPackage);
            intent.PutExtras(bundle);
            StartService(intent);
        }

        private void InitClient()
        {
            Intent intent = new Intent(Values.SDK_INIT);
            ReceiveConnectionStatus += AMLSetupClient_ReceiveConnectionStatus;
            var bundle = new Bundle();
            bundle.PutParcelable(Intent.ExtraResultReceiver, ResultReceiverHelp.CreateNewFromParcel(ReceiveConnectionStatus));
            bundle.PutString(Values.SDK_SENDER_PACKAGE_EXTRA, mPackage);
            intent.PutExtras(bundle);
            StartService(intent);
        }        

        private void AMLSetupClient_ReceiveConnectionStatus(Bundle resultData)
        {
            bool hasPermission = resultData.GetBoolean(Values.SDK_PERMISSION_RESULT_EXTRA);
            mPermission = hasPermission;
            Connected?.Invoke(mPermission);
        }

        private void StartService(Intent intent)
        {
            if (intent == null) intent = new Intent();
            intent.SetClassName(Values.PACKAGE_NAME, Values.CLASS_NAME);

            if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
            {
                mContext.StartForegroundService(intent);
            }
            else
            {
                mContext.StartService(intent);
            }
        }
    }
}
