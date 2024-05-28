using HuffmanWeb.Mobile.Client.ViewModels;
namespace HuffmanWeb.Mobile.Client.Pages.Encode.Components;

public partial class EncodeForm : ContentPage
{
    public EncodeForm()
    {
		InitializeComponent();
        BindingContext = IPlatformApplication.Current.Services.GetService<EncodeViewModel>();
        textToEncode.Focus();
    }
    private void OnPageLoaded(object sender, EventArgs e)
    {
        textToEncode.Focus();
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