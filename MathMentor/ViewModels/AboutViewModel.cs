using System.Diagnostics;
using System.Windows;
using System.Windows.Media.Imaging;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MathMentor.Services;

namespace MathMentor.ViewModels;

public partial class AboutViewModel : ViewModelBase
{
    private readonly INavigationService _nav;

    public string CreatorName => "Jayden Shutt";
    public string CreatorCredit => "Created by Jayden Shutt";
    public string LinkedInUrl => "https://www.linkedin.com/in/jaydenshutt/";
    public string LinkedInDisplay => "linkedin.com/in/jaydenshutt";
    public string ConnectInvitation =>
        "Knowledge matters, but the willingness to connect with others is what turns knowledge into something useful and lasting. If you would like to connect, you are welcome on LinkedIn.";
    public string AppDescription =>
        "MathMentor is a free, progressive math tutor from arithmetic foundations through calculus.";
    public string SupportMessage =>
        "MathMentor is free to use. If it has been helpful to you or someone you care about, a small gift via PayPal is a thoughtful way to say thank you. It is never required.";

    /// <summary>
    /// Optional PayPal.me URL (e.g. https://www.paypal.com/paypalme/YourName).
    /// Leave null to rely on the QR code only, the primary, respectful tip method.
    /// </summary>
    public string? PayPalUrl => null;

    public bool HasPayPalUrl => !string.IsNullOrWhiteSpace(PayPalUrl);

    [ObservableProperty]
    private BitmapImage? _payPalQrImage;

    public AboutViewModel(INavigationService nav)
    {
        _nav = nav;
        Title = "About";
        LoadQrImage();
    }

    private void LoadQrImage()
    {
        try
        {
            var uri = new Uri("pack://application:,,,/Assets/paypal-qr.png", UriKind.Absolute);
            var bmp = new BitmapImage();
            bmp.BeginInit();
            bmp.UriSource = uri;
            bmp.CacheOption = BitmapCacheOption.OnLoad;
            bmp.EndInit();
            bmp.Freeze();
            PayPalQrImage = bmp;
        }
        catch
        {
            // QR optional. About page still works without it
            PayPalQrImage = null;
        }
    }

    [RelayCommand]
    private void OpenLinkedIn() => OpenUrl(LinkedInUrl);

    [RelayCommand]
    private void OpenPayPal()
    {
        if (HasPayPalUrl)
            OpenUrl(PayPalUrl!);
    }

    [RelayCommand]
    private void BackToDashboard() => _nav.NavigateToDashboard();

    private static void OpenUrl(string url)
    {
        try
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            });
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                $"Could not open the link:\n{url}\n\n{ex.Message}",
                "MathMentor",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
        }
    }
}
