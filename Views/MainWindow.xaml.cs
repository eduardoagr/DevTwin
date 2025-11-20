namespace DevTwin.Views;

public sealed partial class MainWindow : Window {

    public MainWindow(MainWindowViewModel mainWindowViewModel) {

        DataContext = mainWindowViewModel;

        InitializeComponent();

        Loaded += async (sender, args) => {

            await mainWindowViewModel.LoadAsync();

        };


    }
}
