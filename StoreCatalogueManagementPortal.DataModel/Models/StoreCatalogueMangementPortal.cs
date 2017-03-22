using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;

namespace StoreCatalogueManagementPortal.DataModel.Models
{
    public class Category
    {
        [BsonElement("_id")]
        public Guid CategoryID
        {
            get;
            set;
        }

        public string CategoryName
        {
            get;
            set;
        }
    }

    public class SubCategory
    {
        [BsonElement("_id")]
        public Guid SubCategoryID
        {
            get;
            set;
        }

        public string SubCategoryName
        {
            get;
            set;
        }

        public Guid CategoryID
        {

            get;
            set;
        }

    }

    public class Product
    {
        [BsonElement("_id")]
        public Guid ProductID
        {
            get;
            set;

         
        }

        public string ProductName
        {
            get;
            set;
        }

        public Guid SubCategoryID
        {
            get;
            set;
          
            
        }
    }
} 