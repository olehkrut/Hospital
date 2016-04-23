using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Hospital.Domain.Entities;
using Hospital.Domain.IServices;

namespace Hospital.Controllers
{
	public class PatientsController : Controller
	{
		private readonly IPatientService _patientService;
		private readonly IDoctorService _doctorService;

		public PatientsController(IPatientService patientService, IDoctorService doctorService)
		{
			_patientService = patientService;
			_doctorService = doctorService;
		}

		// GET: Patients
		public ActionResult Index()
		{
			var patients = _patientService.LoadAllPatients();
			return View(patients);
		}

		// GET: Patients/Details/5
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Patient patient = _patientService.FindPatientById(id.Value);
			if (patient == null)
			{
				return HttpNotFound();
			}
			return View(patient);
		}

		private IEnumerable<SelectListItem> GetDoctors()
		{
			var doctors = _doctorService.LoadAllDoctors()
						.Select(x =>
								new SelectListItem
								{
									Value = x.Id.ToString(),
									Text = x.FullName
								});

			return new SelectList(doctors, "Value", "Text");
		}


		// GET: Patients/Create
		public ActionResult Create()
		{
			ViewBag.DoctorId = new SelectList(_doctorService.LoadAllDoctors(), "Id", "FullName");
			return View();
		}

		// POST: Patients/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "Id,Disease,DoctorId,FirstName,LastName")] Patient patient)
		{
			if (ModelState.IsValid)
			{
				_patientService.RegisterNewPatient(patient);
				return RedirectToAction("Index");
			}

			ViewBag.DoctorId = new SelectList(_doctorService.LoadAllDoctors(), "Id", "Qualification", patient.DoctorId);
			return View(patient);
		}

		// GET: Patients/Edit/5
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Patient patient = _patientService.FindPatientById(id.Value);
			if (patient == null)
			{
				return HttpNotFound();
			}
			ViewBag.DoctorId = new SelectList(_doctorService.LoadAllDoctors(), "Id", "FullName", patient.DoctorId);
			return View(patient);
		}

		// POST: Patients/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "Id,Disease,DoctorId,FirstName,LastName")] Patient patient)
		{
			if (ModelState.IsValid)
			{
				_patientService.UpdatePatient(patient);
				return RedirectToAction("Index");
			}
			ViewBag.DoctorId = new SelectList(_doctorService.LoadAllDoctors(), "Id", "FullName", patient.DoctorId);
			return View(patient);
		}

		// GET: Patients/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Patient patient = _patientService.FindPatientById(id.Value);
			if (patient == null)
			{
				return HttpNotFound();
			}
			return View(patient);
		}

		// POST: Patients/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			_patientService.DeletePatient(id);
			return RedirectToAction("Index");
		}
	}
}
