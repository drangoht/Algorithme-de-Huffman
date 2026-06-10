using HuffmanWeb.Mobile.Client.ViewModels;

namespace HuffmanWeb.Mobile.Client.Pages.Decode;

public partial class DecodeForm : ContentPage
{
    public DecodeForm()
    {
        InitializeComponent();
        BindingContext = IPlatformApplication.Current?.Services.GetService<DecodeViewModel>();
        _ = textToDecode.Focus();
    }

    private void OnPageLoaded(object sender, EventArgs e)
    {
        _ = textToDecode.Focus();
    }

    private async void DecodeBtn_Clicked(object sender, EventArgs e)
    {
        textToDecode.Unfocus();
        matchingTableJson.Unfocus();

        if (BindingContext is not DecodeViewModel viewModel)
        {
            await DisplayAlert("Error", "Unable to initialize decode screen.", "OK");
            return;
        }

        if (!string.IsNullOrWhiteSpace(viewModel.TextToDecode) && !string.IsNullOrWhiteSpace(viewModel.MatchingTableJson))
        {
            await viewModel.CallDecodeAPI();
        }
    }

    private void ResetBtn_Clicked(object sender, EventArgs e)
    {
        textToDecode.Text = string.Empty;
        matchingTableJson.Text = string.Empty;
        decodedText.Text = string.Empty;
    }
}
