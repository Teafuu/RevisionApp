using RevisionApp.Services;
using RevisionApp.Services.Dto.Response;
using System.Collections.ObjectModel;

namespace RevisionApp.ViewModels
{
    public class TopicsViewModel
    {
        private readonly RevisionService _service;

        public ObservableCollection<Topic> Topics { get; set; }

        public TopicsViewModel(RevisionService service)
        {
            _service = service;
            Topics = new ObservableCollection<Topic>();
            FillTopics();
        }
        private void FillTopics()
        {
            var topics = _service.GetTopics(1);
            foreach(var topic in topics.Topics)
            {
                Topics.Add(topic);
            }
        }
    }
}
