using Microsoft.Maui.Graphics;

namespace RevisionApp.Services.Dto.Response
{
    public class GetTopicsResponse
    {
       public ICollection<Topic> Topics { get; set; }
    }

    public class Topic
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime RevisionDateTime { get; set; }
        public int ReminderCount { get; set; }
        public string Color { get; set; }
        public int UserId { get; set; }

        public string RevisionDate => $"{RevisionDateTime.Day} {RevisionDateTime.ToString("MMM")}";
        public Color MauiColour => Microsoft.Maui.Graphics.Color.Parse(Color);
    }
}
