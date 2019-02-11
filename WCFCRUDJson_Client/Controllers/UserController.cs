using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WCFCRUDJson_Client.Models;
using WCFCRUDJson_Client.Viewmodels;
using WCFCRUDJson_Client.Services;

namespace WCFCRUDJson_Client.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Index()
        {
            UserServiceClient usc = new UserServiceClient();
            var usr = usc.FindAll();
            //ViewBag.ListUsers = usc.FindAll();
            return View(usr);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public ActionResult Create(UserViewModel pvm)
        {
            UserServiceClient usc = new UserServiceClient();
            usc.Create(pvm.user);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(string id)
        {
            UserServiceClient usc = new UserServiceClient();
            usc.Delete(usc.Find(id));
            return RedirectToAction("Index");
        }

        public ActionResult Edit(string id)
        {
            UserServiceClient usc = new UserServiceClient();
            UserViewModel uvm = new UserViewModel();
            uvm.user = usc.Find(id);
            return View("Edit", uvm);
        }

        [HttpPost]
        public ActionResult Edit(UserViewModel uvm)
        {
            UserServiceClient usc = new UserServiceClient();
            usc.Edit(uvm.user);
            return RedirectToAction("Index");
        }
    }
}