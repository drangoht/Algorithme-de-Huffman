using HuffmanPlayground.Mobile.Client.Enumerations;
using HuffmanWeb.Common.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
namespace HuffmanWeb.Mobile.Client.ViewModels
{
    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        ErrorTypeEnum errorType = ErrorTypeEnum.None;

        [ObservableProperty]
        string errorMessage = string.Empty;


    }
}
