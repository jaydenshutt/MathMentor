using MathMentor.Models;

namespace MathMentor.Services;

public interface ISettingsService
{
    AppSettings Settings { get; }
    void Save();
    void ApplyTheme();
    void ApplyFontScale();
    event EventHandler? SettingsChanged;
}
