using HuffmanWeb.Mobile.Client.ViewModels;
using Microsoft.Maui.Controls;

namespace HuffmanWeb.Mobile.Client.Pages.Encode;

public partial class EncodeTree : ContentPage
{
    public EncodeTree()
    {
        InitializeComponent();
        BindingContext = IPlatformApplication.Current?.Services.GetService<EncodeViewModel>();

    }

    private void OnPanUpdated(object sender, PanUpdatedEventArgs e)
    {
        binaryTree.TranslationX += e.TotalX;
        binaryTree.TranslationY += e.TotalY;
    }
}