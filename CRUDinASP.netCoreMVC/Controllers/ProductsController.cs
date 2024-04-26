using CRUDinASP.netCoreMVC.Data;
using CRUDinASP.netCoreMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Permissions;

namespace CRUDinASP.netCoreMVC.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext db;
        public ProductsController(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            var data = db.products1s.FromSqlRaw("select * from products1s").ToList();
            return View(data);
        }

        public IActionResult AddProducts() { 
            
            return View();
        }

        public IActionResult AddProductsPage()
        {

            return RedirectToAction("AddProducts");
        }

        [HttpPost]
        public IActionResult AddProducts(Products1 p)
        {
            db.Database.ExecuteSqlRaw($"insert into products1s  (Pname, Pcat, Price) values ('{p.Pname}','{p.Pcat}','{p.Price}')");
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult DeleteProducts(int id)
        {
            db.Database.ExecuteSqlRaw($"delete from products1s where Pid={id}");
            return RedirectToAction("Index");
        }

        public IActionResult UpdateProducts(int id)
        {
            var data = db.products1s.FromSqlRaw($"select * from products1s where Pid={id}").ToList().FirstOrDefault();
            return View(data);
        }

        [HttpPost]
        public IActionResult UpdateProducts(Products1 p)
        {
            db.Database.ExecuteSqlRaw($"update products1s set Pname='{p.Pname}', Pcat='{p.Pcat}', Price='{p.Price}' where Pid={p.Pid}");
            return RedirectToAction("Index");
        }
    }
}
