using HuffmanWeb.Mobile.Client.ViewModels;

namespace HuffmanWeb.Mobile.Client.Pages.Encode;

public partial class EncodeTree : ContentPage
{
    public EncodeTree()
    {
        InitializeComponent();
        BindingContext = new EncodeTreeBindingContext()
        {
            TreeViewModel = IPlatformApplication.Current?.Services.GetService<EncodeTreeViewModel>(),
            ViewModel = IPlatformApplication.Current?.Services.GetService<EncodeViewModel>()
        };
    }

    private void OnPanUpdated(object sender, PanUpdatedEventArgs e)
    {
        binaryTree.TranslationX += e.TotalX;
        binaryTree.TranslationY += e.TotalY;
        HideSettings();
    }

    private void refreshBtn_Clicked(object sender, EventArgs e)
    {
        RefreshTree();
    }
    private void RefreshTree()
    {
        var currBindingContext = ((EncodeTreeBindingContext)BindingContext);
        binaryTree.WidthRequest = currBindingContext.TreeViewModel!.TreeWidth;
        binaryTree.HeightRequest = currBindingContext.TreeViewModel!.TreeHeight;
        binaryTree.NodeWidth = currBindingContext.TreeViewModel!.NodeWidth;
        binaryTree.NodeHeight = currBindingContext.TreeViewModel!.NodeHeight;
        binaryTree.Invalidate();
        HideSettings();
    }
    private void settingsToolsBarItem_Clicked(object sender, EventArgs e) =>
        settingsGrid.IsVisible = !settingsGrid.IsVisible;

    private void HideSettings() =>
        settingsGrid.IsVisible = false;


    private void NodeColor_PickedColorChanged(object sender, Maui.ColorPicker.PickedColorChangedEventArgs e)
    {
        var currBindingContext = ((EncodeTreeBindingContext)BindingContext);
        binaryTree.NodeColor = e.NewPickedColorValue;
        currBindingContext.TreeViewModel!.NodeColor = e.NewPickedColorValue;
        binaryTree.Invalidate();
    }

    private void NodeTextColor_PickedColorChanged(object sender, Maui.ColorPicker.PickedColorChangedEventArgs e)
    {
        var currBindingContext = ((EncodeTreeBindingContext)BindingContext);
        binaryTree.NodeTextColor = e.NewPickedColorValue;
        currBindingContext.TreeViewModel!.NodeTextColor = e.NewPickedColorValue;
        binaryTree.Invalidate();
    }

    private void LineColor_PickedColorChanged(object sender, Maui.ColorPicker.PickedColorChangedEventArgs e)
    {
        var currBindingContext = ((EncodeTreeBindingContext)BindingContext);
        binaryTree.LineColor = e.NewPickedColorValue;
        currBindingContext.TreeViewModel!.Linecolor = e.NewPickedColorValue;
        binaryTree.Invalidate();
    }
    private void LineTextColor_PickedColorChanged(object sender, Maui.ColorPicker.PickedColorChangedEventArgs e)
    {
        var currBindingContext = ((EncodeTreeBindingContext)BindingContext);
        binaryTree.LineTextColor = e.NewPickedColorValue;
        currBindingContext.TreeViewModel!.LineTextColor = e.NewPickedColorValue;
        binaryTree.Invalidate();
    }
    private void treeWidth_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        var currBindingContext = ((EncodeTreeBindingContext)BindingContext);
        binaryTree.WidthRequest = (int)e.NewValue;
        binaryTree.Invalidate();
    }

    private void treeHeight_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        var currBindingContext = ((EncodeTreeBindingContext)BindingContext);
        binaryTree.HeightRequest = (int)e.NewValue;
        binaryTree.Invalidate();
    }

    private void nodewidth_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        var currBindingContext = ((EncodeTreeBindingContext)BindingContext);
        binaryTree.NodeWidth = (int)e.NewValue;
        binaryTree.Invalidate();
    }

    private void nodeHeight_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        var currBindingContext = ((EncodeTreeBindingContext)BindingContext);
        binaryTree.NodeHeight = (int)e.NewValue;
        binaryTree.Invalidate();
    }
}
public class EncodeTreeBindingContext
{
    public EncodeTreeViewModel? TreeViewModel { get; set; }
    public EncodeViewModel? ViewModel { get; set; }
}