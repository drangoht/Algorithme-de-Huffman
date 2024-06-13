using HuffmanWeb.Mobile.Client.Pages.Decode;
using HuffmanWeb.Mobile.Client.Pages.Encode;
namespace HuffmanWeb.Mobile.Client
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }



        private async void EncodeBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EncodeForm());
        }

        private async void DecodeBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DecodeForm());
        }
    }

}
