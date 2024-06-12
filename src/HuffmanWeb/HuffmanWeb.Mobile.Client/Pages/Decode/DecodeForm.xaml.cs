using HuffmanWeb.Mobile.Client.ViewModels;
namespace HuffmanWeb.Mobile.Client.Pages.Decode;

public partial class DecodeForm : ContentPage
{
    public DecodeForm()
    {
        InitializeComponent();
        BindingContext = IPlatformApplication.Current?.Services.GetService<DecodeViewModel>();
    }

    private void DecodeBtn_Clicked(object sender, EventArgs e)
    {
        var viewModel = (DecodeViewModel)BindingContext;
        if (!string.IsNullOrWhiteSpace(viewModel.TextToDecode) && !string.IsNullOrWhiteSpace(viewModel.MatchinTableJson))
        {
            if (viewModel.CallDecodeApiCommand.CanExecute(null))
            {
                viewModel.CallDecodeApiCommand.Execute(null);
            }
        }
    }
    private void ResetBtn_Clicked(object sender, EventArgs e)
    {
        textToDecode.Text = string.Empty;
        matchintTableJson.Text = string.Empty;
        decodedText.Text = string.Empty;
    }
}