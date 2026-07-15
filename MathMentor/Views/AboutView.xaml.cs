using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace MathMentor.Views;

public partial class AboutView : UserControl
{
    public AboutView()
    {
        InitializeComponent();
    }

    private void LinkedIn_RequestNavigate(object sender, RequestNavigateEventArgs e)
    {
        try
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = e.Uri.AbsoluteUri,
                UseShellExecute = true
            });
        }
        catch
        {
            // Ignore navigation failures; primary button still works.
        }

        e.Handled = true;
    }
}
