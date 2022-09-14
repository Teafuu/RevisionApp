namespace RevisionApp.Views;

using Microsoft.Maui.Graphics;
public partial class TopicView : ContentView
{
    public static readonly BindableProperty TopicTitleProperty = BindableProperty.Create(nameof(TopicTitle), typeof(string), typeof(TopicView), string.Empty);
    public static readonly BindableProperty TopicColourProperty = BindableProperty.Create(nameof(TopicColour), typeof(Color), typeof(TopicView), Color.Parse("White"));

    public string TopicTitle
    {
        get => (string)GetValue(TopicTitleProperty);
        set => SetValue(TopicTitleProperty, value);
    }

    public Color TopicColour
    {
        get => (Color)GetValue(TopicColourProperty);
        set => SetValue(TopicColourProperty, value);
    }

    public TopicView()
	{
		InitializeComponent();
	}
}