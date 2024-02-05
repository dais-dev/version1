using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MyAssetAppASP.Data;
using MyAssetAppASP.Models;

namespace MyAssetAppASP.Controllers
{
    public class AccountController : Controller
    {
    private readonly MyAssetAppASPContext _context;

        public AccountController(MyAssetAppASPContext context)
        {
            _context = context;
        }




        public IActionResult Index()
        {
            return View();
        }

        public IActionResult  SignIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(User model)
       {
    if (ModelState.IsValid)
    {
         var User = from m in _context.User select m;
         User = User.Where(s => s.UserName.Contains(model.UserName));
         if (User.Count() != 0)
         {
             if (User.First().Password == model.Password)
             {
                  return RedirectToAction("Success");
             }
         }
    }
      return RedirectToAction("Fail");
}


public IActionResult Success()
{
    return View();
}

public IActionResult Fail()
{
   return View();
}




    }
    
}