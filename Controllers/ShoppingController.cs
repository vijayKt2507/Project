using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Controllers;
using Shop.ADo.netconnection;

namespace Shop.Controllers
{
    public class ShoppingController : Controller
    {
       // AdminDAL userdal = new AdminDAL();
        connection userdal = new connection();
        // GET: User
        public ActionResult List()
        {
            var data = userdal.Getusers();
            return View(data);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Sale user)
        {

            if (userdal.Insertuser(user))
            {
                TempData["Insertmsg"] = "user saved successful..";
                return RedirectToAction("List");
            }
            else
            {
                TempData["InsertErrorMsg"] = "data not saved..";
            }
            return View();
        }
        public ActionResult Details(int id)
        {

            var data = userdal.Getusers().Find(a => a.Id == id);
            return View(data);
        }
        public ActionResult Edit(int id)
        {

            var data = userdal.Getusers().Find(a => a.Id == id);
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(Sale user)
        {

            if (userdal.Updatetuser(user))
            {
                TempData["Updatemsg"] = "user updated successful..";
                return RedirectToAction("List");
            }
            else
            {
                TempData["updateErrorMsg"] = "data not updated..";
            }
            return View();
        }
        // [HttpPost]
        public ActionResult Remove(int id)
        {
            int r = userdal.Deletetuser(id);
            if (r > 0)
            {
                TempData["Deletedemsg"] = "user Deleted successful..";
                return RedirectToAction("List");
            }
            else
            {
                TempData["DeletedErrorMsg"] = "Data not Deleted..";
            }
            return View();


        }






    }
}
