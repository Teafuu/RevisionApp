using CommunityToolkit.Maui.Views;
using RevisionApp.Services;
using RevisionApp.Services.Dto.Request;
using RevisionApp.Services.Dto.Response;

namespace RevisionApp.Views;
public partial class TopicPatchPopup : Popup
{
	public Topic Topic { get; set; }
    public string TopicTitle => $"{Topic.Title}";
    public string TopicDescription => $"{Topic.Description}";
	public DateTime TopicDate => Topic.RevisionDateTime;
	public Color TopicColour => Color.Parse(Topic.Color);

	public Command CancelCommand => new Command(OnCancelPressed);
	public Command UpdateCommand => new Command(OnUpdatePressed);
	public string ChosenColor { get; set; }

    private readonly RevisionService _service;

	public TopicPatchPopup(Topic topic, RevisionService service)
	{

		Topic = topic;
		_service = service;
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
			UserId = Topic.UserId
		});
        Close();
    }

	private void Picker_SelectedIndexChanged(object sender, EventArgs e)
	{
		var picker = (Picker)sender;

		picker.TextColor = Color.Parse((string)picker.SelectedItem);
		picker.TitleColor = Color.Parse((string)picker.SelectedItem);
    }
}