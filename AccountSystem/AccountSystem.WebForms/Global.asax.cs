namespace AccountSystem.WebForms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Optimization;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.SessionState;

    using Ninject.Web.Common;
    using Ninject;
    using AccountSystem.Data;
    using System.Reflection;

    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }

    //public class Global : NinjectHttpApplication
    //{
    //    protected override IKernel CreateKernel()
    //    {
    //        IKernel kernel = new StandardKernel();
    //        //kernel.Load(Assembly.GetExecutingAssembly());

    //        RegisterMappings(kernel);

    //        return kernel;
    //    }

    //    private void RegisterMappings(IKernel kernel)
    //    {
    //        kernel.Bind<IAccountSystemData>().To<AccountSystemData>();//.WithConstructorArgument("context", c => new AccountSystemDbContext());
    //    }

    //    protected override void OnApplicationStarted()
    //    {
    //        base.OnApplicationStarted();

    //        RouteConfig.RegisterRoutes(RouteTable.Routes);
    //        BundleConfig.RegisterBundles(BundleTable.Bundles);

    //        this.CreateKernel();
    //    }
    //}
}