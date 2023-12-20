using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace MailMeEntityLayer.Concrete
{
    public class MailUser
    {
        public Guid Id { get; set; }
        public string RecipientEmail { get; set; }

        public DateTime ScheduledTime { get; set; }
        public DateTime CreatedTime { get; set; }

        public string Title { get; set; }

        public string MailContent { get; set; }

        public bool Remember { get; set; }
        public AppUser AppUser { get; set; }
        public int AppUserId { get; set; }
    }
}
