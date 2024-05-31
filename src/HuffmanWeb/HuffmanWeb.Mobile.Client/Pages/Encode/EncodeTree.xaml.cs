using HuffmanWeb.Mobile.Client.ViewModels;
using Microsoft.Maui;
using Microsoft.Maui.Controls;

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
}