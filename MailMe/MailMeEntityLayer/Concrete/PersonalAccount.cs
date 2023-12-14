using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailMeEntityLayer.Concrete
{
    public class PersonalAccount
    {
        public int PersonalAccountId { get; set; }
        public int AppUserID { get; set; }
        public AppUser AppUser { get; set; }
    }
}
