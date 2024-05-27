using HuffmanWeb.Common.DTOs.Requests;
using HuffmanWeb.Common.DTOs.Responses;
using Refit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Refit;
using HuffmanWeb.Mobile.Client.ApiInterfaces;
using HuffmanWeb.Common.DTOs.Requests;
namespace HuffmanWeb.Mobile.Client.Commands
{
    public class EncodeCommandViewModel : INotifyPropertyChanged
    {

            EncodeResponse response = new();
            string textToEncode = string.Empty;
            public event PropertyChangedEventHandler PropertyChanged;

            public ICommand CallEncodeApiCommand { get; private set; }

            public EncodeCommandViewModel()
            {
                CallEncodeApiCommand = new Command(
                    execute: (async) =>
                    {
                        var huffmanApi = RestService.For<IEncodeApi>("http://10.0.2.2:5041");
                        var req = new EncodeRequest();
                        req.TextToEncode = textToEncode;
                        Task.Run(async () =>
                        {
                            Response =await huffmanApi.Encode(req);
                        });

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
    }
}
