using CommunityToolkit.Maui.Views;
using RevisionApp.Services;
using RevisionApp.Services.Dto.Response;
using RevisionApp.ViewModels;

namespace RevisionApp.Views;
public partial class TopicPopup : Popup
{
	public Topic Topic { get; set; }
	public string Description => $"{Topic.Description}";
	public string ReminderCount => $"Revised so far: {Topic.ReminderCount}";
	public Color TopicColour => Color.Parse(Topic.Color);

	public Command NoCommand => new(OnNoPressed);
	public Command YesCommand => new(OnYesPressed);
    private readonly RevisionService _service;
    private readonly HomeViewModel _model;

    public TopicPopup(Topic topic, RevisionService service, HomeViewModel model)
	{
		Topic = topic;
		_service = service;
        _model = model;
        BindingContext = this;
		InitializeComponent();
	}    

	public void OnNoPressed()
	{
		Close();
	}
	public void OnYesPressed()
	{
        _service.Revise(Topic.Id, Topic.UserId);
        _model.FillTopics();
        Close();
    }
}