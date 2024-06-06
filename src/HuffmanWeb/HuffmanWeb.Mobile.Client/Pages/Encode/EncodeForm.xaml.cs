using HuffmanWeb.Mobile.Client.ViewModels;
namespace HuffmanWeb.Mobile.Client.Pages.Encode;
using CommunityToolkit.Maui.Core.Platform;
public partial class EncodeForm : ContentPage
{
    bool isPageLoaded = false;
    public EncodeForm()
    {
        InitializeComponent();
        BindingContext = IPlatformApplication.Current?.Services.GetService<EncodeViewModel>();
        //textToEncode.Focus();
    }
    private void OnPageLoaded(object sender, EventArgs e)
    {
        if (isPageLoaded) return;
        //textToEncode.Focus();
        isPageLoaded = true;
    }
    private async void EncodeBtn_Clicked(object sender, EventArgs e)
    {
        //textToEncode.Unfocus();
        MatchingTablebtn.IsVisible = false;
        TreeBtn.IsVisible = false;

        var viewModel = (EncodeViewModel)BindingContext;
        if (viewModel.CallEncodeApiCommand.CanExecute(null))
        {
            viewModel.CallEncodeApiCommand.Execute(null);
            MatchingTablebtn.IsVisible = true;
            TreeBtn.IsVisible = true;
        }
    }

    private async void MatchingTablebtn_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new EncodeMatchingTable());
    }

    private async void TreeBtn_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new EncodeTree());
    }

    private void ResetBtn_Clicked(object sender, EventArgs e)
    {
        textToEncode.Text = string.Empty;
    }
}