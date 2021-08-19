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
    public class FacultyDAL
    {
        SqlConnection sqlConObj;
        SqlCommand sqlCmdObj;
        public FacultyDAL()
        {
            sqlConObj = new SqlConnection(ConfigurationManager.ConnectionStrings["ProjectXConStr"].ToString());
        }
        public List<FacultyDTO> GetAllFaculties()
        {
            try
            {
                List<FacultyDTO> lstFaculty = new List<FacultyDTO>();
                ProjectXConStr context = new ProjectXConStr();
                var facultylst = context.Faculties.ToList();
                foreach (var item in facultylst)
                {
                    lstFaculty.Add(
                       new FacultyDTO
                       {
                           FacultyID = item.FacultyID,
                           EmailId = item.EmailId,
                           Name = item.Name

                       });
                }
                return lstFaculty;

            }
            catch (Exception)
            {

                throw;
            }
        }
        public int AddNewFaculty(FacultyDTO newobj)
        {
            int result = 0;
            try
            {
                using (var context = new ProjectXConStr())
                {
                    Faculty newFacultyobj = new Faculty()
                    {
                        FacultyID = newobj.FacultyID,
                        EmailId = newobj.EmailId,
                        Name = newobj.Name
                    };
                    context.Faculties.Add(newFacultyobj);
                    result = context.SaveChanges();
                    return result;

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something Went Wrong!!!");
                throw;
            }

        }
        public int AddFaculty(FacultyDTO facDTOObj)
        {
            try
            {
                sqlCmdObj = new SqlCommand("dbo.InsertFaculty", sqlConObj);
                sqlCmdObj.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCmdObj.Parameters.AddWithValue("@FacultyID", facDTOObj.FacultyID);
                sqlCmdObj.Parameters.AddWithValue("@EmailId", facDTOObj.EmailId);
                sqlCmdObj.Parameters.AddWithValue("@Name", facDTOObj.Name);
                SqlParameter paroutput = new SqlParameter();
                paroutput.ParameterName = "@requeststatus";
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
        public int UpdateFacultyDetails(FacultyDTO facDTOObj)
        {
            try
            {
                sqlCmdObj = new SqlCommand("uspInsertFaculty", sqlConObj);
                sqlCmdObj.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCmdObj.Parameters.AddWithValue("@FacultyID", facDTOObj.FacultyID);
                sqlCmdObj.Parameters.AddWithValue("@Name", facDTOObj.Name);
                sqlCmdObj.Parameters.AddWithValue("@email", facDTOObj.EmailId);
                SqlParameter paroutput = new SqlParameter();
                paroutput.ParameterName = "@RequestStatus";
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