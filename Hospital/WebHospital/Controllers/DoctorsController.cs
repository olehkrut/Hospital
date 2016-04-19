﻿using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Hospital.Domain.Entities;
using Hospital.Domain.IRepositories;

namespace Hospital.Controllers
{
	public class DoctorsController : Controller
	{
		private IDoctorRepository _repository;

		public DoctorsController(IDoctorRepository repository)
		{
			_repository = repository;
		}
		// GET: Doctors
		public ActionResult Index()
		{
			return View(_repository.GetAll().ToList());
		}

		// GET: Doctors/Details/5
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Doctor doctor = _repository.FindById(id.Value);
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
				_repository.Add(doctor);
				db.SaveChanges();
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
			Doctor doctor = db.Doctors.Find(id);
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
				db.Entry(doctor).State = EntityState.Modified;
				db.SaveChanges();
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
			Doctor doctor = db.Doctors.Find(id);
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
			Doctor doctor = db.Doctors.Find(id);
			db.Doctors.Remove(doctor);
			db.SaveChanges();

			return RedirectToAction("Index");
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				db.Dispose();
			}
			base.Dispose(disposing);
		}
	}
}
