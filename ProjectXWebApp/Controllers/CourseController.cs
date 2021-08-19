using ProjectXBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectXWebApp.Controllers
{
    public class CourseController : Controller
    {
        CourseBL courseBLObj;
        // GET: Course
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAllCourses()
        {
            courseBLObj = new CourseBL();
            var resDTO = courseBLObj.GetAllCourses();
            List<Models.CourseView> lstCourseObj = new List<Models.CourseView>();
            foreach (var item in resDTO)
            {
                lstCourseObj.Add(new Models.CourseView()
                {
                    CourseID = item.CourseID,
                    CourseTitle = item.CourseTitle,
                    NoOfHours = item.NoOfHours,
                    CourseOwner_ID = item.CourseOwner_ID

                });
            }
            return View(lstCourseObj);
        }
    }
}