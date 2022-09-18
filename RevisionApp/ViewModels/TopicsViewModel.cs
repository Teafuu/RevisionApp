using CommunityToolkit.Maui.Views;
using RevisionApp.Services;
using RevisionApp.Services.Dto.Response;
using RevisionApp.Views;
using System.Collections.ObjectModel;

namespace RevisionApp.ViewModels
{
    public class TopicsViewModel
    {
        private readonly RevisionService _service;

        static Page Page => Application.Current?.MainPage ?? throw new NullReferenceException();

        public ObservableCollection<Topic> Topics { get; set; }
        public Command CollectionChangeCommand => new Command(OnCollectionViewSelectionChanged);
        public Topic CurrentSelectedTopic { get; set; }

        public void OnCollectionViewSelectionChanged(object o)
        {
            if (o is null) return;
            var topic = o as Topic;
            var popup = new TopicPatchPopup(topic, _service);
            Page.ShowPopup(popup);
            CurrentSelectedTopic = null;
        }

        public TopicsViewModel(RevisionService service)
        {
            _service = service;
            Topics = new ObservableCollection<Topic>();
            FillTopics();
        }
        private void FillTopics()
        {
            var topics = _service.GetTopics(1);
            if (topics is null) return;
            foreach(var topic in topics.Topics)
            {
                Topics.Add(topic);
            }
        }
    }
}
