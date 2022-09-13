using RevisionApp.Services;
using System.Collections.ObjectModel;

namespace RevisionApp.ViewModels
{
    public class HomeViewModel
    {
        private readonly RevisionService _service;
        public int UserId { get; set; } = 1;    
        public HomeViewModel(RevisionService service)
        {
            _service = service;
            FillTopics();
        }

        private void FillTopics()
        {
            /*
            var topics = _service.GetTopics(UserId);
            Topics = new();

            foreach(var topic in topics.Topics)
                Topics.Add(new TopicViewModel()); 
            */
        }
    }
}
