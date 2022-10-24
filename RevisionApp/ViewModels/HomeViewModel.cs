using CommunityToolkit.Maui.Views;
using RevisionApp.Services;
using RevisionApp.Services.Dto.Response;
using RevisionApp.Views;
using System.Collections.ObjectModel;

namespace RevisionApp.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        private readonly RevisionService _service;
        static Page Page => Application.Current?.MainPage ?? throw new NullReferenceException();

        public ObservableCollection<Topic> Topics { get; set; }
        public Command CollectionChangeCommand => new Command(OnCollectionViewSelectionChanged);
        public Topic CurrentSelectedTopic { get; set; }
        public string Status { get; set; }
        public string Name { get; set; }
       
        public void OnCollectionViewSelectionChanged(object o)
        {
            if (o is null) return;

            var topic = o as Topic;
            var popup = new TopicPopup(topic, _service, this);
            Page.ShowPopup(popup);
            CurrentSelectedTopic = null;
        }
        public HomeViewModel(RevisionService service)
        {
            _service = service;
            Topics = new ObservableCollection<Topic>();
            Name = UserManager.Name;
            FillTopics();
        }
        public void FillTopics()
        {
            var topics = _service.GetTopics(UserManager.UserId);
            if (topics?.Topics is null) return;

            if (topics?.Topics == null)
                return;

            Topics.Clear();
            foreach (var topic in topics.Topics.Where(topic => topic.RevisionDateTime.Date == DateTime.Now.Date && topic.LastRevisedDateTime.Date != DateTime.Now.Date))
            {
                Topics.Add(topic);
            }
        }
    }
}
