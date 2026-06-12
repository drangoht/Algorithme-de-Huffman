using CommunityToolkit.Mvvm.ComponentModel;

namespace HuffmanWeb.Mobile.Client.ViewModels
{
    public partial class EncodeTreeViewModel : BaseViewModel
    {
        [ObservableProperty] int nodeWidth = 48;
        [ObservableProperty] int nodeHeight = 36;
        [ObservableProperty] Color nodeColor = Colors.Silver;
        [ObservableProperty] Color nodeTextColor = Colors.Black;
        [ObservableProperty] Color lineColor = Colors.Black;
        [ObservableProperty] Color lineTextColor = Colors.Gray;
    }
}
