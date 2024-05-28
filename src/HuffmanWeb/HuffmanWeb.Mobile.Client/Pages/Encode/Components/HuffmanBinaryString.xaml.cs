namespace HuffmanWeb.Mobile.Client.Pages.Encode.Components;

public partial class HuffmanBinaryString : ContentView
{
	public HuffmanBinaryString()
	{
		InitializeComponent();
	}
    public static readonly BindableProperty HuffmanStringProperty =
           BindableProperty.Create(nameof(HuffmanString), typeof(string), typeof(HuffmanBinaryString), defaultValue: default(string), propertyChanged: OnHuffmanStringChanged);
    private static void OnHuffmanStringChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var view = (HuffmanBinaryString)bindable;
        view.HuffmanStringLbl.Text = (string)newValue;
    }
    public string HuffmanString
    {
        get => (string)GetValue(HuffmanStringProperty);
        set => SetValue(HuffmanStringProperty, value);
    }

}