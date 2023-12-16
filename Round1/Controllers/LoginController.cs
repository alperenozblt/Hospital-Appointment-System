using Microsoft.AspNetCore.Mvc;
using Round1.Models;

[Route("[controller]")]
public class LoginController : Controller
{
    private HastaneContext _context = new HastaneContext();

    [HttpGet]
    public IActionResult LoginIndex()
    {
        return View();
    }

    [HttpPost]
    //public IActionResult AdminLogin(Admin model)
    //{
    //    if (ModelState.IsValid)
    //    {
    //        var admin = _context.Admins.FirstOrDefault(a => a.AdminName == model.AdminName && a.AdminPassword == model.AdminPassword);
    //        if (admin != null)
    //        {
    //            // Admin bilgilerini başarıyla bulduk.
    //            // Kullanıcıyı giriş yapsın.
    //            return RedirectToAction("Index", "Admin");
    //        }
    //        else
    //        {
    //            // Admin bilgilerini bulamadık.
    //            // Giriş başarısız.
    //            ModelState.AddModelError("", "Giriş başarısız. Lütfen bilgilerinizi kontrol edin.");
    //        }
    //    }
    //    return View("Index");
    //}

    [HttpPost]
    public IActionResult HastaLogin(Hasta model)
    {
        if (ModelState.IsValid)
        {
            var hasta = _context.Hastas.FirstOrDefault(h => h.TCKimlikNumarası == model.TCKimlikNumarası && h.HastaPassword == model.HastaPassword);
            if (hasta != null)
            {
                // Hasta bilgilerini başarıyla bulduk.
                // Kullanıcıyı giriş yapsın.
                return RedirectToAction("Index", "Hasta");
            }
            else
            {
                // Hasta bilgilerini bulamadık.
                // Giriş başarısız.
                ModelState.AddModelError("", "Giriş başarısız. Lütfen bilgilerinizi kontrol edin.");
            }
        }
        return View("Index");
    }
}
