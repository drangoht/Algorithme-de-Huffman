﻿using CommunityToolkit.Maui;
using HuffmanWeb.Mobile.Client.ViewModels;
using Microsoft.Extensions.Logging;
using SkiaSharp.Views.Maui.Controls.Hosting;


namespace HuffmanWeb.Mobile.Client
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApplication() // Corrected spelling of 'App' to 'Application'
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .UseSkiaSharp()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
#if DEBUG
            builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<EncodeViewModel>();
            builder.Services.AddSingleton<DecodeViewModel>();
            builder.Services.AddSingleton<EncodeTreeViewModel>();
            return builder.Build();
        }
    }
}
