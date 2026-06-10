using CommunityToolkit.Mvvm.ComponentModel;

namespace HuffmanWeb.Mobile.Client.ViewModels
{
    public partial class EncodeTreeViewModel : BaseViewModel
    {
        [ObservableProperty] int treeWidth = 4000;
        [ObservableProperty] int treeHeight = 2000;
        [ObservableProperty] int nodeWidth = 40;
        [ObservableProperty] int nodeHeight = 20;
        [ObservableProperty] Color nodeColor = Colors.Silver;
        [ObservableProperty] Color nodeTextColor = Colors.Black;
        [ObservableProperty] Color lineColor = Colors.Black;
        [ObservableProperty] Color lineTextColor = Colors.Silver;
    }
}
