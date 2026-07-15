using System.Windows;
using MathMentor.Services;
using MathMentor.ViewModels;

namespace MathMentor;

public partial class App : Application
{
    public static ICurriculumService Curriculum { get; private set; } = null!;
    public static IProgressService Progress { get; private set; } = null!;
    public static ISettingsService Settings { get; private set; } = null!;
    public static INavigationService Navigation { get; private set; } = null!;
    public static MainViewModel MainVm { get; private set; } = null!;

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        DispatcherUnhandledException += (_, args) =>
        {
            MessageBox.Show(
                $"Something went wrong:\n\n{args.Exception.Message}",
                "MathMentor",
                MessageBoxButton.OK,
                MessageBoxImage.Error);
            args.Handled = true;
        };

        try
        {
            Curriculum = new CurriculumService();
            Progress = new ProgressService(Curriculum);
            Settings = new SettingsService();
            Settings.ApplyTheme();
            Settings.ApplyFontScale();

            // Wire navigation with a holder so NavigateTo can always reach MainViewModel
            // after construction (never navigate while the main instance is still null).
            MainViewModel? main = null;
            Navigation = new NavigationService(Curriculum, Progress, Settings, () => main);

            main = new MainViewModel(Navigation, Progress, Settings);
            MainVm = main;

            // Now that main is assigned, load the first page into CurrentViewModel.
            main.Start();

            // Safety net: never open with a blank content region.
            if (main.CurrentViewModel is null)
                Navigation.NavigateToDashboard();

            var window = new MainWindow
            {
                DataContext = main
            };
            window.Show();
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                $"MathMentor failed to start:\n\n{ex.Message}\n\n{ex.InnerException?.Message}",
                "MathMentor",
                MessageBoxButton.OK,
                MessageBoxImage.Error);
            Shutdown(1);
        }
    }
}
