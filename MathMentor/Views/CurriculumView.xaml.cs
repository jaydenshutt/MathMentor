using System.Windows.Controls;
using System.Windows.Input;
using MathMentor.ViewModels;

namespace MathMentor.Views;

public partial class CurriculumView : UserControl
{
    public CurriculumView()
    {
        InitializeComponent();
    }

    private void Lesson_Click(object sender, MouseButtonEventArgs e)
    {
        if (sender is Border { Tag: string id } && DataContext is CurriculumViewModel vm)
            vm.OpenLessonCommand.Execute(id);
    }
}
