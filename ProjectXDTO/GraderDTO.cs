using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectXDTO
{
    public class GraderDTO
    {
        public int FacultyId { get; set; }
        public string CourseId { get; set; }
        public int ParticipantId { get; set; }
        public int TotalMarks { get; set; }
        public string AreaOfImprovement { get; set; }
        public string AreaOfExcellence { get; set; }
    }
}

