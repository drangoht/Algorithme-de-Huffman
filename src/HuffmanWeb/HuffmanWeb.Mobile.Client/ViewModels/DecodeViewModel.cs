using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HuffmanPlayground.Mobile.Client.Enumerations;
using HuffmanWeb.Common.DTOs;
using HuffmanWeb.Common.DTOs.Requests;
using HuffmanWeb.Common.DTOs.Responses;
using HuffmanWeb.Mobile.Client.ApiInterfaces;
using Refit;
using System.Text.Json;

namespace HuffmanWeb.Mobile.Client.ViewModels
{
    public partial class DecodeViewModel : BaseViewModel
    {
        [ObservableProperty]
        DecodeResponse response = new();
        [ObservableProperty]
        string textToDecode = string.Empty;
        [ObservableProperty]
        string matchingTableJson = string.Empty;

        [RelayCommand]
        public async Task CallDecodeAPI() // Corrected spelling of 'Api' to 'API'
        {
            try
            {
                Response = new();
                var huffmanAPI = RestService.For<IHuffmanApi>("https://huffmanweb.thognard.net/huffman"); // Corrected spelling of 'Api' to 'API'
                var req = new DecodeRequest();
                req.BinaryHuffman = TextToDecode;
                req.MatchingCharacters = JsonSerializer.Deserialize<List<Character>>(MatchingTableJson)!;
                Response = await huffmanAPI.Decode(req);
            }
            catch (Exception)
            {
                ErrorMessage = "Une erreur est survenue";
                ErrorType = ErrorTypeEnum.Error;
            }
        }
    }
}
