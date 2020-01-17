using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MuranoTest.Models;

namespace MuranoTest.Controllers
{
    public class SumPageController : Controller
    {
        public ActionResult Index()
        {
            DBHandler IHandler = new DBHandler();
            ModelState.Clear();
            List<OneRow> iList = new List<OneRow>();
            iList = IHandler.GetItemsList();
            return View(iList);
        }

        [HttpGet]
        public ActionResult Edit()
        {
            DBHandler IHandler = new DBHandler();
            List<OneRow> iList = new List<OneRow>();
            iList = IHandler.GetItemsList();
            return View(iList);
        }
        [HttpPost]
        public ActionResult Edit([FromForm] List<OneRow> iList)
        {
            try
            {
                DBHandler ItemHandler = new DBHandler();
                ItemHandler.UpdateItem(iList);
                return RedirectToAction("Index");
            }
            catch { return View(iList); }
        }
    }
}