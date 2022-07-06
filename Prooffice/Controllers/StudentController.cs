using Prooffice.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Net;
using Prooffice;

namespace Prooffice.Controllers
{
    public class StudentController : Controller
    {
        dbofficeEntities db = new dbofficeEntities();

        [HttpGet]
        public ActionResult Index()



        {
            ViewData["msg"] = "";
            List<tblcountrymast> cun = db.tblcountrymasts.ToList();
            ViewBag.insert = new SelectList(cun, "country_name", "country_name");
            return View();        
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(CustomModel model)
         {
            string fileup = "/uploadfile/" + Guid.NewGuid() + System.IO.Path.GetExtension(model.fileupload.FileName);
            List<tblcountrymast> cun = db.tblcountrymasts.ToList();
            ViewBag.insert = new SelectList(cun, "country_name", "country_name");
            if (ModelState.IsValid)
            {          
                tblstudentinfo Stu = new tblstudentinfo();
                Stu.transid = Guid.NewGuid();
                Stu.studentname = model.studentname;
                Stu.address = model.address;
                Stu.mobile = model.mobile;
                Stu.email = model.email;
                Stu.gender = model.gender;
                Stu.country = model.country;
                Stu.fileupload = fileup;
                db.tblstudentinfoes.Add(Stu);
                db.SaveChanges();
                model.fileupload.SaveAs(Server.MapPath(fileup));
                ViewData["msg"] = "true";           
            }
            else
            {
                ViewData["msg"] = "false";
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult Details()
        {
            var details = (from x in db.tblstudentinfoes
                           select new TableModel
                           {
                               transid = x.transid,
                               studentname = x.studentname,
                               address = x.address,
                               mobile = x.mobile,
                               email = x.email,
                               gender = x.gender,
                               country = x.country,
                               fileupload = x.fileupload,
                           }).ToList();
                  ViewBag.details = details;
            ViewData["msg"] = TempData["msg"];
            return View();
        }
        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            var details = (from x in db.tblstudentinfoes
                           where x.transid == id
                           select new CustomModel
                           {
                               transid = x.transid,
                               studentname = x.studentname,
                               address = x.address,
                               mobile = x.mobile,
                               email = x.email,
                               gender = x.gender,
                               country = x.country,
                               url = x.fileupload,
                           }).ToList();
            ViewBag.details = details;

            List<tblcountrymast> cun = db.tblcountrymasts.ToList();
            ViewBag.insert = new SelectList(cun, "country_name", "country_name");
            var data = db.tblstudentinfoes.Where(x => x.transid == id).FirstOrDefault();
            CustomModel model = new CustomModel();
            model.transid = data.transid;
            model.studentname = data.studentname;
            model.address = data.address;
            model.mobile = data.mobile;
            model.email = data.email;
            model.gender = data.gender;
            model.country = data.country;
            model.url = data.fileupload;
            return View(model);

        }
        [HttpPost]
        public ActionResult Edit(CustomModel model, Guid id)
        {
            var details = (from x in db.tblstudentinfoes
                           where x.transid == id
                           select new CustomModel
                           {
                               transid = x.transid,
                               studentname = x.studentname,
                               address = x.address,
                               mobile = x.mobile,
                               email = x.email,
                               gender = x.gender,
                               country = x.country,
                               url = x.fileupload,
                           }).ToList();
            ViewBag.details = details;
            List<tblcountrymast> cun = db.tblcountrymasts.ToList();
            ViewBag.insert = new SelectList(cun, "country_name", "country_name");
            //string fileup = "/uploadfile/" + Guid.NewGuid() + System.IO.Path.GetExtension(model.fileupload.FileName);
            if (ModelState.IsValid)
            {
                tblstudentinfo Stu = new tblstudentinfo();
                if(model.fileupload != null)
                {
                    string fileup = "/uploadfile/" + Guid.NewGuid() + System.IO.Path.GetExtension(model.fileupload.FileName);
                    Stu.fileupload = fileup;
                    model.fileupload.SaveAs(Server.MapPath(fileup));
                    Stu.transid = model.transid;
                    Stu.studentname = model.studentname;
                    Stu.address = model.address;
                    Stu.mobile = model.mobile;
                    Stu.email = model.email;
                    Stu.gender = model.gender;
                    Stu.country = model.country;
                    db.Entry(Stu).State = EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {
                    Stu.transid = model.transid;
                    Stu.studentname = model.studentname;
                    Stu.address = model.address;
                    Stu.mobile = model.mobile;
                    Stu.email = model.email;
                    Stu.gender = model.gender;
                    Stu.country = model.country;
                   // Stu.fileupload = model.fileupload.ToString();
                    db.Entry(Stu).State = EntityState.Modified;
                    db.SaveChanges();
                }
               
               
                ViewData["msg"] = "true";
            }
            else
            {
                ViewData["msg"] = "false";
            }
            return View(model);
        }
        //[HttpGet]
        //public ActionResult Delete(Guid id)
        //{
        //    var data = db.tblstudentinfoes.Where(x => x.transid == id).FirstOrDefault();
        //    CustomModel model = new CustomModel();
        //    model.transid = data.transid;
        //    model.studentname = data.studentname;
        //    model.address = data.address;
        //    model.mobile = data.mobile;
        //    model.email = data.email;

        //    return View(model);

        //}
    //    [HttpPost]
        public ActionResult Delete(Guid id)
        {
          
                tblstudentinfo tblstudent = db.tblstudentinfoes.Where(x => x.transid == id).FirstOrDefault();
                tblstudentdlt Stu = new tblstudentdlt();
                Stu.transid = tblstudent.transid;
                Stu.studentname = tblstudent.studentname;
                Stu.address = tblstudent.address;
                Stu.mobile = tblstudent.mobile;
                Stu.email = tblstudent.email;
                Stu.gender = tblstudent.gender;
                Stu.country = tblstudent.country;
                Stu.fileupload = tblstudent.fileupload;
                db.tblstudentdlts.Add(Stu);
                db.tblstudentinfoes.Remove(tblstudent);
                db.SaveChanges();
                TempData["msg"] = "true";
           
            return RedirectToAction("Details");
        }

        public ActionResult Test()
        {
            parent par = new parent();           
            List<chklist> chkl = new List<chklist>();
            chkl.Add(new chklist { checkbox = true });
            chkl.Add(new chklist { checkbox = false });
            chkl.Add(new chklist { checkbox = true });
            List<chkall> chk = new List<chkall>();
            chk.Add(new chkall { name = "Smriti", test = chkl });
            chk.Add(new chkall { name = "Ram", test = chkl });
            chk.Add(new chkall { name = "John", test = chkl });
            par.demo = chk;
            return View();

        }
    }
}