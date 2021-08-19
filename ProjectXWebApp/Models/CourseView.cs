using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectXWebApp.Models
{
    public class CourseView
    {
        public string CourseID { get; set; }
        public string CourseTitle { get; set; }
        public decimal NoOfHours { get; set; }
        public int CourseOwner_ID { get; set; }
    }
}