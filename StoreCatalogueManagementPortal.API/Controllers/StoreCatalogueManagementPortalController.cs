using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using StoreCatalogueManagementPortal.DataModel.Models;
using StoreCatalogueManagementPortal.Services;
using System.Net.Http;
using System.Net;

namespace StoreCatalogueManagementPortal.API.Controllers
{
    public class CategoryController : ApiController
    {
        private readonly ICategoryService _categoryService;
        public CategoryController()
        {
            _categoryService = new CategoryService();
        }

        // GET: api/category/id
        public HttpResponseMessage Get(Guid id)
        {
            var category = _categoryService.Get(id);
            if (category != null) return Request.CreateResponse(HttpStatusCode.OK, category);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Category not found for provided id.");
        }

        public void Post([FromBody] Category Category)
        {
            _categoryService.Insert(Category);
        }

        public void Delete(Guid id)
        {
            _categoryService.Delete(id);
        }

        public void Put([FromBody] Category Category)
        {
            _categoryService.Update(Category);
        }
    }

    public class SubCategoryController : ApiController
    {
        private readonly ISubCategoryService _SubcategoryService;
        public SubCategoryController()
        {
            _SubcategoryService = new SubCategoryService();
        }

        // GET: api/category/id
        public HttpResponseMessage Get(Guid id)
        {
            var subcategory = _SubcategoryService.Get(id);
            if (subcategory != null) return Request.CreateResponse(HttpStatusCode.OK, subcategory);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "SubCategory not found for provided id.");
        }

        public void Post([FromBody] SubCategory SubCategory)
        {
            _SubcategoryService.Insert(SubCategory);
        }

        public void Delete(Guid id)
        {
            _SubcategoryService.Delete(id);
        }

        public void Put([FromBody] SubCategory SubCategory)
        {
            _SubcategoryService.Update(SubCategory);
        }
    }

    public class ProductController : ApiController
    {
        private readonly IProductService _productService;
        public ProductController()
        {
            _productService = new ProductService();
        }

        // GET: api/category/id
        public HttpResponseMessage Get(Guid id)
        {
            var product = _productService.Get(id);
            if (product != null) return Request.CreateResponse(HttpStatusCode.OK, product);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Product not found for provided id.");
        }

        public void Post([FromBody] Product Product)
        {
            _productService.Insert(Product);
        }

        public void Delete(Guid id)
        {
            _productService.Delete(id);
        }

        public void Put([FromBody] Product Product)
        {
            _productService.Update(Product);
        }
    }
}