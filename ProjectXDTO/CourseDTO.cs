using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectXDTO
{

    public class CourseDTO
    {
        public string CourseID { get; set; }
        public string CourseTitle { get; set; }
        public decimal NoOfHours { get; set; }
        public int CourseOwner_ID { get; set; }
    }
}