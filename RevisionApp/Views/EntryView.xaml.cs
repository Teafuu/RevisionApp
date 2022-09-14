namespace RevisionApp.Views;
public partial class EntryView : ContentView
{
    public static readonly BindableProperty EntryPlaceholderTextProperty = BindableProperty.Create(nameof(EntryPlaceholderText), typeof(string), typeof(EntryView), string.Empty);
    public static readonly BindableProperty EntryTextProperty = BindableProperty.Create(nameof(EntryText), typeof(string), typeof(EntryView), string.Empty);
    public static readonly BindableProperty EntryIsPasswordProperty = BindableProperty.Create(nameof(EntryIsPassword), typeof(bool), typeof(EntryView), false);

    public string EntryPlaceholderText
    {
        get => (string)GetValue(EntryPlaceholderTextProperty);
        set => SetValue(EntryPlaceholderTextProperty, value);
    }
    public string EntryText
    {
        get => (string)GetValue(EntryTextProperty);
        set => SetValue(EntryTextProperty, value);
    }
    public bool EntryIsPassword
    {
        get => (bool)GetValue(EntryIsPasswordProperty);
        set => SetValue(EntryIsPasswordProperty, value);
    }

    public EntryView()
    {
        InitializeComponent();
    }
}