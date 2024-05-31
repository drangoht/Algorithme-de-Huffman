using HuffmanWeb.Mobile.Client.ViewModels;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using System.IO;

namespace HuffmanWeb.Mobile.Client.Pages.Encode;

public partial class EncodeTree : ContentPage
{
    private double startScale;
    private double currentScale;
    public EncodeTree()
    {
        InitializeComponent();
        BindingContext = IPlatformApplication.Current?.Services.GetService<EncodeViewModel>();

    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        IScreenshotResult screenshotResult = await binaryTree.CaptureAsync();
        binaryTreeImage.Source = ImageSource.FromStream(async (async) => await screenshotResult.OpenReadAsync());
    }
}