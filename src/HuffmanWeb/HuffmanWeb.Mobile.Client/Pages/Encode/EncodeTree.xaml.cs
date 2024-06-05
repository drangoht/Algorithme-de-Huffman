using HuffmanWeb.Mobile.Client.ViewModels;
using Microsoft.Maui.Controls;

namespace HuffmanWeb.Mobile.Client.Pages.Encode;

public partial class EncodeTree : ContentPage
{
    //public EncodeTreeViewModel? TreeViewModel { get; set; }
    public EncodeTree()
    {
        InitializeComponent();
        BindingContext = new EncodeTreeBindingContext()
        {
            TreeViewModel = IPlatformApplication.Current?.Services.GetService<EncodeTreeViewModel>(),
            ViewModel = IPlatformApplication.Current?.Services.GetService<EncodeViewModel>()
        };
        //BindingContext = IPlatformApplication.Current?.Services.GetService<EncodeViewModel>();
        //TreeViewModel = IPlatformApplication.Current?.Services.GetService<EncodeTreeViewModel>();
    }

    private void OnPanUpdated(object sender, PanUpdatedEventArgs e)
    {
        binaryTree.TranslationX += e.TotalX;
        binaryTree.TranslationY += e.TotalY;
        settingsGrid.IsVisible = false;
    }

    private void refreshBtn_Clicked(object sender, EventArgs e)
    {
        var currBindingContext = ((EncodeTreeBindingContext)BindingContext);
        binaryTree.WidthRequest = currBindingContext.TreeViewModel!.TreeWidth;
        binaryTree.HeightRequest = currBindingContext.TreeViewModel!.TreeHeight;
        binaryTree.NodeWidth = currBindingContext.TreeViewModel!.NodeWidth;
        binaryTree.NodeHeight = currBindingContext.TreeViewModel!.NodeHeight;
        settingsGrid.IsVisible = false;
        binaryTree.Invalidate();
    }

    private void settingsToolsBarItem_Clicked(object sender, EventArgs e) =>
        settingsGrid.IsVisible = !settingsGrid.IsVisible;
}
public class EncodeTreeBindingContext
{
    public EncodeTreeViewModel? TreeViewModel { get; set; }
    public EncodeViewModel? ViewModel { get; set; }
}