using CommunityToolkit.Maui.Views;
using RevisionApp.Services;
using RevisionApp.Services.Dto.Request;
using RevisionApp.Services.Dto.Response;
using RevisionApp.ViewModels;

namespace RevisionApp.Views;
public partial class TopicPatchPopup : Popup
{
	public Topic Topic { get; set; }
    public string TopicTitle { get; set; }
    public string TopicDescription { get; set; }
	public DateTime TopicDate { get; set; }
	public Color TopicColour => Color.Parse(Topic.Color);

	public Command CancelCommand => new(OnCancelPressed);
	public Command UpdateCommand => new(OnUpdatePressed);
	public string ChosenColor { get; set; }

    private readonly RevisionService _service;
    private readonly TopicsViewModel _model;

    public TopicPatchPopup(Topic topic, RevisionService service, TopicsViewModel model)
	{
		_service = service;
        _model = model;

        Topic = topic;
		TopicTitle = topic.Title;
		TopicDescription = topic.Description;
		TopicDate = topic.RevisionDateTime;
		BindingContext = this;
		InitializeComponent();
	}
    void OnColorsRadioButtonCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
		var radioButton = (RadioButton)sender;
		ChosenColor = radioButton.TextColor.ToHex();
    }
    public void OnCancelPressed()
	{
		Close();
	}
	public void OnUpdatePressed()
	{
		_service.PatchTopic(new PatchTopicRequest
		{
			Color = ChosenColor ?? Topic.Color,
			Description = TopicDescription,
			Title = TopicTitle,
			Id = Topic.Id,
			RevisionDateTime = TopicDate,
			UserId = UserManager.UserId,
		});

		_model.FillTopics();
        Close();
    }

	private void Picker_SelectedIndexChanged(object sender, EventArgs e)
	{
		var picker = (Picker)sender;

		picker.TextColor = Color.Parse((string)picker.SelectedItem);
		picker.TitleColor = Color.Parse((string)picker.SelectedItem);
    }
}