using CommunityToolkit.Mvvm.ComponentModel;

namespace MathMentor.ViewModels;

public abstract partial class ViewModelBase : ObservableObject
{
    [ObservableProperty]
    private string _title = "";
}
