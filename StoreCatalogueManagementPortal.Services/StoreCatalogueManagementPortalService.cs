using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreCatalogueManagementPortal.DataModel.Models;
using StoreCatalogueManagementPortal.DataModel.UnitOfWork;

namespace StoreCatalogueManagementPortal.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly CategoryUnitOfWork _cUnitOfWork;
        public CategoryService()
        {
            _cUnitOfWork = new CategoryUnitOfWork();
        }

        public Category Get(Guid i)
        {
            return _cUnitOfWork.Categories.Get(i);
        }

        public void Delete(Guid id)
        {
            _cUnitOfWork.Categories.Delete(s => s.CategoryID, id);
        }

        public void Insert(Category Category)
        {
            _cUnitOfWork.Categories.Add(Category);
        }

        public void Update(Category Category)
        {
            _cUnitOfWork.Categories.Update(s => s.CategoryID, Category.CategoryID, Category);
        }
    }

    public class SubCategoryService : ISubCategoryService
    {
        private readonly SubCategoryUnitOfWork _sUnitOfWork;
        public SubCategoryService()
        {
            _sUnitOfWork = new SubCategoryUnitOfWork();
        }

        public SubCategory Get(Guid i)
        {
            return _sUnitOfWork.SubCategories.Get(i);
        }

        public void Delete(Guid id)
        {
            _sUnitOfWork.SubCategories.Delete(s => s.SubCategoryID, id);
        }

        public void Insert(SubCategory SubCategory)
        {
            _sUnitOfWork.SubCategories.Add(SubCategory);
        }

        public void Update(SubCategory SubCategory)
        {
            _sUnitOfWork.SubCategories.Update(s => s.SubCategoryID, SubCategory.SubCategoryID, SubCategory);
        }
    }

    public class ProductService : IProductService
    {
        private readonly ProductUnitOfWork _pUnitOfWork;
        public ProductService()
        {
            _pUnitOfWork = new ProductUnitOfWork();
        }

        public Product Get(Guid i)
        {
            return _pUnitOfWork.Products.Get(i);
        }

        public void Delete(Guid id)
        {
            _pUnitOfWork.Products.Delete(s => s.ProductID, id);
        }

        public void Insert(Product Product)
        {
            _pUnitOfWork.Products.Add(Product);
        }

        public void Update(Product Product)
        {
            _pUnitOfWork.Products.Update(s => s.ProductID, Product.ProductID, Product);
        }
    }
}
