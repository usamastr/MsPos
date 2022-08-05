using Microsoft.AspNetCore.Mvc;
using MsPos.Data;
using MsPos.Models;
using System.Security.Cryptography;
using System.Text;

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


        public class Credentials
        {
            public string UserName { get; set; }
            public string Password { get; set; }

        }
        [HttpPost]
        public Task<ActionResult<User>> LoginUser([FromBody] Credentials login)
        {
            try
            {
                string pswd_string = Encryption.EncryptToSHA256(login.Password, login.UserName.ToUpper());

                var loggedInUser = (from e in _db.Users
                             where e.Username == login.UserName && e.Password = pswd_string
                                    select e).FirstOrDefault();



                if (loggedInUser.UserId != 0)
                {                    
                    _user.UserId = loggedInUser.UserId;
                    _user.DisplayName = loggedInUser.UserName;                    

                    return Task.FromResult(loggedInUser);
                }                
            }
            catch (Exception e)
            {
                dynamic response = new System.Dynamic.ExpandoObject();
                response.Message = e.Message;
                response.StatusCode = 401;
                return View(login);
            }
        }

        public class Encryption
        {
            public static string EncryptToSHA256(string data, string salt)
            {
                if (salt != null)
                {
                    salt = salt.ToLower();
                    data += salt;
                }

                SHA256 hasher = SHA256.Create();

                byte[] hashedData = hasher.ComputeHash(Encoding.Unicode.GetBytes(data));

                StringBuilder sb = new StringBuilder(hashedData.Length * 2);

                foreach (byte b in hashedData)
                {

                    sb.AppendFormat("{0:x2}", b);

                }

                return sb.ToString();

            }
        }
    }
}
