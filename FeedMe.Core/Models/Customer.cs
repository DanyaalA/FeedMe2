using FeedMe.Core.Server;
using System;
using System.Collections.Generic;
using System.Text;

namespace FeedMe.Core.Models
{
    class Customer : Client
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
}
