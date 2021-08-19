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
    public class ModelDAL
    {
        SqlConnection sqlConObj;
        SqlCommand sqlCmdObj;
        public ModelDAL()
        {
            sqlConObj = new SqlConnection(ConfigurationManager.ConnectionStrings["ProjectXConStr"].ToString());
        }
        public List<ModelDTO> GetAllModels()
        {
            try
            {
                List<ModelDTO> lstModels = new List<ModelDTO>();
                ProjectXConStr context = new ProjectXConStr();
                var result = context.Models.ToList();
                foreach (var item in result)
                {
                    lstModels.Add(new ModelDTO()
                    {
                        ModelId = item.ModelId,
                        ModelName = item.ModelName

                    });

                }
                return lstModels;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public int AddNewModel(ModelDTO modelDTOObj)
        {
            try
            {
                sqlCmdObj = new SqlCommand("uspInsertModel", sqlConObj);
                sqlCmdObj.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCmdObj.Parameters.AddWithValue("@ModelId", modelDTOObj.ModelId);
                sqlCmdObj.Parameters.AddWithValue("@CourseId", modelDTOObj.ModelName);
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
