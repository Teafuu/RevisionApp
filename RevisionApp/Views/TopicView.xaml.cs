
namespace RevisionApp.Views;

public partial class TopicView : ContentView
{
    public static readonly BindableProperty TopicTitleProperty = BindableProperty.Create(nameof(TopicTitle), typeof(string), typeof(TopicView), string.Empty);
    public static readonly BindableProperty TopicDescriptionProperty = BindableProperty.Create(nameof(TopicDescription), typeof(string), typeof(TopicView), string.Empty);

    public string TopicTitle
    {
        get => (string)GetValue(TopicTitleProperty);
        set => SetValue(TopicTitleProperty, value);
    }

    public string TopicDescription
    {
        get => (string)GetValue(TopicDescriptionProperty);
        set => SetValue(TopicDescriptionProperty, value);
    }
    public TopicView()
	{
		InitializeComponent();
	}
}