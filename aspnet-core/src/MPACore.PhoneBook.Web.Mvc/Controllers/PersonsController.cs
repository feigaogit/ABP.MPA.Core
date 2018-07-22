using Microsoft.AspNetCore.Mvc;
using MPACore.PhoneBook.Controllers;

namespace MPACore.PhoneBook.Web.Controllers
{
    public class PersonsController : PhoneBookControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}