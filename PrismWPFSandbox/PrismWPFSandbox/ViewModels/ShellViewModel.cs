using Prism.Commands;
using Prism.Events;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using DryIoc;
using Infrastructure;
using Infrastructure.Interfaces;
using Infrastructure.ResourceNames;

namespace PrismWPFSandbox.ViewModels
{
    internal class ShellViewModel : BindableBase
    {
        public ShellViewModel(IContainer container,
            IEventAggregator eventAggregator, 
            IRegionManager regionManager)
        {
            _container = container;
            _eventAggregator = eventAggregator;
            _regionManager = regionManager;

            _shellRegionName01 = KnownRegions.Region01;
            NewChartCommand = new DelegateCommand<object>(AddModuleBToRegion02, CanAddToRegion);
        }

        /// <summary>
        /// Add Module B to Region02
        /// </summary>
        /// <param name="obj"></param>
        private void AddModuleBToRegion02(object obj)
        {
            var vm = _container.Resolve<Func<string, IModuleAViewModel>>(KnownServiceKeys.ModuleViewModelB);
            var viewModel = vm($"Parameterized {KnownServiceKeys.ModuleViewModelB} Title [{DateTime.Now}]");
            
            var v = _container.Resolve<UserControl>(KnownServiceKeys.ModuleViewB);
            _regionManager.AddToRegion(KnownRegions.Region02, v);

            IRegion region = _regionManager.Regions[KnownRegions.Region02]; //get the region
            
            if (!region.Views.Contains(viewModel))
                region.Add(viewModel); //add the viewModel
            
            region.Activate(viewModel); //active the viewModel

            // if (!region.Views.Contains(viewModel))
            //     _regionManager.RegisterViewWithRegion(KnownRegionNames.TabGroupPane02, typeof())

            //var r = _regionManager.Regions[KnownRegionNames.TabGroupPane01].Views;
        }
        private bool CanAddToRegion(object arg)
        {
            return true;
        }

        private string _title = "PRISM WPF Sandbox";
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        private string _shellRegionName01;
        public string ShellRegionName01
        {
            get => _shellRegionName01;
            set => SetProperty(ref _shellRegionName01, value);
        }

        private readonly IContainer _container;
        private readonly IEventAggregator _eventAggregator;
        private readonly IRegionManager _regionManager;

        public ICommand NewChartCommand { get; set; }
    }
}
