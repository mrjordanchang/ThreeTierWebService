using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIDataTier.Models
{
    public class UserAccount
    {
        public uint userId { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
    }
}