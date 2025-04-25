using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace MVCProject.Controllers.USER
{
    public class LoginRegisterController : Controller
    {
       
        /// <summary>
        ///  Login Page controller 
        /// </summary>
        /// <returns></returns>
        public ActionResult LoginPage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginPage(IFormCollection collection)
        {
            try
            {
                
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        /// <summary>
        ///  SignUp Page Controller
        /// </summary>
        /// <returns></returns>
        public ActionResult SignUpPage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignUpPage([FromBody] object apiResponse)
        {
            try
            {
                return RedirectToAction(nameof(SignUpPage));
            }
            catch
            {
                return View();
            }
           
        }

        /// <summary>
        ///  Edit  Password
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult PasswordPage(int id)
        {
            return View();
        }

        // POST: LoginRegisterController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PasswordPage(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(); 
            }
        }






        public ActionResult ShowUsers(int id)
        {
            return View();
        }

        // GET: LoginRegisterController1/Create
       
      

        // GET: LoginRegisterController1/Edit/5
       

        // GET: LoginRegisterController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LoginRegisterController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
