using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HuffmanWeb.Common.DTOs.Requests;
using HuffmanWeb.Common.DTOs.Responses;
using HuffmanWeb.Mobile.Client.ApiInterfaces;
using HuffmanPlayground.Mobile.Client.Enumerations;
using Refit;

namespace HuffmanWeb.Mobile.Client.ViewModels
{
    public partial class EncodeViewModel : BaseViewModel
    {
        [ObservableProperty]
        EncodeResponse response = new();
        [ObservableProperty]
        string textToEncode = string.Empty;
        [ObservableProperty]
        decimal compressionPercent = 0;

        [RelayCommand]
        public async Task CallEncodeApi()
        {
            try
            {
                Response = new();
                var huffmanApi = RestService.For<IHuffmanApi>("https://huffmanweb.thognard.net/huffman"); // Ugly      
                var req = new EncodeRequest();
                req.TextToEncode = TextToEncode;
                Response = await huffmanApi.Encode(req);
                CompressionPercent = Response.OriginalSize > 0 ? ((1 - (decimal)((decimal)Response.EncodedSize / (decimal)Response.OriginalSize)) * (decimal)100) : 0;
                ErrorType = ErrorTypeEnum.None;
            }
            catch (Exception ex)
            {
                ErrorMessage = "Une erreur est survenue";
                ErrorType = ErrorTypeEnum.Error;
            }

        }

    }
}
