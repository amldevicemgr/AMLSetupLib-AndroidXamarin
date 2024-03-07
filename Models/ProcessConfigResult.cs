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
    public class ProcessConfigResult
    {
        private bool Success;
        private List<FailedSdkTask> FailedTasks;

        public bool IsSuccess()
        {
            return Success;
        }

        void SetSuccess(bool success)
        {
            Success = success;
        }

        public List<FailedSdkTask> GetFailedTasks()
        {
            return FailedTasks;
        }

        void SetFailedTasks(List<FailedSdkTask> failedTasks)
        {
            FailedTasks = failedTasks;
        }
    }
}