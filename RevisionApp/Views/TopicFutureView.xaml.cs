namespace RevisionApp.Views;

using Microsoft.Maui.Graphics;
public partial class TopicFutureView : ContentView
{
    public static readonly BindableProperty TopicTitleProperty = BindableProperty.Create(nameof(TopicTitle), typeof(string), typeof(TopicFutureView), string.Empty);
    public static readonly BindableProperty TopicRevisionDateProperty = BindableProperty.Create(nameof(TopicRevisionDate), typeof(string), typeof(TopicFutureView), string.Empty);
    public static readonly BindableProperty TopicColourProperty = BindableProperty.Create(nameof(TopicColour), typeof(Color), typeof(TopicFutureView), Color.Parse("White"));
    
    public Color TopicColour
    {
        get => (Color)GetValue(TopicColourProperty);
        set => SetValue(TopicColourProperty, value);
    }

    public string TopicTitle
    {
        get => (string)GetValue(TopicTitleProperty);
        set => SetValue(TopicTitleProperty, value);
    }

    public string TopicRevisionDate
    {
        get => (string)GetValue(TopicRevisionDateProperty);
        set => SetValue(TopicRevisionDateProperty, value);
    }

    public TopicFutureView()
	{
		InitializeComponent();
	}
}