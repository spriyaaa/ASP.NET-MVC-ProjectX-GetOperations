using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectXDTO
{
    public class BatchDTO
    {
        public int BatchId { get; set; }
        public string BatchName { get; set; }
        public System.DateTime Batch { get; set; }
        public int NoOfStudent { get; set; }
        public string SessionQuarter { get; set; }
    }
}