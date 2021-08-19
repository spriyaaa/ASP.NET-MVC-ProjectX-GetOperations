using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectXDAL;
using ProjectXDTO;

namespace ProjectXBL
{
    public class ModelBL
    {
        ModelDAL objModel;
        public ModelBL()
        {
            objModel = new ModelDAL();
        }
        public List<ModelDTO> GetAllModels()
        {
            try
            {
                var lstModel = objModel.GetAllModels();
                return lstModel;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public int AddNewModel(ModelDTO newModelDetails)
        {
            try
            {
                int returnvalue = objModel.AddNewModel(newModelDetails);
                return returnvalue;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}