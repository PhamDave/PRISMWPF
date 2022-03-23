using System;
using Infrastructure.Interfaces;
using Prism;
using Prism.Events;
using Prism.Mvvm;

namespace ModuleB.ViewModels;

public class ModuleBViewModel : BindableBase, IModuleBViewModel, IActiveAware
{
    public ModuleBViewModel(string message)
    {
        Message = message;
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