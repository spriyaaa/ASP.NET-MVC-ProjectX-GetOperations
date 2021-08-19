using ProjectXDAL;
using ProjectXDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProjectXBL
{
    public class GraderBL
    {
        GraderDAL objGrader;
        public GraderBL()
        {
            objGrader = new GraderDAL();
        }
        public List<GraderDTO> GetAllGraders()
        {
            try
            {
                var lstGrader = objGrader.GetAllGraders();
                return lstGrader;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public int AddNewGrader(GraderDTO newGraderDetails)
        {
            try
            {
                int returnvalue = objGrader.AddNewGrader(newGraderDetails);
                return returnvalue;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
