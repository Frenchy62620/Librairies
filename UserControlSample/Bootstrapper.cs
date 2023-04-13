using Caliburn.Micro;
using Ninject;
using System;
using System.Collections.Generic;
using System.Windows;
using UserControlSample.ViewModels;

namespace UserControlSample
{
    public class Bootstrapper : BootstrapperBase
    {
        private IKernel kernel;
        //static Bootstrapper()
        //{
        //    LogManager.GetLog = type => new DebugLogger(type);
        //}
        public Bootstrapper()
        {
            Initialize();
        }

        protected override void Configure()
        {
            kernel = new StandardKernel();
            kernel.Bind<IWindowManager>().To<WindowManager>().InSingletonScope();
            kernel.Bind<IEventAggregator>().To<EventAggregator>().InSingletonScope();
            //kernel.Bind<ILog>().To<DebugLogger>().InSingletonScope();

            //kernel.Bind<ILog>().ToMethod(x => new DebugLogger());

            //var bindings0 = kernel.GetBindings(typeof(MyGridViewModel));
            var bindings1 = kernel.GetBindings(typeof(ILog));
        }
        protected override async void OnStartup(object sender, StartupEventArgs e)
        {
            await DisplayRootViewForAsync<MainViewModel>();
        }
        protected override object GetInstance(Type service, string key)
        {
            return kernel.Get(service);
        }
        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return kernel.GetAll(service);
        }
        protected override void BuildUp(object instance)
        {
            kernel.Inject(instance);
        }
    }
}
