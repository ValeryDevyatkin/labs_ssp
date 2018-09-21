using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ssp2.Models;

namespace ssp2.Controllers
{
    public class HomeController : Controller
    {
        private readonly WorkerContext _workerContext = new WorkerContext();

        public ActionResult Index()
        {
            return View(_workerContext);
        }
        
        public ActionResult Delete(int? idParam)
        {
            if (idParam == null) return Redirect("Index");

            try
            {
                _workerContext.Workers.Remove(_workerContext.Workers.First(x => x.Id == idParam));
                _workerContext.SaveChanges();
            }
            catch (Exception)
            {
                // ignored
            }

            return Redirect("Index");
        }

        public ActionResult Update(int? idParam, string speciality, int age = 0, string fio = null)
        {
            if (idParam == null) return Redirect("Index");

            try
            {
                var worker = _workerContext.Workers.First(x => x.Id == idParam);
                worker.Age = age;
                worker.Speciality = speciality;
                worker.Fio = fio;
                _workerContext.SaveChanges();
            }
            catch (Exception)
            {
                // ignored
            }

            return Redirect("Index");
        }

        [HttpPost]
        public ActionResult Add(string speciality, int age = 0, string fio = null)
        {
            if (fio == null || fio.Trim() == "") return Redirect("Index");

            try
            {
                _workerContext.Workers.Add(new Worker(fio, age, speciality));
                _workerContext.SaveChanges();
            }
            catch (Exception)
            {
                // ignored
            }

            return Redirect("Index");
        }
        
        public ActionResult ChangeImage(string spec, HttpPostedFileBase upload)
        {
            if (upload != null)
            {
                string fileName = System.IO.Path.GetFileName(upload.FileName);
                upload.SaveAs(Server.MapPath("/Content/images/" + fileName));

                try
                {
                    _workerContext.Specialities.First(x => x.SpecialityId == spec).Img = fileName;
                    _workerContext.SaveChanges();
                }
                catch (Exception)
                {
                    // ignored
                }
            }

            return Redirect("Index");
        }

        public ActionResult ChangePayment(string spec, int pay)
        {
            if (spec == null || spec.Trim() == "") return Redirect("Index");

            try
            {
                var speciality = _workerContext.Specialities.First(x => x.SpecialityId == spec);
                speciality.Payment = pay;
                _workerContext.SaveChanges();
            }
            catch (Exception)
            {
                // ignored
            }

            return Redirect("Index");
        }
    }
}