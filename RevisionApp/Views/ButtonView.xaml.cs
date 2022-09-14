using System.Windows.Input;

namespace RevisionApp.Views;
public partial class ButtonView : ContentView
{
    public static readonly BindableProperty ButtonTextProperty = BindableProperty.Create(nameof(ButtonText), typeof(string), typeof(ButtonView), string.Empty);
    public static readonly BindableProperty ButtonColourProperty = BindableProperty.Create(nameof(ButtonColour), typeof(Color), typeof(ButtonView), Color.Parse("Green"));
    public static readonly BindableProperty ButtonCommandProperty = BindableProperty.Create(nameof(ButtonCommand), typeof(ICommand), typeof(ButtonView), null);

    public string ButtonText
    {
        get => (string)GetValue(ButtonTextProperty);
        set => SetValue(ButtonTextProperty, value);
    }
    public Color ButtonColour
    {
        get => (Color)GetValue(ButtonColourProperty);
        set => SetValue(ButtonColourProperty, value);
    }

    public ICommand ButtonCommand
    {
        get => (ICommand)GetValue(ButtonCommandProperty);
        set => SetValue(ButtonCommandProperty, value);
    }
    public ButtonView()
    {
        InitializeComponent();
    }
}