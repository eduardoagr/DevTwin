
namespace DevTwin.Services;

public class EmulatorScanner : IEmulatorScanner {

    private readonly string _avdRoot;

    public EmulatorScanner() {

        // Path to the AVD folder
        _avdRoot = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".android", "avd");
    }

    public IEnumerable<string> GetAndroidEmulators() {

        var emulators = new List<string>();

        if(!Directory.Exists(_avdRoot)) {
            return emulators;
        }

        foreach(var item in Directory.GetFiles(_avdRoot, "*.ini")) {

            // Extract the emulator name and API level from the folder name
            var names = Path.GetFileNameWithoutExtension(item);

            emulators.Add(names);
        }

        return emulators;
    }
}
