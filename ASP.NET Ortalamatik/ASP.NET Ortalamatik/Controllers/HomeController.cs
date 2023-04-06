using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using OrtalaMatik.Models;
using OrtalaMatik.Models.Entities;

namespace OrtalaMatik.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    HesaplamatikdbContext db = new HesaplamatikdbContext();
    public IActionResult Index()
    {
        var datas = new Lessons()
        {
            lessons = db.Lessons.OrderByDescending(x => x.Id).ToList(),
        };
        return View(datas);
    }
    [HttpPost]
    [Route("/add-lesson/")]
    [ValidateAntiForgeryToken]
    public IActionResult AddLesson(Lessons lesson)
    {
        if (ModelState.IsValid)
        {
            db.Lessons.Add(lesson);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        else { return View(); }
    }
    [Route("/delete-lesson/{id}")]
    public IActionResult DeleteLesson(int id)
    {
        var item = db.Lessons.SingleOrDefault(x => x.Id == id);
        db.Remove(item);
        db.SaveChanges();
        return Redirect("/");
    }

    [HttpPost]
    [Route("/edit-lesson/")]
    public IActionResult EditLesson(Lessons lesson)
    {
        var item = db.Lessons.SingleOrDefault(x => x.Id == lesson.Id);
        item.LessonName = lesson.LessonName;
        item.Credit = lesson.Credit;
        item.Note = lesson.Note;
        db.SaveChanges();
        return RedirectToAction("Index");
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
