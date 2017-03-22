using System;
using System.Web;
using System.Web.Mvc;

namespace StoreCatalogueManagementPortal.API
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {

            filters.Add(new HandleErrorAttribute());
            
        }
    }

    
}
