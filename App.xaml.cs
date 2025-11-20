

namespace DevTwin;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application {

    public static IServiceProvider Services { get; private set; }

    public App() {
        var services = new ServiceCollection();

        ConfigureServices(services);

        Services = services.BuildServiceProvider();
    }

    private static void ConfigureServices(IServiceCollection services) {

        // Register services
        services.AddSingleton<IRegistryScanner, RegistryScanner>();
        services.AddSingleton<IEmulatorScanner, EmulatorScanner>();

        // Register ViewModels
        services.AddSingleton<MainWindowViewModel>();

        // Register MainWindow
        services.AddSingleton<MainWindow>();
    }

    protected override void OnStartup(StartupEventArgs e) {
        base.OnStartup(e);

        var mainWindow = Services.GetRequiredService<MainWindow>();
        mainWindow.Show();
    }
}
