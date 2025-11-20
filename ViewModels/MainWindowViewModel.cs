namespace DevTwin.ViewModels;

public partial class MainWindowViewModel(IRegistryScanner scanner, IEmulatorScanner emulatorScanner) : ObservableObject {

    [ObservableProperty]
    public partial string LauncherName { get; set; } = "DevTwin";

    [ObservableProperty]
    public partial List<string> AndroidEmulators { get; set; } = new List<string>();

    [ObservableProperty]
    public partial List<FileData> VisualStudioFiles { get; set; } = new List<FileData>();

    [ObservableProperty]
    public partial Visibility EmulatorsGridVisibility { get; set; } = Visibility.Hidden;

    [ObservableProperty]
    public partial Visibility GenerateBatGridVisibility { get; set; } = Visibility.Hidden;

    [ObservableProperty]
    public partial FileData? SelectedVisualStudioFile { get; set; }

    [ObservableProperty]
    public partial string? SelectedAndroidFile { get; set; }

    public async Task LoadAsync() {
        var installs = await scanner.GetVisualStudioInstallsAsync();
        VisualStudioFiles = [.. installs];

        var Emulators = emulatorScanner.GetAndroidEmulators();
        AndroidEmulators = [.. Emulators];
    }

    partial void OnSelectedVisualStudioFileChanged(FileData? value) {
        if(value is not null) {

            EmulatorsGridVisibility = Visibility.Visible;

            emulatorScanner.GetAndroidEmulators();
        }
    }

    partial void OnSelectedAndroidFileChanged(string? value) {

        if(value is not null) {
            GenerateBatGridVisibility = Visibility.Visible;
        }
    }

    [RelayCommand]
    void Generate() {
        GenerateBat.GenerateLaunchBat(SelectedVisualStudioFile?.ExePath!, SelectedAndroidFile!, LauncherName);

        Environment.Exit(0);
    }
}
