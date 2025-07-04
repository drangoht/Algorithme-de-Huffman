﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HuffmanPlayground.Mobile.Client.Enumerations;
using HuffmanWeb.Common.DTOs.Requests;
using HuffmanWeb.Common.DTOs.Responses;
using HuffmanWeb.Mobile.Client.ApiInterfaces;
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
        [ObservableProperty]
        bool isWorking = false;
        [RelayCommand]
        public async Task CallEncodeAPI() // Corrected spelling of 'Api' to 'API'
        {
            try
            {
                IsWorking = true;
                Response = new();
                var huffmanAPI = RestService.For<IHuffmanApi>("https://huffmanweb.thognard.net/huffman"); // Corrected spelling of 'Api' to 'API'
                var req = new EncodeRequest();
                req.TextToEncode = TextToEncode;
                Response = await huffmanAPI.Encode(req);
                CompressionPercent = Response.OriginalSize > 0 ? ((1 - (decimal)((decimal)Response.EncodedSize / (decimal)Response.OriginalSize)) * (decimal)100) : 0;
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
