using ShoppingPage.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;

namespace ShoppingPage.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            var db = new ShoppingEntities();
           
            var data= db.Products.ToList();
            
            return View(data);
            
        }
        public ActionResult Customer()
        {
            var db = new ShoppingEntities();
            var data = db.Products.ToList();
            return View(data);
        }
        [HttpGet]
        public ActionResult ShowSelectedProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ShowSelectedProduct(int[] selectedProducts)
        {
            var db = new ShoppingEntities();
            if (selectedProducts == null || selectedProducts.Length == 0)
            {
                return RedirectToAction("Error");
            }


            var selectedProductList = db.Products.Where(p => selectedProducts.Contains(p.ProductId)).ToList();

            return View("ShowSelectedProduct", selectedProductList);


           
        }
       //public ActionResult Order(int[] selectedProducts)
       // {

       //     foreach (int productId in selectedProducts)
       //     {
                
       //         var order = new Order
       //         {
       //             ProductId = productId,
       //             Quantity = 1,
       //             ProductName = ProductName,
       //             ProductPrice = ProductPrice, 
       //             OrderDate = DateTime.Now, 
       //         };
       //         var db = new ShoppingEntities();

       //         db.Orders.Add(order);
       //         db.SaveChanges();
                


       //     }
        //[HttpPost]
        //public ActionResult Order(Order o)
        //{
        //    var db = new ShoppingEntities();
        //    db.Orders.Add(o);
        //    db.SaveChanges();
        //    return RedirectToAction("Order");


        //}



        [HttpGet]
        public ActionResult Create()
        {
            var db = new ShoppingEntities();
            ViewBag.Product = db.Categories.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product p)
        {
                var db = new ShoppingEntities();
                db.Products.Add(p);
                db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var db = new ShoppingEntities();
            var data = db.Products.Find(id);
            return View(data);

        }
        [HttpPost]
        public ActionResult Edit(Product d)
        {
            var db = new ShoppingEntities();
            var ex = db.Products.Find(d.ProductId);
            ex.ProductName = d.ProductName;
            ex.ProductPrice = d.ProductPrice;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var db = new ShoppingEntities();
            var ex = db.Products.Find(id);
            db.Products.Remove(ex);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //all Controller for Category 
        [HttpGet]
        public ActionResult AddCategory()
        {
            var db = new ShoppingEntities();
            ViewBag.Categories = db.Categories.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category c)
        {

            var db = new ShoppingEntities();
            db.Categories.Add(c);
            db.SaveChanges();


            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditCategory(int id)
        {
           
            return View();
           
        }
        [HttpPost]
        public ActionResult EditCategory(Product d)
        {

            return View();
        }


        


    }
}