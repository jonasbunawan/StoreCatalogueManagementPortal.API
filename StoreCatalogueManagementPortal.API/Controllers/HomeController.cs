using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StoreCatalogueManagementPortal.DataModel.Models;
using MongoDB.Driver;
using StoreCatalogueManagementPortal.API.Properties;
using MongoDB.Driver.Builders;
using MongoDB.Bson;

namespace StoreCatalogueManagementPortal.API.Controllers
{
    public class HomeController : Controller
    {
        public MongoDatabase mongodb;
        
        public HomeController()
        {
            var conn = new MongoClient(Settings.Default.ConnectionStringSetting);
            var server = conn.GetServer();
            mongodb = server.GetDatabase(Settings.Default.DbMongoName);
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
        
        //Category
        public ActionResult CategoryIndex()
        {
            try
            {
                var collection = mongodb.GetCollection<Category>("Category");

                return View("CategoryIndex", collection.FindAll().ToList<Category>());
            }
            catch (Exception ex)
            {
                
                return View("Error", ex);
            }
            
        }
        [HttpPost]
        public ActionResult CategoryIndex(Guid ID)
        {
            try
            {
                var collection = mongodb.GetCollection<Category>("Category");
                    return View("CategoryIndex", collection.FindAs<Category>(Query.EQ("_id", ID)));
                

                
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }

        }

        
     
        public ActionResult CreateCategory()
        {
            try { return View(); }
            catch(Exception ex) { return View("Error", ex); }
            
        }

        [HttpPost]
        public ActionResult CreateCategory(Category category)
        {
            try
            {
                var collection = mongodb.GetCollection<Category>("Category");
                category.CategoryID = Guid.NewGuid();
                collection.Insert(category);
                return RedirectToAction("CategoryIndex");
            }
            catch (Exception ex)
            {
                return View("Error",ex);
            }
        }
            
        public ActionResult UpdateCategory(Guid id)
        {
            try
            {
                MongoCollection<Category> Categories = mongodb.GetCollection<Category>("Category");
                Category category = Categories.FindOneAs<Category>(Query.EQ("_id", id));
                return View(category);
            }
            catch (Exception ex)
            { return View("Error", ex); }
        }

        [HttpPost]
        public ActionResult UpdateCategory(Category category)
        {
            try
            {
                var collection = mongodb.GetCollection<Category>("Category");
                IMongoQuery query = Query.EQ("_id", category.CategoryID);
                var update = Update.Set("CategoryName", category.CategoryName);
                collection.FindAndModify(query, SortBy.Null, update);
                return RedirectToAction("CategoryIndex");
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
            }

        public ActionResult DeleteCategory(Guid Id)
        {
            try
            {
                MongoCollection<Category> Categories = mongodb.GetCollection<Category>("Category");
                MongoCollection<SubCategory> SubCategories = mongodb.GetCollection<SubCategory>("SubCategory");

                Category category = Categories.FindOneAs<Category>(Query.EQ("_id", Id));
                SubCategory subcategory = SubCategories.FindOneAs<SubCategory>(Query.EQ("CategoryID", category.CategoryID));

                IMongoQuery query = Query.EQ("_id", category.CategoryID);

                if (!(subcategory == null))
                {

                        return View("Error");  
                }

                Categories.Remove(query);
                return RedirectToAction("CategoryIndex");

            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }

        //SubCategory
        public ActionResult SubCategoryIndex()
        {
            try
            {
                var collection = mongodb.GetCollection<SubCategory>("SubCategory");

                return View("SubCategoryIndex", collection.FindAll().ToList<SubCategory>());
            }
            catch (Exception ex)
            {

                return View("Error", ex);
            }

        }

        [HttpPost]
        public ActionResult SubCategoryIndex(Guid ID)
        {
            try
            {
                var collection = mongodb.GetCollection<SubCategory>("SubCategory");
                return View("SubCategoryIndex", collection.FindAs<SubCategory>(Query.EQ("_id", ID)));



            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }

        }



        public ActionResult CreateSubCategory()
        {
            
            try {
                MongoCollection<Category> collection = mongodb.GetCollection<Category>("Category");
                var categories = new List<Category>();
                categories = collection.FindAll().ToList();

                ViewBag.Categories = categories.Select(c => new SelectListItem() { Value = c.CategoryID.ToString(), Text = c.CategoryName });
                    

                return View();
            }
            catch (Exception ex) { return View("Error", ex); }

        }

        [HttpPost]
        public ActionResult CreateSubCategory(SubCategory Subcategory, string Categories)
        {
            try
            {
                var collection = mongodb.GetCollection<SubCategory>("SubCategory");

                Subcategory.SubCategoryID = Guid.NewGuid();
                Subcategory.CategoryID = Guid.Parse(Categories);
                collection.Insert(Subcategory);
                return RedirectToAction("SubCategoryIndex");
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }

        public ActionResult UpdateSubCategory(Guid id)
        {
            try
            {
                MongoCollection<SubCategory> SubCategories = mongodb.GetCollection<SubCategory>("SubCategory");
                SubCategory subcategory = SubCategories.FindOneAs<SubCategory>(Query.EQ("_id", id));
                MongoCollection<Category> collection = mongodb.GetCollection<Category>("Category");
                var categories = new List<Category>();
                categories = collection.FindAll().ToList();

                ViewBag.Categories = categories.Select(c => new SelectListItem() { Value = c.CategoryID.ToString(), Text = c.CategoryName });
                return View("UpdateSubCategory", subcategory);
            }
            catch (Exception ex)
            { return View("Error", ex); }
        }

        [HttpPost]
        public ActionResult UpdateSubCategory(SubCategory subcategory, string Categories)
        {
            try
            {
                var collection = mongodb.GetCollection<SubCategory>("SubCategory");
                IMongoQuery query = Query.EQ("_id", subcategory.SubCategoryID);
                var update = Update.Set("SubCategoryName", subcategory.SubCategoryName).Set("CategoryID", Guid.Parse(Categories));
                collection.FindAndModify(query, SortBy.Null, update);
                return RedirectToAction("SubCategoryIndex");
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }

        public ActionResult DeleteSubCategory(Guid Id)
        {
            try
            {
                MongoCollection<SubCategory> SubCategories = mongodb.GetCollection<SubCategory>("SubCategory");
                MongoCollection<Product> Products = mongodb.GetCollection<Product>("Product");

                SubCategory subcategory = SubCategories.FindOneAs<SubCategory>(Query.EQ("_id", Id));
                Product product = Products.FindOneAs<Product>(Query.EQ("SubCategoryID", subcategory.SubCategoryID));

                IMongoQuery query = Query.EQ("_id", subcategory.SubCategoryID);

                if (!(product == null))
                {

                    return View("Error");
                }

                SubCategories.Remove(query);
                return RedirectToAction("SubCategoryIndex");

            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }

        //Product
        public ActionResult ProductIndex()
        {
            try
            {
                var collection = mongodb.GetCollection<Product>("Product");

                return View("ProductIndex", collection.FindAll().ToList<Product>());
            }
            catch (Exception ex)
            {

                return View("Error", ex);
            }

        }

        [HttpPost]
        public ActionResult ProductIndex(Guid ID)
        {
            try
            {
                var collection = mongodb.GetCollection<Product>("Product");
                return View("ProductIndex", collection.FindAs<Product>(Query.EQ("_id", ID)));



            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }

        }



        public ActionResult CreateProduct()
        {

            try
            {
                MongoCollection<SubCategory> collection = mongodb.GetCollection<SubCategory>("SubCategory");
                var subcategories = new List<SubCategory>();
                subcategories = collection.FindAll().ToList();

                ViewBag.SubCategories = subcategories.Select(c => new SelectListItem() { Value = c.SubCategoryID.ToString(), Text = c.SubCategoryName });


                return View();
            }
            catch (Exception ex) { return View("Error", ex); }

        }

        [HttpPost]
        public ActionResult CreateProduct(Product Product, string SubCategories)
        {
            try
            {
                var collection = mongodb.GetCollection<Product>("Product");

                Product.ProductID = Guid.NewGuid();
                Product.SubCategoryID = Guid.Parse(SubCategories);
                collection.Insert(Product);
                return RedirectToAction("ProductIndex");
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }

        public ActionResult UpdateProduct(Guid id)
        {
            try
            {
                MongoCollection<Product> Products = mongodb.GetCollection<Product>("Product");
                Product product = Products.FindOneAs<Product>(Query.EQ("_id", id));
                MongoCollection<SubCategory> collection = mongodb.GetCollection<SubCategory>("SubCategory");
                var subcategories = new List<SubCategory>();
                subcategories = collection.FindAll().ToList();

                ViewBag.SubCategories = subcategories.Select(c => new SelectListItem() { Value = c.SubCategoryID.ToString(), Text = c.SubCategoryName });
                return View("UpdateProduct", product);
            }
            catch (Exception ex)
            { return View("Error", ex); }
        }

        [HttpPost]
        public ActionResult UpdateProduct(Product product, string SubCategories)
        {
            try
            {
                var collection = mongodb.GetCollection<Product>("Product");
                IMongoQuery query = Query.EQ("_id", product.ProductID);
                var update = Update.Set("ProductName", product.ProductName).Set("SubCategoryID", Guid.Parse(SubCategories));
                collection.FindAndModify(query, SortBy.Null, update);
                return RedirectToAction("ProductIndex");
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }

        public ActionResult DeleteProduct(Guid Id)
        {
            try
            {
                
                MongoCollection<Product> Products = mongodb.GetCollection<Product>("Product");

                IMongoQuery query = Query.EQ("_id", Id);



                Products.Remove(query);
                return RedirectToAction("ProductIndex");

            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }
    }
}



