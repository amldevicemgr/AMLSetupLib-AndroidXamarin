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
    public class Values
    {
        //AML Setup service package/class strings for Intent
        public const string PACKAGE_NAME = "com.amltd.amlsetup";
        public const string CLASS_NAME = PACKAGE_NAME + ".AMLSetupService";
        public const string SDK_RESULT_SEND = ".RECEIVE_SDK_RESULT";
        public const string SDK_PERMISSION_RESULT_EXTRA = "sdk.permission.result";
        public const string SDK_INIT = "com.amltd.amlsetup.sdk.INIT";
        public const string SDK_SENDER_PACKAGE_EXTRA = "sdk.user.package";
        public const string SDK_ERROR_EXTRA = "sdk.error.extra";
        public const string SDK_GET_DEVICE_INFO = "com.amltd.amlsetup.sdk.GET_DEVICE_INFO";
        public const string SDK_EXTRA_DEVICE_INFO = "com.amltd.amlsetup.DEVICE_INFO";
        public const string SDK_FORCE_OTA = "com.amltd.amlsetup.sdk.FORCE_OTA";
        public const string SDK_REBOOT = "com.amltd.amlsetup.sdk.REBOOT";
        public const string SDK_PROCESS_CONFIG_JSON = "com.amltd.amlsetup.sdk.PROCESS_JSON";
        public const string SDK_EXTRA_CONFIG_JSON_RESULT = "com.amltd.amlsetup.SDK_CONFIG_JSON";
        public const string SDK_PROCESS_CONFIG = "com.amltd.amlsetup.sdk.PROCESS_CONFIG";
        public const string SDK_EXTRA_CONFIG = "com.amltd.amlsetup.SDK_CONFIG";
        public const string SDK_EXTRA_CONFIG_RESULT = "com.amltd.amlsetup.SDK_CONFIG_RESULT";
        public const string SDK_TASK_LIST_EXTRA = "com.amltd.amlsetup.SDK_JSON_TASK_LIST";
        public const string SDK_TASK_EXTRA = "com.amltd.amlsetup.SDK_JSON_TASK";
        public const int SDK_FIRST_VERSION = 103;
    }
}