using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HuffmanWeb.Common.DTOs;
using HuffmanWeb.Common.DTOs.Requests;
using HuffmanWeb.Common.DTOs.Responses;
using HuffmanWeb.Mobile.Client.ApiInterfaces;
using HuffmanPlayground.Mobile.Client.Enumerations;

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
        public async Task CallDecodeApi()
        { 
            try
            {
                Response = new();
                var huffmanApi = RestService.For<IHuffmanApi>("https://huffmanweb.thognard.net/huffman"); // Ugly      
                var req = new DecodeRequest();
                req.BinaryHuffman = TextToDecode;
                req.MatchingCharacters = JsonSerializer.Deserialize<List<Character>>(MatchingTableJson)!;
                Response = await huffmanApi.Decode(req);
            }
            catch (Exception ex)
            {
                ErrorMessage = "Une erreur est survenue";
                ErrorType = ErrorTypeEnum.Error;

            }

        }

    }
}
