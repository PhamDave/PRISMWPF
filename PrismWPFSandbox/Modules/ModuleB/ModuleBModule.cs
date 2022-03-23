
using DryIoc;
using Infrastructure.Interfaces;
using Infrastructure.ResourceNames;
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
        
    }

    public void OnInitialized(IContainerProvider containerProvider)
    {

    }
}