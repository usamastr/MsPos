using Microsoft.AspNetCore.Mvc;
using MsPos.Data;
using MsPos.Models;
using System;
using System.Web;

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
                IEnumerable<User> objusers = _db.User;
                if (objusers != null)
                {
                    if (objusers.Any())
                        return View(objusers);
                }
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
            _db.User.Add(obj);
            _db.SaveChanges();
                TempData["success"] = "User Created Successfully";
            return RedirectToAction("Users");
            }
            return View(obj);
        }
        //Get
        public IActionResult Edit(Int64? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var userFromDb = _db.User.Find(id);
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
                _db.User.Update(obj);
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
           
            var obj = _db.User.Find(id);
            if(obj == null)
            {
                return NotFound();
            }

            _db.User.Remove(obj);
                _db.SaveChanges();
            TempData["success"] = "User Deleted Successfully";
            return RedirectToAction("Users");
            
           
        }

        public IActionResult Login(User obj)
        {
            try
            {
                var dataItem = _db.User.Where(x => x.Username == obj.Username && x.Password == obj.Password).SingleOrDefault();

                bool isLogged = true;

                if (dataItem != null)

                {                    
                    isLogged = true;
                    
                    return RedirectToAction("Index","Home");
                }

                else

                {

                    isLogged = false;
                    return RedirectToAction("Login");
                }
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return RedirectToAction("Login");
            }
            
        }
    }
}
