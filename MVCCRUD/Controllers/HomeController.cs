using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCRUD.Controllers
{
    public class HomeController : Controller
    {
        MVCCRUDDbContext _context = new MVCCRUDDbContext();

        public ActionResult Index()
        {
            var listofData = _context.Bond.ToList();
            return View(listofData);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Bond bond)
        {
            var check = _context.Bond.Find(bond.BondId);
            if (check != null)
            {
                ViewBag.Message = "Id Don`t be unique";
                return View(); 
            }
            if(ModelState.IsValid == false)
            {
                ViewBag.Message = "Form is invalid";
                return View();
            }
            _context.Bond.Add(bond);
            _context.SaveChanges();
            ViewBag.Message ="Data Insert of Bond Successfully";
            return RedirectToAction("index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = _context.Bond.Where(x => x.BondId == id).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(Bond bond)
        {
            var data = _context.Bond.Where(x => x.BondId == bond.BondId).FirstOrDefault();
            if( data != null)
            {
                data.Title = bond.Title;
                data.Cost = bond.Cost;
                data.Broker = bond.Broker;
                data.Coupon = bond.Coupon;
                data.Percent = bond.Percent;
                data.Nominal = bond.Nominal;
                data.Date_of_buy = bond.Date_of_buy;
                data.Date_of_maturity = bond.Date_of_maturity;
                data.Count = bond.Count;
                _context.SaveChanges();
            }
            return RedirectToAction("index");
        }
        public ActionResult Details(int id)
        {
            var data = _context.Bond.Where(x => x.BondId == id).FirstOrDefault();
            return View(data);
        }
        public ActionResult Delete(int id)
        {
            var data = _context.Bond.Where(x => x.BondId == id).FirstOrDefault();
            _context.Bond.Remove(data);
            _context.SaveChanges();
            ViewBag.Message = "Record of Bond Delete Successfully";
            return RedirectToAction("index");
        }
    }
}