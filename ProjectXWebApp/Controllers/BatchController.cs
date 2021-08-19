using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectXBL;

namespace ProjectXWebApp.Controllers
{
    public class BatchController : Controller
    {
        BatchBL batchBLObj;
        // GET: Batch
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult GetAllBatches()
        {
            batchBLObj = new BatchBL();
            var resultDTO = batchBLObj.GetAllBatches();

            List<Models.BatchView> lstDeptObj = new List<Models.BatchView>();
            foreach (var item in resultDTO)
            {
                lstDeptObj.Add(new Models.BatchView()
                {
                    BatchName = item.BatchName,
                    BatchId =item.BatchId,
                    Batch=item.Batch, 
                    NoOfStudent=item.NoOfStudent, 
                    SessionQuarter =item.SessionQuarter
                });

            }
            return View(resultDTO);
        }


        
    }
}