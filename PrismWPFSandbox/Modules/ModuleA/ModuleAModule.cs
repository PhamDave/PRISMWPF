using Infrastructure.ResourceNames;
using ModuleA.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace ModuleA;

[Module(ModuleName = ModuleNames.ModuleAModule, OnDemand = false)]
[ViewSortHint("20")]
public class ModuleAModule : IModule
{
    public void RegisterTypes(IContainerRegistry containerRegistry)
    {
        containerRegistry.RegisterForNavigation<ModuleAView>();
    }

    public void OnInitialized(IContainerProvider containerProvider)
    {
        var regionManager = containerProvider.Resolve<IRegionManager>();
        regionManager?.RegisterViewWithRegion(KnownRegions.Region01, typeof(ModuleAView));
    }
}