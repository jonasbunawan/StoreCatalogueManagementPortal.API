using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using StoreCatalogueManagementPortal.DataModel.Models;
using StoreCatalogueManagementPortal.DataModel.StoreCataloguesManagementPortalRepository;
using System.Configuration;

namespace StoreCatalogueManagementPortal.DataModel.UnitOfWork
{
    public class CategoryUnitOfWork
    {
        private MongoDatabase _database;
        protected StoreCatalogueManagementPortalRepository<Category> _Categories;
        public CategoryUnitOfWork()
        {
            var connectionString = ConfigurationManager.AppSettings["MongoDBConnectionString"];
            var client = new MongoClient(connectionString);
            var server = client.GetServer();
            var databaseName = ConfigurationManager.AppSettings["MongoDBDatabaseName"];
            _database = server.GetDatabase(databaseName);
        }

        public StoreCatalogueManagementPortalRepository<Category> Categories
        {
            get
            {
                if (_Categories == null) _Categories = new StoreCatalogueManagementPortalRepository<Category>(_database, "Categories");
                return _Categories;
            }
        }
    }

    public class SubCategoryUnitOfWork
    {
        private MongoDatabase _database;
        protected StoreCatalogueManagementPortalRepository<SubCategory> _SubCategories;
        public SubCategoryUnitOfWork()
        {
            var connectionString = ConfigurationManager.AppSettings["MongoDBConnectionString"];
            var client = new MongoClient(connectionString);
            var server = client.GetServer();
            var databaseName = ConfigurationManager.AppSettings["MongoDBDatabaseName"];
            _database = server.GetDatabase(databaseName);
        }

        public StoreCatalogueManagementPortalRepository<SubCategory> SubCategories
        {
            get
            {
                if (_SubCategories == null) _SubCategories = new StoreCatalogueManagementPortalRepository<SubCategory>(_database, "SubCategories");
                return _SubCategories;
            }
        }
    }

    public class ProductUnitOfWork
    {
        private MongoDatabase _database;
        protected StoreCatalogueManagementPortalRepository<Product> _Products;
        public ProductUnitOfWork()
        {
            var connectionString = ConfigurationManager.AppSettings["MongoDBConnectionString"];
            var client = new MongoClient(connectionString);
            var server = client.GetServer();
            var databaseName = ConfigurationManager.AppSettings["MongoDBDatabaseName"];
            _database = server.GetDatabase(databaseName);
        }

        public StoreCatalogueManagementPortalRepository<Product> Products
        {
            get
            {
                if (_Products == null) _Products = new StoreCatalogueManagementPortalRepository<Product>(_database, "Products");
                return _Products;
            }
        }
    }
}
