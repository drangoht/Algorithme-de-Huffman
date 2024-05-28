using HuffmanWeb.Mobile.Client.ViewModels;
namespace HuffmanWeb.Mobile.Client.Pages.Encode.Components;

public partial class EncodeMatchingTable : ContentPage
{
    public EncodeMatchingTable()
    {
        InitializeComponent();
        BindingContext = IPlatformApplication.Current.Services.GetService<EncodeViewModel>();

    }
}