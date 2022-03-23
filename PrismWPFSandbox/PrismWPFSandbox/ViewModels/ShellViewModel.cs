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
using Prism.Modularity;
using PrismWPFSandbox.Views;

namespace PrismWPFSandbox.ViewModels
{
    internal class ShellViewModel : BindableBase
    {
        public ShellViewModel(IContainer container,
            IEventAggregator eventAggregator, 
            IRegionManager regionManager,
            IModuleManager moduleManager)
        {
            _container = container;
            _eventAggregator = eventAggregator;
            _regionManager = regionManager;
            _moduleManager = moduleManager;

            _shellRegionName01 = KnownRegions.Region01;
            AddModuleBCommand = new DelegateCommand<object>(AddModuleBToRegion02, CanAddToRegion);
        }

        /// <summary>
        /// I cannot figure this out.  How to add ModuleBView to Region 02 and pass parameters at the same time?
        /// where Main app doesn't take a dependency on ModuleB project.  Loosely coupled.
        /// </summary>
        /// <param name="obj"></param>
        private void AddModuleBToRegion02(object obj)
        {
            // try to add to region by ViewModel to also be able to send params           
            var vm = _container.Resolve<Func<string, IModuleBViewModel>>(KnownServiceKeys.ModuleViewModelB);
            var viewModel = vm($"Parameterized {KnownServiceKeys.ModuleViewModelB} Title [{DateTime.Now}]");

            var region = _regionManager.Regions[KnownRegions.Region02];
            if (!region.Views.Contains(viewModel))
            {
                region.Add(viewModel);
                region.Activate(viewModel); 
            } 

            // try to add to region by view
            _regionManager.RegisterViewWithRegion(KnownRegions.Region02, 
                GetView);

            var v = _container.Resolve<UserControl>(KnownServiceKeys.ModuleViewB);
            _regionManager.AddToRegion(KnownRegions.Region02, v);

            // Try Func<object>
            //_regionManager.RegisterViewWithRegion(KnownRegions.Region02, GetView);
        }

        object GetView()
        {
            return _container.Resolve<UserControl>(KnownServiceKeys.ModuleViewB);
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
        private readonly IModuleManager _moduleManager;

        public ICommand AddModuleBCommand { get; set; }
    }
}
