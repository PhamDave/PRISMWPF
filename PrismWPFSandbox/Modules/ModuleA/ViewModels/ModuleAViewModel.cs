using System;
using Prism;
using Prism.Events;
using Prism.Mvvm;

namespace ModuleA.ViewModels;

public class ModuleAViewModel : BindableBase, IActiveAware
{
    public ModuleAViewModel(IEventAggregator aggregator)
    {
        Message = "Hello from ModuleAViewModel";
    }
    
    private string _message;
    public string Message
    {
        get => _message;
        set => SetProperty(ref _message, value);
    }
    
    private bool _isActive;
    public bool IsActive
    {
        get => _isActive;
        set => SetProperty(ref _isActive, value);
    }

    public event EventHandler? IsActiveChanged;
}