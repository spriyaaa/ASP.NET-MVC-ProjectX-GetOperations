using ProjectXDAL;
using ProjectXDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectXBL
{
    public class CourseBL
    {
        CourseDAL objCourseDAL;
        public CourseBL()
        {
            objCourseDAL = new CourseDAL();
        }
        public List<CourseDTO> GetAllCourses()
        {
            try
            {
                var lstCourse = objCourseDAL.GetAllCourses();
                return lstCourse;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
/*        public List<CourseFacultyDTO> GetCourseFaculty()
        {
            try
            {
                var lstCourseFaculty = objCourseDAL.GetCourseFaculty();
                return lstCourseFaculty;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }*/
        public List<CourseDTO> GetCoursesByGroup(string cTitle)
        {
            try
            {
                var lstCourse = objCourseDAL.GetCoursesByTitle(cTitle);
                return lstCourse;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
/*        public List<CourseFacultyDTO> GetCourseFacultyByCourseTitle(string cTitle)
        {
            try
            {
                var lstCourseFaculty = objCourseDAL.GetCourseFacultyByCourseTitle(cTitle);
                return lstCourseFaculty;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
*/        public int AddNewCourse(CourseDTO newCourseDetails)
        {
            try
            {
                int returnvalue = objCourseDAL.AddNewCourse(newCourseDetails);
                return returnvalue;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
