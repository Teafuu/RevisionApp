namespace RevisionApp.Services.Dto.Request
{
    public class SendReviseRequest
    {
        public SendReviseRequest(int id, int userId)
        {
            Id = id;
            UserId = userId;
        }

        public int Id { get; set; }
        public int UserId { get; set; }
    }
}
