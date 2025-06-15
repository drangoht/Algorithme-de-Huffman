using HuffmanWeb.Mobile.Client.ViewModels;
namespace HuffmanWeb.Mobile.Client.Pages.Decode;

public partial class DecodeForm : ContentPage
{
    public DecodeForm()
    {
        InitializeComponent();
        BindingContext = IPlatformApplication.Current?.Services.GetService<DecodeViewModel>();
        textToDecode.Focus();
    }
    private void OnPageLoaded(object sender, EventArgs e)
    {
        textToDecode.Focus();
    }
    private void DecodeBtn_Clicked(object sender, EventArgs e)
    {
        textToDecode.Unfocus();
        matchingTableJson.Unfocus();
        var viewModel = (DecodeViewModel)BindingContext;
        if (!string.IsNullOrWhiteSpace(viewModel.TextToDecode) && !string.IsNullOrWhiteSpace(viewModel.MatchingTableJson))
        {
            viewModel.CallDecodeAPICommand.Execute(null);
        }
    }
    private void ResetBtn_Clicked(object sender, EventArgs e)
    {
        textToDecode.Text = string.Empty;
        matchingTableJson.Text = string.Empty;
        decodedText.Text = string.Empty;
    }
}