using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HuffmanWeb.Mobile.Client.Enumerations;
using HuffmanWeb.Common.DTOs;
using HuffmanWeb.Common.DTOs.Requests;
using HuffmanWeb.Common.DTOs.Responses;
using HuffmanWeb.Mobile.Client.ApiInterfaces;
using System.Text.Json;

namespace HuffmanWeb.Mobile.Client.ViewModels
{
    public partial class DecodeViewModel : BaseViewModel
    {
        private readonly IHuffmanApi _api;

        [ObservableProperty]
        DecodeResponse response = new();
        [ObservableProperty]
        string textToDecode = string.Empty;
        [ObservableProperty]
        string matchingTableJson = string.Empty;

        public DecodeViewModel(IHuffmanApi api)
        {
            _api = api;
        }

        [RelayCommand]
        public async Task CallDecodeAPI()
        {
            try
            {
                var characters = JsonSerializer.Deserialize<List<Character>>(MatchingTableJson);
                if (characters is null)
                {
                    ErrorMessage = "Invalid matching table format.";
                    ErrorType = ErrorTypeEnum.Error;
                    return;
                }

                Response = new();
                var req = new DecodeRequest
                {
                    BinaryHuffman = TextToDecode,
                    MatchingCharacters = characters
                };
                Response = await _api.Decode(req);
            }
            catch (Exception)
            {
                ErrorMessage = "Une erreur est survenue";
                ErrorType = ErrorTypeEnum.Error;
            }
        }
    }
}
