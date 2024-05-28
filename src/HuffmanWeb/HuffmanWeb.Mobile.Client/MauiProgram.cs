using HuffmanWeb.Mobile.Client.ApiInterfaces;
using HuffmanWeb.Mobile.Client.ViewModels;
using Microsoft.Extensions.Logging;
using Refit;

namespace HuffmanWeb.Mobile.Client
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
#if DEBUG
            builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<EncodeViewModel>();
            //builder.Services
            //    .AddRefitClient<IHuffmanApi>()
            //    .ConfigureHttpClient(c => c.BaseAddress = new Uri("http://localhost:5041/huffman"));
            return builder.Build();
        }
    }
}
