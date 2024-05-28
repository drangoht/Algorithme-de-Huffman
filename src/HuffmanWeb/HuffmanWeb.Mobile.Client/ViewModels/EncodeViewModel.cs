using HuffmanWeb.Common.DTOs.Requests;
using HuffmanWeb.Common.DTOs.Responses;
using Refit;
using System.ComponentModel;
using System.Windows.Input;
using HuffmanWeb.Mobile.Client.ApiInterfaces;
namespace HuffmanWeb.Mobile.Client.ViewModels
{
    public class EncodeViewModel : INotifyPropertyChanged
    {

            EncodeResponse response = new();
            string textToEncode = string.Empty;
            decimal compressionPercent = 0;

            public event PropertyChangedEventHandler? PropertyChanged;

            public ICommand CallEncodeApiCommand { get; private set; }
        
        public EncodeViewModel()
            {
                CallEncodeApiCommand = new Command(
                    execute: (async) =>
                    {
                        var huffmanApi = RestService.For<IHuffmanApi>("https://huffmanweb.thognard.net/huffman"); // Ugly      
                        var req = new EncodeRequest();
                        req.TextToEncode = textToEncode;
                        Response = huffmanApi.Encode(req).Result;
                        CompressionPercent = response.OriginalSize > 0 ? ((1 - (decimal)((decimal)response.EncodedSize / (decimal)response.OriginalSize)) * (decimal)100) : 0;
                    },
                    canExecute: (async) => response != null
                );
            }

            public EncodeResponse Response
            {
                get
                {
                    return response;
                }
                set
                {
                    response = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Response"));
                }
            }
        public string TextToEncode
        {
            get
            {
                return textToEncode;
            }
            set
            {
                textToEncode = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TextToEncode"));
            }
        }
        public decimal CompressionPercent
        {
            get
            {
                return compressionPercent;
            }
            set
            {
                compressionPercent = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CompressionPercent"));
            }
        }
    }
}
