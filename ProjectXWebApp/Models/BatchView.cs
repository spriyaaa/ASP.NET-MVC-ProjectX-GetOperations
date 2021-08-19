using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectXWebApp.Models
{
    public class BatchView
    {
        public int BatchId { get; set; }
        public string BatchName { get; set; }
        public System.DateTime Batch { get; set; }
        public int NoOfStudent { get; set; }
        public string SessionQuarter { get; set; }
    }
}