namespace HuffmanWeb.Mobile.Client.Pages.Encode.Components;

public partial class EncodingStatsDisplay : ContentView
{
    public EncodingStatsDisplay()
    {
        InitializeComponent();
    }

    public static readonly BindableProperty EncodedSizeProperty =
            BindableProperty.Create(nameof(EncodedSize), typeof(int), typeof(EncodingStatsDisplay), defaultValue: default(int), propertyChanged: OnEncodedSizeChanged);
    public static readonly BindableProperty OriginalSizeProperty =
            BindableProperty.Create(nameof(OriginalSize), typeof(int), typeof(EncodingStatsDisplay), defaultValue: default(int), propertyChanged: OnOriginalSizeChanged);
    public static readonly BindableProperty CompressionPercentProperty =
            BindableProperty.Create(nameof(CompressionPercent), typeof(decimal), typeof(EncodingStatsDisplay), defaultValue: default(decimal), propertyChanged: OnCompressionPercentChanged);
    private static void OnOriginalSizeChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var view = (EncodingStatsDisplay)bindable;
        view.OriginalSizeLbl.Text = $"Taille origine:{newValue}";
    }

    private static void OnEncodedSizeChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var view = (EncodingStatsDisplay)bindable;
        view.EncodedSizeLbl.Text = $"Taille encodée:{newValue}";
    }

    private static void OnCompressionPercentChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var view = (EncodingStatsDisplay)bindable;
        view.CompressionPercentLbl.Text = $"Gain:{string.Format("{0:0.00}%", newValue)}";
    }
    public int OriginalSize
    {
        get => (int)GetValue(OriginalSizeProperty);
        set => SetValue(OriginalSizeProperty, value);
    }
    public int EncodedSize
    {
        get => (int)GetValue(EncodedSizeProperty);
        set => SetValue(EncodedSizeProperty, value);
    }
    public decimal CompressionPercent
    {
        get => (decimal)GetValue(CompressionPercentProperty);
        set => SetValue(CompressionPercentProperty, value);
    }
}
