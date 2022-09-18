using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevisionApp.Services.Dto.Request
{
    public class CreateTopicRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime RevisionDateTime { get; set; }
        public string Color { get; set; }
        public int UserId { get; set; } = 1;
    }
}
