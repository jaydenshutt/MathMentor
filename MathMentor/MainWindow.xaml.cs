using System.Windows;
using System.Windows.Input;
using MathMentor.ViewModels;

namespace MathMentor;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
    {
        if (DataContext is not MainViewModel main) return;

        // Ctrl+1..4 navigation shortcuts
        if (Keyboard.Modifiers == ModifierKeys.Control)
        {
            switch (e.Key)
            {
                case Key.D1:
                case Key.NumPad1:
                    main.GoDashboardCommand.Execute(null);
                    e.Handled = true;
                    break;
                case Key.D2:
                case Key.NumPad2:
                    main.GoCurriculumCommand.Execute(null);
                    e.Handled = true;
                    break;
                case Key.D3:
                case Key.NumPad3:
                    main.GoReviewCommand.Execute(null);
                    e.Handled = true;
                    break;
                case Key.D4:
                case Key.NumPad4:
                    main.GoSettingsCommand.Execute(null);
                    e.Handled = true;
                    break;
                case Key.D5:
                case Key.NumPad5:
                    main.GoAboutCommand.Execute(null);
                    e.Handled = true;
                    break;
                case Key.T:
                    main.ToggleThemeCommand.Execute(null);
                    e.Handled = true;
                    break;
            }
        }
    }
}
