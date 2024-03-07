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
    public class FailedSdkTask
    {
        private string Task;

        public string GetTask()
        {
            return Task;
        }

        void SetTask(string task)
        {
            Task = task;
        }
    }
}