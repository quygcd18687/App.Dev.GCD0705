using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TMS.Models;

namespace TMS.Controllers
{


	public class CourseController : Controller
	{

		private ApplicationDbContext _context;
		public CourseController()
		{
			_context = new ApplicationDbContext();
		}
		// GET: Course
		public ActionResult Index()
		{
			return View(_context.Courses.ToList());
		}

		// Add Course
		[HttpGet]


		public ActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Create(Course course)
		{
			if (!ModelState.IsValid)
			{
				return View();
			}
			var newCourse = new Course()
			{
				Name = course.Name,
				Description = course.Description,
				Categogy = course.Categogy
			};

			_context.Courses.Add(newCourse);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}

	}
}