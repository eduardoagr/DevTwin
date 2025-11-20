

namespace DevTwin.Models;

public class FileData {

    public string? DisplayName { get; set; }

    public string? InstallPath { get; set; }

    public string? ExePath { get; set; }

    public string? IconPath { get; set; }

    // Change to BitmapSource
    public BitmapSource? IconBitmap { get; set; }
}
