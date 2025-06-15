using HuffmanWeb.Mobile.Client.ViewModels;
namespace HuffmanWeb.Mobile.Client.Pages.Encode;
using System.Text.Json;

public partial class EncodeForm : ContentPage
{
    bool isPageLoaded = false;
    DecodeViewModel? decodeViewModel;
    public EncodeForm()
    {
        InitializeComponent();
        BindingContext = IPlatformApplication.Current?.Services.GetService<EncodeViewModel>();
        decodeViewModel = IPlatformApplication.Current?.Services.GetService<DecodeViewModel>();
        textToEncode.Focus();
    }
    private void OnPageLoaded(object sender, EventArgs e)
    {
        if (isPageLoaded) return;
        textToEncode.Focus();
        isPageLoaded = true;
    }
    private void EncodeBtn_Clicked(object sender, EventArgs e)
    {
        textToEncode.Unfocus();
        MatchingTablebtn.IsVisible = false;
        TreeBtn.IsVisible = false;
        encodingStats.IsVisible = false;
        binaryString.IsVisible = false;
        copyToDecodeBtn.IsVisible = false;

        var viewModel = (EncodeViewModel)BindingContext;
        if (!string.IsNullOrWhiteSpace(viewModel.TextToEncode))
        {
            viewModel.CallEncodeAPICommand.Execute(null);
            MatchingTablebtn.IsVisible = true;
            TreeBtn.IsVisible = true;
            encodingStats.IsVisible = true;
            binaryString.IsVisible = true;
            copyToDecodeBtn.IsVisible = true;
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

    private void copyToDecodeBtn_Clicked(object sender, EventArgs e)
    {
        var viewModel = (EncodeViewModel)BindingContext;
        if (decodeViewModel != null)
        {
            decodeViewModel.TextToDecode = binaryString.HuffmanString;
            decodeViewModel.MatchingTableJson = JsonSerializer.Serialize(viewModel.Response.MatchingCharacters);
        }
    }
}