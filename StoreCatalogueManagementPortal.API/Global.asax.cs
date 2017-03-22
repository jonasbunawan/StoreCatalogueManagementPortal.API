using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using StoreCatalogueManagementPortal.DataModel.Models;

namespace StoreCatalogueManagementPortal.API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
    //       ModelBinders.Binders.Add(typeof(Category), new MyClassBinder());
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

    //    public class MyClassBinder : DefaultModelBinder
    //    {
    //        protected override object CreateModel(ControllerContext controllerContext, ModelBindingContext bindingContext, Type modelType)
    //        {
    //            var model = (Category)base.CreateModel(controllerContext, bindingContext, modelType);
    //            model.CategoryID = Guid.NewGuid();
    //            return model;
    //        }
    //    }
    }
}
