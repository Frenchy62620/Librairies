using Caliburn.Micro;
using Ninject.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WpfApp1.ViewModels
{
    public class MyModalDialogViewModel : Screen
    {
        private readonly IResolutionRoot resolutionRoot;
        private readonly IEventAggregator eventAggregator;

        public MyModalDialogViewModel(IResolutionRoot resolutionRoot, IEventAggregator eventAggregator)
        {
            this.resolutionRoot = resolutionRoot;
            this.eventAggregator = eventAggregator;
        }
        public async void DoAccept()
        {
            await TryCloseAsync(true);
        }
        public async void DoCancel()
        {
            await TryCloseAsync(false);
        }
        public override async Task<bool> CanCloseAsync(CancellationToken cancellationToken)
        {
            await Task.Delay(500);
            return true;//true to accept, false to refuse the close
        }
    }
}
