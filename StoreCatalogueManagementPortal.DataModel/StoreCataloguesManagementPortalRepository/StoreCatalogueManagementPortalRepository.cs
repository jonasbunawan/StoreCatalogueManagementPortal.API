using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver.Builders;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace StoreCatalogueManagementPortal.DataModel.StoreCataloguesManagementPortalRepository
{
    public class StoreCatalogueManagementPortalRepository<T> where T: class
    {
        private MongoDatabase _database;
        private string _tableName;
        private MongoCollection<T> _collection;

        public StoreCatalogueManagementPortalRepository(MongoDatabase db, string tblName)
        {
            _database = db;
            _tableName = tblName;
            _collection = _database.GetCollection<T>(tblName);
        }

        public T Get(Guid i)
        {
            return _collection.FindOneById(i);
        }

        public void Add (T entity)
        {
            _collection.Insert(entity);
        }

        public void Delete(Expression<Func<T, Guid >> queryExpression, Guid id)
        {
            var query = Query<T>.EQ(queryExpression, id);
            _collection.Remove(query);
        }

        public void Update(Expression <Func <T, Guid >> queryExpression, Guid id, T entity)
        {
            var query = Query<T>.EQ(queryExpression, id);
            _collection.Update(query, Update<T>.Replace(entity));
        }
    }
}
