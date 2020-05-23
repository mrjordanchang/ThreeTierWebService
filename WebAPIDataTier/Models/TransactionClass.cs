using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIDataTier.Models
{
    public class TransactionClass
    {
        public uint tID { get; set; }
        public uint sender { get; set; }
        public uint receiver { get; set; }
        public uint amount { get; set; }
    }
}