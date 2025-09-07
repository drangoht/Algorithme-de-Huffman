

using CommunityToolkit.Mvvm.ComponentModel;
using HuffmanPlayground.Mobile.Client.Enumerations;
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
