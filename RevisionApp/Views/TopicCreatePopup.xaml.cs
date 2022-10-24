using CommunityToolkit.Maui.Views;
using RevisionApp.Services;
using RevisionApp.Services.Dto.Request;
using RevisionApp.Services.Dto.Response;
using RevisionApp.ViewModels;

namespace RevisionApp.Views;
public partial class TopicCreatePopup : Popup
{
    public string TopicTitle { get; set; }
    public string TopicDescription { get; set; }
	public DateTime TopicDate { get; set; }
	public Command CancelCommand => new(OnCancelPressed);
	public Command CreateCommand => new(OnCreatePressed);
	public string ChosenColor { get; set; }

    private readonly RevisionService _service;
    private readonly TopicsViewModel _model;

    public TopicCreatePopup(RevisionService service, TopicsViewModel model)
	{
		_service = service;
        _model = model;
        TopicDate = DateTime.Now;
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
	public void OnCreatePressed()
	{
		_service.CreateTopic(new CreateTopicRequest
		{
			Color = ChosenColor,
			Description = TopicDescription,
			Title = TopicTitle,
			UserId = UserManager.UserId,
			RevisionDateTime = TopicDate,
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