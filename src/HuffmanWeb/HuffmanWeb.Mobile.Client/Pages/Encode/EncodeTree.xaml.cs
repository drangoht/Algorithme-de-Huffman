using System.ComponentModel;
using HuffmanWeb.Mobile.Client.ViewModels;

namespace HuffmanWeb.Mobile.Client.Pages.Encode;

public partial class EncodeTree : ContentPage
{
    private readonly EncodeTreeBindingContext _context;
    private bool _treeCentered;

    public EncodeTree()
    {
        InitializeComponent();
        _context = new EncodeTreeBindingContext
        {
            TreeViewModel = IPlatformApplication.Current?.Services.GetService<EncodeTreeViewModel>(),
            ViewModel = IPlatformApplication.Current?.Services.GetService<EncodeViewModel>()
        };
        BindingContext = _context;

        if (_context.ViewModel is not null)
            _context.ViewModel.PropertyChanged += OnEncodeViewModelPropertyChanged;
        binaryTree.SizeChanged += OnTreeSizeChanged;
    }

    private void OnEncodeViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        // A new encoding produces a new tree: re-center once it is laid out.
        if (e.PropertyName == nameof(EncodeViewModel.Response))
            _treeCentered = false;
    }

    private async void OnTreeSizeChanged(object? sender, EventArgs e)
    {
        if (_treeCentered || treeScroll.Width <= 0 || binaryTree.Width <= 0) return;
        _treeCentered = true;
        var targetX = Math.Max(0, (binaryTree.Width - treeScroll.Width) / 2);
        await treeScroll.ScrollToAsync(targetX, 0, false);
    }

    private void settingsToolsBarItem_Clicked(object sender, EventArgs e) =>
        settingsGrid.IsVisible = !settingsGrid.IsVisible;

    private void NodeColor_PickedColorChanged(object sender, Maui.ColorPicker.PickedColorChangedEventArgs e)
    {
        if (_context.TreeViewModel is not null)
            _context.TreeViewModel.NodeColor = e.NewPickedColorValue;
    }

    private void NodeTextColor_PickedColorChanged(object sender, Maui.ColorPicker.PickedColorChangedEventArgs e)
    {
        if (_context.TreeViewModel is not null)
            _context.TreeViewModel.NodeTextColor = e.NewPickedColorValue;
    }
}

public class EncodeTreeBindingContext
{
    public EncodeTreeViewModel? TreeViewModel { get; set; }
    public EncodeViewModel? ViewModel { get; set; }
}
