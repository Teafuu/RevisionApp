using CommunityToolkit.Maui.Views;
using RevisionApp.Services;
using RevisionApp.Services.Dto.Response;

namespace RevisionApp.Views;
public partial class TopicPopup : Popup
{
	public Topic Topic { get; set; }
	public string Description => $"{Topic.Description}";
	public string ReminderCount => $"Revised so far: {Topic.ReminderCount}";
	public Color TopicColour => Color.Parse(Topic.Color);

	public Command NoCommand => new Command(OnNoPressed);
	public Command YesCommand => new Command(OnYesPressed);
    private readonly RevisionService _service;
	public TopicPopup(Topic topic, RevisionService service)
	{
		Topic = topic;
		_service = service;
		BindingContext = this;
		InitializeComponent();
	}    

	public void OnNoPressed()
	{
		Close();
	}
	public void OnYesPressed()
	{
        Close();
    }
}