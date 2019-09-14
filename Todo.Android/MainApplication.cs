﻿using System;
using Shiny;
using Android.App;
using Android.Runtime;


namespace Todo.Droid
{
    [Application]
    public class MainApplication : ShinyAndroidApplication<ShinyStartup>
    {
        public MainApplication(IntPtr handle, JniHandleOwnership transfer) : base(handle, transfer)
        {
        }
    }
}