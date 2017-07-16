﻿using System.Collections.Generic;
using Microsoft.AspNet.Identity;

namespace QBO_Events_Management.Controllers
{
    internal class IndexViewModel
    {
        public bool BrowserRemembered { get; set; }
        public bool HasPassword { get; set; }
        public IList<UserLoginInfo> Logins { get; set; }
        public string PhoneNumber { get; set; }
        public bool TwoFactor { get; set; }
    }
}