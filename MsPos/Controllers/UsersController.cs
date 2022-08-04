using Microsoft.AspNetCore.Mvc;
using MsPos.Data;

namespace MsPos.Controllers
{
    public class UsersController : Controller
    {
        private readonly MsPosDbcontext _db;
        public UsersController(MsPosDbcontext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var objusers = _db.Users.ToList();
            return View();
        }

    }
}
