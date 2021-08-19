
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
    public class BatchDAL
    {
        SqlConnection sqlConObj;
        SqlCommand sqlCmdObj;
        public BatchDAL()
        {
            sqlConObj = new SqlConnection(ConfigurationManager.ConnectionStrings["ProjectXConStr"].ToString());
        }

        public List<BatchDTO> GetAllBatches()
        {
            try
            {
                List<BatchDTO> lstBatch = new List<BatchDTO>();
                ProjectXConStr context = new ProjectXConStr();
                var batchlist = context.Batches.ToList();
                foreach (var item in batchlist)
                {
                    lstBatch.Add(new BatchDTO()
                    {
                        BatchId = item.BatchId,
                        BatchName = item.BatchName,
                        NoOfStudent = item.NoOfStudent,
                        SessionQuarter = item.SessionQuarter
                    });

                }
                return lstBatch;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public int AddNewBatch(BatchDTO batchDTOObj)
        {
            try
            {
                sqlCmdObj = new SqlCommand("uspInsertBatch", sqlConObj);
                sqlCmdObj.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCmdObj.Parameters.AddWithValue("@BatchName", batchDTOObj.BatchName);
                sqlCmdObj.Parameters.AddWithValue("@BatchId", batchDTOObj.BatchId);
                sqlCmdObj.Parameters.AddWithValue("@NoOfStudent", batchDTOObj.NoOfStudent);
                sqlCmdObj.Parameters.AddWithValue("@SessionQuarter", batchDTOObj.SessionQuarter);
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
















