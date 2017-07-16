using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace QBO_Events_Management.Controllers
{
    internal class ManageLoginsViewModel
    {
        public IList<UserLoginInfo> CurrentLogins { get; set; }
        public List<AuthenticationDescription> OtherLogins { get; set; }
    }
}