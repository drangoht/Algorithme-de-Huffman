using HuffmanWeb.Mobile.Client.ViewModels;
namespace HuffmanWeb.Mobile.Client.Pages.Encode;

public partial class EncodeForm : ContentPage
{
    bool isPageLoaded = false;
    public EncodeForm()
    {
        InitializeComponent();
        BindingContext = IPlatformApplication.Current?.Services.GetService<EncodeViewModel>();
        textToEncode.Focus();
    }
    private void OnPageLoaded(object sender, EventArgs e)
    {
        if (isPageLoaded) return;
        textToEncode.Focus();
        isPageLoaded = true;
    }
    private async void EncodeBtn_Clicked(object sender, EventArgs e)
    {
        textToEncode.Unfocus();
        if (textToEncode.IsSoftInputShowing())
            await textToEncode.HideSoftInputAsync(System.Threading.CancellationToken.None);

        var viewModel = (EncodeViewModel)BindingContext;
        if (viewModel.CallEncodeApiCommand.CanExecute(null))
            viewModel.CallEncodeApiCommand.Execute(null);
    }
}