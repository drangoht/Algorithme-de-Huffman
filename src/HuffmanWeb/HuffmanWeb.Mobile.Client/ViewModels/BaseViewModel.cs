
/* Unmerged change from project 'HuffmanWeb.Mobile.Client (net8.0-android)'
Before:
using HuffmanPlayground.Mobile.Client.Enumerations;
After:
using CommunityToolkit.Mvvm.ComponentModel;
using HuffmanPlayground.Mobile.Client.Enumerations;
*/
using CommunityToolkit.Mvvm.ComponentModel;
using HuffmanPlayground.Mobile.
/* Unmerged change from project 'HuffmanWeb.Mobile.Client (net8.0-android)'
Before:
using CommunityToolkit.Mvvm.ComponentModel;
namespace HuffmanWeb.Mobile.Client.ViewModels
After:
namespace HuffmanWeb.Mobile.Client.ViewModels
*/
Client.Enumerations;
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
