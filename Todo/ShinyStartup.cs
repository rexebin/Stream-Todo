﻿using System;
using Microsoft.Extensions.DependencyInjection;
using Todo.Infrastructure;
using Shiny;
using Shiny.Jobs;
using Shiny.Notifications;
using Shiny.Locations;
using Shiny.Logging;


namespace Todo
{
    public class ShinyStartup : Startup
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            services.UseNotifications();
            services.UseGeofencing<GeofenceDelegate>();
            services.RegisterStartupTask<GlobalExceptionHandler>();

            var job = new JobInfo
            {
                Identifier = nameof(SyncJob),
                Type = typeof(SyncJob),
                BatteryNotLow = true,
                RequiredInternetAccess = InternetAccess.Any
            };
            services.RegisterJob(job);

            Log.UseConsole();
            Log.UseDebug();
        }
    }
}