using System.Windows.Controls;
using Infrastructure.Interfaces;

namespace ModuleB.Views;

public partial class ModuleBView : UserControl, IModuleBView
{
    public ModuleBView()
    {
        InitializeComponent();
    }
}