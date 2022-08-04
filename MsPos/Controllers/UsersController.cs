using Microsoft.AspNetCore.Mvc;
using MsPos.Data;
using MsPos.Models;

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
            IEnumerable<User> objusers = _db.Users;
            return View(objusers);
        }

    }
}
