using ProjectXBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectXWebApp.Controllers
{
    public class ModelController : Controller
    {
        ModelBL modelBLObj;
        // GET: Model
        public ActionResult Index()
        {
            return View();
        }
      
        public ActionResult GetAllModels()
        {
            modelBLObj = new ModelBL();
            var resDTO = modelBLObj.GetAllModels();
            List<Models.ModelView> lstModelObj = new List<Models.ModelView>();
            foreach (var item in resDTO)
            {
                lstModelObj.Add(new Models.ModelView()
                {
                    ModelId = item.ModelId,
                    ModelName = item.ModelName

                });
            }
            return View(lstModelObj);
        }
    }
}