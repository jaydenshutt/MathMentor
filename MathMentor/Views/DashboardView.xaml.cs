using System.Windows.Controls;
using System.Windows.Input;
using MathMentor.ViewModels;

namespace MathMentor.Views;

public partial class DashboardView : UserControl
{
    public DashboardView()
    {
        InitializeComponent();
    }

    private void Category_Click(object sender, MouseButtonEventArgs e)
    {
        if (sender is Border { Tag: string id } && DataContext is DashboardViewModel vm)
            vm.OpenCategoryCommand.Execute(id);
    }

    private void Lesson_Click(object sender, MouseButtonEventArgs e)
    {
        if (sender is Border { Tag: string id } && DataContext is DashboardViewModel vm)
            vm.OpenLessonCommand.Execute(id);
    }
}
