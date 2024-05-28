using HuffmanWeb.Common.DTOs.Requests;
using HuffmanWeb.Common.DTOs.Responses;
using HuffmanWeb.Mobile.Client.ApiInterfaces;
using Refit;
using System.ComponentModel;
using System.Windows.Input;
namespace HuffmanWeb.Mobile.Client.ViewModels
{
    public class EncodeViewModel : INotifyPropertyChanged
    {

        EncodeResponse response = new();
        string textToEncode = string.Empty;
        decimal compressionPercent = 0;
        bool isBusy = false;

        public event PropertyChangedEventHandler? PropertyChanged;

        public ICommand CallEncodeApiCommand { get; private set; }

        public EncodeViewModel()
        {
            CallEncodeApiCommand = new Command(
                execute: (async) =>
                {
                    IsBusy = true;
                    var huffmanApi = RestService.For<IHuffmanApi>("https://huffmanweb.thognard.net/huffman"); // Ugly      
                    var req = new EncodeRequest();
                    req.TextToEncode = textToEncode;
                    Response = huffmanApi.Encode(req).Result;
                    CompressionPercent = response.OriginalSize > 0 ? ((1 - (decimal)((decimal)response.EncodedSize / (decimal)response.OriginalSize)) * (decimal)100) : 0;
                    IsBusy = false;
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
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Response)));
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
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TextToEncode)));
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
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CompressionPercent)));
            }
        }
        public bool IsBusy
        {
            get
            {
                return isBusy;
            }
            set
            {
                isBusy = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsBusy)));
            }
        }
    }
}
