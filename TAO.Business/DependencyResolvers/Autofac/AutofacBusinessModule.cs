using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using TAO.Business.Abstract;
using TAO.Business.Concrete;
using TAO.DataAccess.Abstract;
using TAO.DataAccess.Concrete.EntityFramework.Dals;
using TAO_Core.Utilities.Interceptors;


namespace TAO.Business.DependencyResolvers.Autofac
{
  public class AutofacBusinessModule:Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder.RegisterType<ProductManager>().As<IProductService>();
      builder.RegisterType<EfProductDal>().As<IProductDal>();

      builder.RegisterType<CategoryManager>().As<ICategoryService>();
      builder.RegisterType<EfCategoryDal>().As<ICategoryDal>();


      var assembly = System.Reflection.Assembly.GetExecutingAssembly();
      builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
        .EnableInterfaceInterceptors(new ProxyGenerationOptions()
        {
          Selector = new AspectInterceptorSelector()
        }).SingleInstance();
    }


  }
}
