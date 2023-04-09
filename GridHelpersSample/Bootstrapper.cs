using Caliburn.Micro;
using Ninject;
using System;
using System.Collections.Generic;
using System.Windows;

namespace GridHelpersSample
{
    public class Bootstrapper : BootstrapperBase
    {
        private IKernel kernel;
        public Bootstrapper()
        {
            Initialize();
        }

        protected override void Configure()
        {
            kernel = new StandardKernel();
            kernel.Bind<IWindowManager>().To<WindowManager>().InSingletonScope();
            kernel.Bind<IEventAggregator>().To<EventAggregator>().InSingletonScope();
            kernel.Bind<MyGridViewModel>().ToSelf().InTransientScope();
            //kernel.Bind<MyGridViewModel>().ToSelf().InSingletonScope();
            var bindings0 = kernel.GetBindings(typeof(MyGridViewModel));
            //var bindings1 = kernel.GetBindings(typeof(MainViewModel));
        }
        protected override async void OnStartup(object sender, StartupEventArgs e)
        {
            await DisplayRootViewForAsync<Main2ViewModel>();
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
