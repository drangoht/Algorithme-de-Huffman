using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HuffmanPlayground.Mobile.Client.Enumerations;
using HuffmanWeb.Common.DTOs.Requests;
using HuffmanWeb.Common.DTOs.Responses;
using HuffmanWeb.Mobile.Client.ApiInterfaces;

namespace HuffmanWeb.Mobile.Client.ViewModels
{
    public partial class EncodeViewModel : BaseViewModel
    {
        private readonly IHuffmanApi _api;

        [ObservableProperty]
        EncodeResponse response = new();
        [ObservableProperty]
        string textToEncode = string.Empty;
        [ObservableProperty]
        decimal compressionPercent = 0;
        [ObservableProperty]
        bool isWorking = false;

        public EncodeViewModel(IHuffmanApi api)
        {
            _api = api;
        }

        [RelayCommand]
        public async Task CallEncodeAPI()
        {
            try
            {
                IsWorking = true;
                Response = new();
                var req = new EncodeRequest { TextToEncode = TextToEncode };
                Response = await _api.Encode(req);
                CompressionPercent = Response.OriginalSize > 0
                    ? (1 - (decimal)Response.EncodedSize / Response.OriginalSize) * 100
                    : 0;
                ErrorType = ErrorTypeEnum.None;
            }
            catch (Exception)
            {
                ErrorMessage = "Une erreur est survenue";
                ErrorType = ErrorTypeEnum.Error;
            }
            finally
            {
                IsWorking = false;
            }
        }
    }
}
