using HuffmanWeb.Mobile.Client.ViewModels;
using System.Text.Json;

namespace HuffmanWeb.Mobile.Client.Pages.Encode;

public partial class EncodeForm : ContentPage
{
    bool isPageLoaded = false;
    DecodeViewModel? decodeViewModel;

    public EncodeForm()
    {
        InitializeComponent();
        BindingContext = IPlatformApplication.Current?.Services.GetService<EncodeViewModel>();
        decodeViewModel = IPlatformApplication.Current?.Services.GetService<DecodeViewModel>();
        _ = textToEncode.Focus();
    }

    private void OnPageLoaded(object sender, EventArgs e)
    {
        if (isPageLoaded) return;
        _ = textToEncode.Focus();
        isPageLoaded = true;
    }

    private async void EncodeBtn_Clicked(object sender, EventArgs e)
    {
        textToEncode.Unfocus();
        MatchingTablebtn.IsVisible = false;
        TreeBtn.IsVisible = false;
        encodingStats.IsVisible = false;
        binaryString.IsVisible = false;
        copyToDecodeBtn.IsVisible = false;

        if (BindingContext is not EncodeViewModel viewModel)
        {
            await DisplayAlertAsync("Error", "Unable to initialize encode screen.", "OK");
            return;
        }

        if (!string.IsNullOrWhiteSpace(viewModel.TextToEncode))
        {
            await viewModel.CallEncodeAPI();
            MatchingTablebtn.IsVisible = true;
            TreeBtn.IsVisible = true;
            encodingStats.IsVisible = true;
            binaryString.IsVisible = true;
            copyToDecodeBtn.IsVisible = true;
        }
    }

    private async void MatchingTablebtn_Clicked(object sender, EventArgs e)
    {
        try
        {
            await Navigation.PushAsync(new EncodeMatchingTable());
        }
        catch
        {
            await DisplayAlertAsync("Error", "Unable to open matching table page.", "OK");
        }
    }

    private async void TreeBtn_Clicked(object sender, EventArgs e)
    {
        try
        {
            await Navigation.PushAsync(new EncodeTree());
        }
        catch
        {
            await DisplayAlertAsync("Error", "Unable to open tree page.", "OK");
        }
    }

    private void ResetBtn_Clicked(object sender, EventArgs e)
    {
        textToEncode.Text = string.Empty;
    }

    private void copyToDecodeBtn_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is not EncodeViewModel viewModel)
            return;

        if (decodeViewModel != null)
        {
            decodeViewModel.TextToDecode = binaryString.HuffmanString;
            decodeViewModel.MatchingTableJson = JsonSerializer.Serialize(viewModel.Response.MatchingCharacters);
        }
    }
}
