using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Windows;

namespace GridHelpersSample
{
    public class Bootstrapper : BootstrapperBase
    {
        //private IKernel kernel;
        public Bootstrapper()
        {
            Initialize();
            //StartDebugLogger();
        }

        //protected override void Configure()
        //{
        //    kernel = new StandardKernel();
        //    kernel.Bind<IWindowManager>().To<WindowManager>().InSingletonScope();
        //    kernel.Bind<IEventAggregator>().To<EventAggregator>().InSingletonScope();
        //    kernel.Bind<IConfig>().To<ConfigRoot>().InSingletonScope();

            //kernel.Bind<IResultFactory>().To<ResultFactory>();
            //kernel.Bind<IParser>().To<Parser>();
            //kernel.Bind<ShellViewModel>().ToSelf().InSingletonScope();
            //kernel.Bind<MainViewModel>().ToSelf().InSingletonScope();
            //kernel.Bind<TrayIconViewModel>().ToSelf().InSingletonScope();

            //return;

            //_container.Instance(_container);
            //_container
            //  .Singleton<IWindowManager, WindowManager>()
            //  .Singleton<IEventAggregator, EventAggregator>()
            //  .PerRequest<IResultFactory, ResultFactory>();



            //foreach (var assembly in SelectAssemblies())
            //{
            //    assembly.GetTypes()
            //   .Where(type => type.IsClass)
            //   .Where(type => type.Name.EndsWith("ViewModel"))
            //   .ToList()
            //   .ForEach(viewModelType => _container.RegisterPerRequest(
            //       viewModelType, viewModelType.ToString(), viewModelType));
            //}
       // }
        protected override async void OnStartup(object sender, StartupEventArgs e)
        {
            await DisplayRootViewForAsync<MainViewModel>();
            //await DisplayRootViewForAsync<ShellViewModel>();
            //var c = IoC.Get<SimpleContainer>();
            //await DisplayRootViewForAsync(typeof(ShellViewModel));
        }
        //protected override object GetInstance(Type service, string key)
        //{
        //    return kernel.Get(service);
        //}

        //protected override IEnumerable<object> GetAllInstances(Type service)
        //{
        //    return kernel.GetAll(service);
        //}

        //protected override void BuildUp(object instance)
        //{
        //    _container.BuildUp(instance);
        //}
    }
}
