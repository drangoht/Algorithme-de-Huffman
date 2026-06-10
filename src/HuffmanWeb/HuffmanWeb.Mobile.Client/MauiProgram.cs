using HuffmanWeb.Mobile.Client.ApiInterfaces;
using HuffmanWeb.Mobile.Client.ViewModels;
using Microsoft.Extensions.Logging;
using Refit;
using SkiaSharp.Views.Maui.Controls.Hosting;

namespace HuffmanWeb.Mobile.Client
{
    public static class MauiProgram
    {
        private const string ApiBaseUrl = "https://huffmanweb.thognard.net/huffman/";

        public static MauiApp CreateMauiApplication()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseSkiaSharp()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            builder.Services
                .AddRefitClient<IHuffmanApi>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri(ApiBaseUrl));

            builder.Services.AddSingleton<EncodeViewModel>();
            builder.Services.AddSingleton<DecodeViewModel>();
            builder.Services.AddSingleton<EncodeTreeViewModel>();

            return builder.Build();
        }
    }
}
