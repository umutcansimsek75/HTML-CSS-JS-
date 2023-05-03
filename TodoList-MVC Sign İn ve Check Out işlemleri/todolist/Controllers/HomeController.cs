using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TodoList.Models;
using TodoList.Models.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;




namespace TodoList.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }


    MydbContext db = new MydbContext();
    public IActionResult Index()
    {
        return View();
    }


    [Route("/Privacy")]
    public IActionResult Privacy()
    {
        return View();
    }

    [Route("/Contract")]
     public IActionResult Contract()
    {
        return View();
    }

    [Authorize]
    [Route("/Todolist")]
    public IActionResult TodoList()
    {
        var model= new TodoViewModel(){
            Todos=db.Todos!.OrderByDescending(x=>x.Title).ToList(),
        };
        return View(model);
    }
    [Route("/signout")]
    public async Task<IActionResult> Signout()
    {
        await HttpContext.SignOutAsync();
        TempData["Success"]="Tekrar Bekleriz";
        return Redirect("/login");
        
    }
    
    [Route("/login")]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    [IgnoreAntiforgeryToken]
    [Route("/login")]
    public async Task<IActionResult> Login(User postedData)
    {
        User user =db.Users!.FirstOrDefault(x=>x.Username==postedData.Username && x.Password==postedData.Password)!;
        if ( user != null)
        
        {
            var claims = new List<Claim>{
            new Claim("user",user.Id.ToString()),
            new Claim ("role","admin")
            
            
            }

        ;
        var claimsIdentity=new ClaimsIdentity(claims,"Cookies");
        var claimsPrinciple=new ClaimsPrincipal(claimsIdentity);

        
            
        await HttpContext.SignInAsync(claimsPrinciple);
            return Redirect("/todolist");

        }
        else{
            
            TempData!["Danger"]="Hatalı Kullanıcı adı / Şifre ";
            return Redirect("/login");
        }
        
       
    }

    




    [HttpPost]
    [IgnoreAntiforgeryToken]
    [Route("/add-todo")]
     public IActionResult AddTodo(Todo postedData)
    {
        Todo toAdd= new Todo();

        toAdd.Title=postedData.Title;
        toAdd.IsComplated=false;
        db.Add(toAdd);
        db.SaveChanges();

        return Redirect("/todolist");
    }
   
    [Route("/delete-todo/{id}")]
     public IActionResult DeleteTodo(int id)
    {
        Todo toDelete= db.Todos!.Find(id)!;

       
        db.Remove(toDelete);
        db.SaveChanges();

        return Content("Kayıt Başarıyla Silindi!");
    }
    [Route("/update-todo/{id}")]
     public IActionResult UpdateTodo(int id)
    {
        Todo toUpdate= db.Todos!.Find(id)!;
        toUpdate.IsComplated=!toUpdate.IsComplated;

        db.Entry(toUpdate).CurrentValues.SetValues(toUpdate);
        db.SaveChanges();

        return Content(toUpdate.IsComplated.ToString()!);
    }





    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
