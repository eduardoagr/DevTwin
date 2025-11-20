
namespace DevTwin.Services;

public class RegistryScanner : IRegistryScanner {

    public async Task<IEnumerable<FileData>> GetVisualStudioInstallsAsync() {
        var installs = new List<FileData>();

        try {
            var query = new SetupConfiguration();
            var enumerator = query.EnumInstances();
            var instances = new ISetupInstance[1];

            while(true) {
                enumerator.Next(1, instances, out var fetched);
                if(fetched == 0)
                    break;

                var instance = instances[0];
                var path = instance.GetInstallationPath();
                var displayName = instance.GetDisplayName();

                if(!string.IsNullOrEmpty(path) && Directory.Exists(path)) {
                    string? exePath = Path.Combine(path, "Common7", "IDE", "devenv.exe");

                    BitmapSource? bitmapSource = null;
                    if(File.Exists(exePath)) {
                        bitmapSource = await IconHelper.GetExeIconAsync(exePath);
                    }

                    installs.Add(new FileData {
                        DisplayName = displayName,
                        InstallPath = path,
                        IconPath = exePath,
                        IconBitmap = bitmapSource,
                        ExePath = exePath,
                    });
                }
            }
        } catch(Exception ex) {
            Debug.WriteLine($"SetupConfiguration failed: {ex.Message}");
        }

        // 2. Fallback: Registry + File scan (VS 2010–2015 or COM failure)

        if(installs.Count == 0) {
            installs.AddRange(await FallbackScanner.ScanRegistryAndPaths());
        }

        return installs;
    }
}
