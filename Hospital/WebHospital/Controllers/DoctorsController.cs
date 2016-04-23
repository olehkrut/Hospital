using System.Net;
using System.Web.Mvc;
using Hospital.Domain.Entities;
using Hospital.Domain.IServices;

namespace Hospital.Controllers
{
	public class DoctorsController : Controller
	{
		private readonly IDoctorService _doctorService;

		public DoctorsController(IDoctorService doctorService)
		{
			_doctorService = doctorService;
		}


		// GET: Doctors
		public ActionResult Index()
		{
			var doctors = _doctorService.LoadAllDoctors();

			return View(doctors);
		}

		// GET: Doctors/Details/5
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Doctor doctor = _doctorService.FindDoctorById(id.Value);
			if (doctor == null)
			{
				return HttpNotFound();
			}

			return View(doctor);
		}

		// GET: Doctors/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: Doctors/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "Id,Qualification,FirstName,LastName")] Doctor doctor)
		{
			if (ModelState.IsValid)
			{
				_doctorService.RegisterNewDoctor(doctor);

				return RedirectToAction("Index");
			}

			return View(doctor);
		}

		// GET: Doctors/Edit/5
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Doctor doctor = _doctorService.FindDoctorById(id.Value);
			if (doctor == null)
			{
				return HttpNotFound();
			}

			return View(doctor);
		}

		// POST: Doctors/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "Id,Qualification,FirstName,LastName")] Doctor doctor)
		{
			if (ModelState.IsValid)
			{
				_doctorService.UpdateDoctor(doctor);
				return RedirectToAction("Index");
			}

			return View(doctor);
		}

		// GET: Doctors/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Doctor doctor = _doctorService.FindDoctorById(id.Value);
			if (doctor == null)
			{
				return HttpNotFound();
			}

			return View(doctor);
		}

		// POST: Doctors/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			_doctorService.DeleteDoctor(id);

			return RedirectToAction("Index");
		}
	}
}
