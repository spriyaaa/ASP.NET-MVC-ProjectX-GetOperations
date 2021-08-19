using ProjectXDAL;
using ProjectXDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectXBL
{
    public class BatchBL
    {
        BatchDAL objBatch;
        public BatchBL()
        {
            objBatch = new BatchDAL();
        }
        public List<BatchDTO> GetAllBatches()
        {
            try
            {
                var lstBatch = objBatch.GetAllBatches();
                return lstBatch;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public int AddNewBatch(BatchDTO newBatchDetails)
        {
            try
            {
                int returnvalue = objBatch.AddNewBatch(newBatchDetails);
                return returnvalue;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
