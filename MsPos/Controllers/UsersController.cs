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
        //Get
        public IActionResult Users()
        {
            try
            {
                IEnumerable<User> objusers = _db.Users;
                if (objusers != null )
               
                return View(objusers);
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                
            }
            return RedirectToAction("Create");
        }
        //Get
        public IActionResult Create()
        {
            return View();
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(User obj)
        {
            if(obj.Username == obj.Password)
            {
                ModelState.AddModelError("CustomError", "Username should not be Same as Password.");
            }
            if (ModelState.IsValid) { 
            _db.Users.Add(obj);
            _db.SaveChanges();
                TempData["success"] = "User Created Successfully";
            return RedirectToAction("Users");
            }
            return View(obj);
        }
        //Get
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var userFromDb = _db.Users.Find(id);
            if (userFromDb == null)
            {
                return NotFound();

            }
            return View(userFromDb);
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(User obj)
        {
            if (obj.Username == obj.Password)
            {
                ModelState.AddModelError("CustomError", "Username should not be Same as Password.");
            }
            if (ModelState.IsValid)
            {
                _db.Users.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "User Updated Successfully";
                return RedirectToAction("Users");
            }
            return View(obj);
        }

      

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int? id)
        {
           
            var obj = _db.Users.Find(id);
            if(obj == null)
            {
                return NotFound();
            }

            _db.Users.Remove(obj);
                _db.SaveChanges();
            TempData["success"] = "User Deleted Successfully";
            return RedirectToAction("Users");
            
           
        }
    }
}
