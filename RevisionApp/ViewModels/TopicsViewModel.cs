using CommunityToolkit.Maui.Views;
using RevisionApp.Services;
using RevisionApp.Services.Dto.Response;
using RevisionApp.Views;
using System.Collections.ObjectModel;

namespace RevisionApp.ViewModels
{
    public class TopicsViewModel : BaseViewModel
    {
        private readonly RevisionService _service;

        static Page Page => Application.Current?.MainPage ?? throw new NullReferenceException();

        public ObservableCollection<Topic> Topics { get; set; }
        public Command CollectionChangeCommand => new Command(OnCollectionViewSelectionChanged);
        public Command AddTopicCommand => new Command(AddTopic);
        public Topic CurrentSelectedTopic { get; set; }
        public int SpanCount { get => _spanCount; set { _spanCount = value; OnPropertyChanged(nameof(_spanCount)); } }  // MAUI needs this to update UI

        private int _spanCount;

        public TopicsViewModel(RevisionService service)
        {
            _service = service;
            Topics = new ObservableCollection<Topic>();
        }

        public void OnCollectionViewSelectionChanged(object o)
        {
            if (o is null) return;
            var topic = o as Topic;
            var popup = new TopicPatchPopup(topic, _service, this);
            Page.ShowPopup(popup);
            CurrentSelectedTopic = null;
        }

        public void AddTopic()
        {
            var popup = new TopicCreatePopup(_service, this);
            Page.ShowPopup(popup);
        }

        public void FillTopics()
        {
            var topics = _service.GetTopics(UserManager.UserId);
            if (topics?.Topics is null) return;
            Topics.Clear();

            SpanCount = topics.Topics.Count > 1
                ? 2
                : 1;

            foreach(var topic in topics.Topics)
            {
                Topics.Add(topic);
            }
        }
    }
}
