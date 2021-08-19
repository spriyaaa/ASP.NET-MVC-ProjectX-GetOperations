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
    public class GraderDAL
    {
        SqlConnection sqlConObj;
        SqlCommand sqlCmdObj;
        public GraderDAL()
        {
            sqlConObj = new SqlConnection(ConfigurationManager.ConnectionStrings["ProjectXConStr"].ToString());
        }
        public List<GraderDTO> GetAllGraders()
        {
            try
            {
                List<GraderDTO> lstGrader = new List<GraderDTO>();
                ProjectXConStr context = new ProjectXConStr();
                var result = context.Graders.ToList();
                foreach (var item in result)
                {
                    lstGrader.Add(new GraderDTO()
                    {
                        FacultyId = item.FacultyId,
                        CourseId = item.CourseId,
                        ParticipantId = item.ParticipantId,
                        TotalMarks = (int)item.TotalMarks,
                        AreaOfImprovement = item.AreaOfImprovement,
                        AreaOfExcellence = item.AreaOfExcellence
                    });
                }
                return lstGrader;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public int AddNewGrader(GraderDTO graderDTOObj)
        {
            try
            {


                sqlCmdObj = new SqlCommand("uspInsertGrader", sqlConObj);
                sqlCmdObj.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCmdObj.Parameters.AddWithValue("@FacultyId", graderDTOObj.FacultyId);
                sqlCmdObj.Parameters.AddWithValue("@CourseId", graderDTOObj.CourseId);
                sqlCmdObj.Parameters.AddWithValue("@ParticipantId ", graderDTOObj.ParticipantId);
                sqlCmdObj.Parameters.AddWithValue("@TotalMarks", graderDTOObj.TotalMarks);
                sqlCmdObj.Parameters.AddWithValue("@AreaOfImprovement", graderDTOObj.AreaOfImprovement);
                sqlCmdObj.Parameters.AddWithValue("@AreaOfExcellence", graderDTOObj.AreaOfExcellence);
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
