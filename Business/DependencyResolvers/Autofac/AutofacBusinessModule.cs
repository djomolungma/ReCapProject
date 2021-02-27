using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        //Burada Autofac IoC altyapısı kullanılmıştır (aşağıda kurulan ortam açıklanmıştır)!
        //Dot.Net in IoC si yerine Autofac i WebAPI Program.cs ye ekliyoruz bunun için
        // CreateHostBuilder fonuksiyonuna 
        //.UseServiceProviderFactory(new AutofacServiceProviderFactory())
        //ve
        //.ConfigureContainer<ContainerBuilder>(builder=>
        //{
        //    builder.RegisterModule(new AutofacBusinessModule());
        //})
        //kodlarını ekliyoruz

        /// ///////////////////////////////////////////////////////////////////////////////////////////
        //Buradaki IoC yerine Manage nuget packages'dan Business katmanına Autofac ve Autofac.Extras
        //Autofac teknolojisini kuruyoruz "Autofac" ve "Autofac.Extras.DynamicProxy" yi kuruyoruz

        //Autofac,Ninject,CastleWindsor,StructureMap,LightInject,DryInject -->IoC Container için yapılardır bunlardan birini kullanacağız
        //Postrsharp (ücretli bir IoC)

        //Net.core ile Autofac i kullanabiliriz (bize IoC container altyapısı sunmakta)
        //Autofac bize AOP imkanı sunmakta ondan dolayı onu kullanacağız (2. ek çok kullanılan Ninject)

        //Biz AOP (Aspect Oriented Programming) yapacağız 
        //AOP bir methodun önünde, sonunda çalışan kod parçalıklarını AOP mimarisi ile vereceğiz

        //Biri constructorda IProductService isterse ProductManager() i new le ve ona ver !!!
        //services.AddSingleton<IProductService, ProductManager>();//Bana arka planda bir referans oluştur IoC bizim yerine new ler
        //services.AddSingleton<IProductDal, EFProductDal>();

        //services.AddTransient - datalı referanslar için
        //services.AddScoped  - datalı referanslar için

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BrandManager>().As<IBrandService>().SingleInstance();
            builder.RegisterType<EfBrandDal>().As<IBrandDal>().SingleInstance();


            builder.RegisterType<CarManager>().As<ICarService>().SingleInstance();
            builder.RegisterType<EfCarDal>().As<ICarDal>().SingleInstance();

            builder.RegisterType<CustomerManager>().As<ICustomerService>().SingleInstance();
            builder.RegisterType<EfCustomerDal>().As<ICustomerDal>().SingleInstance();

            builder.RegisterType<ColorManager>().As<IColorService>().SingleInstance();
            builder.RegisterType<EfColorDal>().As<IColorDal>().SingleInstance();

            builder.RegisterType<RentalManager>().As<IRentalService>().SingleInstance();
            builder.RegisterType<EfRentalDal>().As<IRentalDal>().SingleInstance();

            builder.RegisterType<ModelManager>().As<IModelService>().SingleInstance();
            builder.RegisterType<EfModelDal>().As<IModelDal>().SingleInstance();

            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();

            builder.RegisterType<CarImageManager>().As<ICarImageService>().SingleInstance();
            builder.RegisterType<EfCarImageDal>().As<ICarImageDal>().SingleInstance();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
