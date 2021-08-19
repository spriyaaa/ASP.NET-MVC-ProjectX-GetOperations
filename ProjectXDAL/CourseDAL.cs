using ProjectXDTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectXDAL
{
    public class CourseDAL
    {
        SqlConnection sqlConObj;
        SqlCommand sqlCmdObj;
        public CourseDAL()
        {
            sqlConObj = new SqlConnection(ConfigurationManager.ConnectionStrings["ProjectXConStr"].ToString());
        }
        public List<CourseDTO> GetAllCourses()
        {
            try
            {
                List<CourseDTO> lstCourses = new List<CourseDTO>();
                ProjectXConStr context = new ProjectXConStr();
                var Courselst = context.Courses.ToList();
                foreach (var item in Courselst)
                {
                    lstCourses.Add(new CourseDTO
                    {
                        CourseID = item.CourseID,
                        CourseTitle = item.CourseTitle,
                        NoOfHours = (int)item.NoOfHours,
                        CourseOwner_ID = item.CourseOwner_ID


                    });
                }
                return lstCourses;

            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<CourseDTO> GetCoursesByTitle(string Coursetitle)
        {
            try
            {
                List<CourseDTO> lstCourses = new List<CourseDTO>();
                ProjectXConStr context = new ProjectXConStr();
                var Courselst = context.Courses.Where(x => x.CourseTitle == Coursetitle).ToList();
                foreach (var item in Courselst)
                {
                    lstCourses.Add(new CourseDTO
                    {
                        CourseID = item.CourseID,
                        CourseTitle = item.CourseTitle,
                        NoOfHours = (int)item.NoOfHours,
                        CourseOwner_ID = item.CourseOwner_ID


                    });
                }
                return lstCourses;

            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<CourseDTO> GetCourseFacultyByCourseTitle(string courseTitle)
        {
            try
            {
                List<CourseDTO> lstCourses = new List<CourseDTO>();
                ProjectXConStr context = new ProjectXConStr();
                var result = (from Course in context.Courses
                              join Faculty in context.Faculties
                              on Course.CourseOwner_ID equals Faculty.FacultyID
                              where (Course.CourseTitle == courseTitle)
                              select new
                              {
                                  CID = Course.CourseID,
                                  CTitle = Course.CourseTitle,
                                  Hours = Course.NoOfHours

                              }).ToList();

                foreach (var item in result)
                {
                    lstCourses.Add(new CourseDTO
                    {
                        CourseID = item.CID,
                        CourseTitle = item.CTitle,
                        NoOfHours = (int)item.Hours

                    });
                }
                return lstCourses;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<CourseDTO> GetCourseFaculty()
        {
            try
            {
                List<CourseDTO> lstCourses = new List<CourseDTO>();
                ProjectXConStr context = new ProjectXConStr();
                var result = (from Course in context.Courses
                              join Faculty in context.Faculties
                              on Course.CourseOwner_ID equals Faculty.FacultyID
                              select new
                              {
                                  CID = Course.CourseID,
                                  CTitle = Course.CourseTitle,
                                  Hours = Course.NoOfHours

                              }).ToList();

                foreach (var item in result)
                {
                    lstCourses.Add(new CourseDTO
                    {
                        CourseID = item.CID,
                        CourseTitle = item.CTitle,
                        NoOfHours = (int)item.Hours

                    });
                }
                return lstCourses;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public int AddNewCourse(CourseDTO couDTOObj)
        {
            try
            {
                sqlCmdObj = new SqlCommand("uspInsertCourses", sqlConObj);
                sqlCmdObj.CommandType = System.Data.CommandType.StoredProcedure;

                sqlCmdObj.Parameters.AddWithValue("@CourseId", couDTOObj.CourseID);
                sqlCmdObj.Parameters.AddWithValue("@Coursetitle", couDTOObj.CourseTitle);
                sqlCmdObj.Parameters.AddWithValue("@NoOfHours", couDTOObj.NoOfHours);
                sqlCmdObj.Parameters.AddWithValue("@CourseOwner_ID", couDTOObj.CourseOwner_ID);
                SqlParameter paroutput = new SqlParameter();
                //paroutput.ParameterName = "@RequestStatus";
                paroutput.Direction = System.Data.ParameterDirection.ReturnValue;
                paroutput.SqlDbType = System.Data.SqlDbType.Int;
                sqlCmdObj.Parameters.Add(paroutput);
                sqlConObj.Open();
                sqlCmdObj.ExecuteNonQuery();

                int retval = Convert.ToInt32(paroutput.Value);
                return retval;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

    }
}

