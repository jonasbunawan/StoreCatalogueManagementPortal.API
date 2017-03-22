using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreCatalogueManagementPortal.DataModel.Models;

namespace StoreCatalogueManagementPortal.Services
{
    public interface ICategoryService
    {
        void Insert(Category Category);
        Category Get(Guid i);
        void Delete(Guid id);
        void Update(Category Category);
    }

    public interface ISubCategoryService
    {
        void Insert(SubCategory SubCategory);
        SubCategory Get(Guid i);
        void Delete(Guid id);
        void Update(SubCategory SubCategory);
    }

    public interface IProductService
    {
        void Insert(Product Product);
        Product Get(Guid i);
        void Delete(Guid id);
        void Update(Product Product);
    }
}
