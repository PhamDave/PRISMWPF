
using DryIoc;
using Infrastructure.Interfaces;
using Infrastructure.ResourceNames;
using ModuleB.ViewModels;
using ModuleB.Views;
using Prism.Ioc;
using Prism.DryIoc;
using Prism.Modularity;
using Prism.Regions;


namespace ModuleB;
[Module(ModuleName = ModuleNames.ModuleBModule, OnDemand = false)]
public class ModuleBModule : IModule
{
    public void RegisterTypes(IContainerRegistry containerRegistry)
    {
        containerRegistry.Register<IModuleBViewModel, ModuleBViewModel>(KnownServiceKeys.ModuleViewModelB);
        containerRegistry.Register<IModuleBView, ModuleBView>(KnownServiceKeys.ModuleViewB);
    }

    public void OnInitialized(IContainerProvider containerProvider)
    {
        
    }
}