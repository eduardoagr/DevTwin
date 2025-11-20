namespace DevTwin.Helpers; 
public class FallbackScanner {

    public static async Task<IEnumerable<FileData>> ScanRegistryAndPaths() {

        var installs = new List<FileData>();
        installs.AddRange(await ScanSxSRegistry());
        installs.AddRange(await ScanInstallFolders());

        return installs;
    }

    private static async Task<IEnumerable<FileData>> ScanInstallFolders() {

        var results = new List<FileData>();
        foreach(var root in VisualStudioConstants.InstallRoots) {
            if(!Directory.Exists(root))
                continue;

            foreach(var yearDir in Directory.GetDirectories(root)) {

                foreach(var editionDir in Directory.GetDirectories(yearDir)) {

                    var devenv = Path.Combine(editionDir, VisualStudioConstants.DevenvRelativePath);

                    if(File.Exists(devenv)) {

                        results.Add(new FileData {
                            DisplayName = $"Visual Studio {VisualStudioConstants.MapVersionToYear(Path.GetFileName(yearDir))}" +
                            $" {Path.GetFileName(editionDir)}",
                            InstallPath = editionDir,
                            IconPath = devenv,
                            IconBitmap = await IconHelper.GetExeIconAsync(devenv),
                            ExePath = devenv,
                        });
                    }
                }
            }
        }
        return results;
    }



    private static async Task<IEnumerable<FileData>> ScanSxSRegistry() {

        var results = new List<FileData>();

        try {

            var key = Registry.LocalMachine.OpenSubKey(VisualStudioConstants.SxSRegistryKey);
            if(key is not null) {

                foreach(var version in key.GetValueNames()) {

                    var path = key.GetValue(version)?.ToString();
                    var deven = Path.Combine(path!, VisualStudioConstants.DevenvRelativePath);

                    if(File.Exists(deven)) {

                        var mappedYear = VisualStudioConstants.MapVersionToYear(version);
                        var edition = Path.GetFileName(Path.GetDirectoryName(path!));



                        results.Add(new FileData {

                            DisplayName = $"Visual Studio {mappedYear} {edition}",
                            InstallPath = path,
                            IconPath = deven,
                            IconBitmap = await IconHelper.GetExeIconAsync(deven),
                            ExePath = deven,

                        });
                    }
                }
            }

        } catch(Exception ex) {

            Debug.WriteLine($"SxS registry scan failed: {ex.Message}");
        }

        return results;
    }
}
