using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Yeni_klasör.Models;

namespace Yeni_klasör.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    [Route ("/Menu")]
    public IActionResult Menu()
    {
        return View();
    }
    [Route ("/services")]
    public IActionResult services()
    {
        return View();
    }
    [Route ("/Blog")]
    public IActionResult Blog()
    {
        return View();
    }
    [Route ("/About")]
    public IActionResult About()
    {
        return View();
    }
        [Route ("/Shop")]
    public IActionResult Shop()
    {
        return View();
    }
    [Route ("/contact")]
    public IActionResult contact()
    {
        return View();
    }
    [Route ("/Productsible")]
    public IActionResult Productsible()
    {
        return View();
    }

    [Route ("/blogsingle")]
    public IActionResult blogsingle()
    {
        return View();
    }
    [Route ("/cart")]
    public IActionResult cart()
    {
        return View();
    }
       [Route ("/checkout")]
    public IActionResult checkout()
    {
        return View();
    }
  
  [Route ("/productsingle")]
    public IActionResult productsingle()
    {
        return View();
    }




  
}
