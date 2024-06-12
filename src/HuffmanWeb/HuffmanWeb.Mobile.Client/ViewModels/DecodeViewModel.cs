using HuffmanWeb.Common.DTOs;
using HuffmanWeb.Common.DTOs.Requests;
using HuffmanWeb.Common.DTOs.Responses;
using HuffmanWeb.Mobile.Client.ApiInterfaces;
using Refit;
using System.ComponentModel;
using System.Text.Json;
using System.Windows.Input;
namespace HuffmanWeb.Mobile.Client.ViewModels
{
    public class DecodeViewModel : INotifyPropertyChanged
    {

        DecodeResponse response = new();
        string textToDecode = string.Empty;
        string matchingTableJson = string.Empty;
        decimal compressionPercent = 0;

        public event PropertyChangedEventHandler? PropertyChanged;

        public ICommand CallDecodeApiCommand { get; private set; }
        private bool isWorking;

        public DecodeViewModel()
        {
            CallDecodeApiCommand = new Command(
                execute: async (async) =>
                {
                    IsWorking = true;
                    Response = new();
                    var huffmanApi = RestService.For<IHuffmanApi>("https://huffmanweb.thognard.net/huffman"); // Ugly      
                    var req = new DecodeRequest();
                    req.BinaryHuffman = textToDecode;
                    req.MatchingCharacters = JsonSerializer.Deserialize<List<Character>>(matchingTableJson)!;
                    Response = await huffmanApi.Decode(req);
                    IsWorking = false;
                },
                canExecute: (async) => response != null
            );
        }

        public DecodeResponse Response
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
        public string TextToDecode
        {
            get
            {
                return textToDecode;
            }
            set
            {
                textToDecode = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TextToDecode)));
            }
        }
        public string MatchinTableJson
        {
            get
            {
                return matchingTableJson;
            }
            set
            {
                matchingTableJson = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(MatchinTableJson)));
            }
        }

        public bool IsWorking
        {
            get => isWorking;
            set
            {
                isWorking = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsWorking)));
            }
        }
    }
}
