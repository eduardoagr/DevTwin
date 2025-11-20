namespace DevTwin.Helpers;

public static class GenerateBat {

    public static void GenerateLaunchBat(string vsExePath, string emulatorName, string launcherName) {

        var fileName = launcherName;

        if(string.IsNullOrEmpty(fileName)) {

            fileName = launcherName;
        }

        // Resolve emulator.exe path
        var sdkRoot = Environment.GetEnvironmentVariable("ANDROID_SDK_ROOT")
                   ?? Environment.GetEnvironmentVariable("ANDROID_HOME")
                   ?? Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Android", "Sdk");

        var emulatorExe = Path.Combine(sdkRoot, "emulator", "emulator.exe");

        if(!File.Exists(vsExePath))
            throw new FileNotFoundException("Visual Studio not found", vsExePath);

        if(!File.Exists(emulatorExe))
            throw new FileNotFoundException("emulator.exe not found", emulatorExe);

        var batContent = $@"@echo off
start ""Visual Studio"" ""{vsExePath}""
start ""Android Emulator"" /B ""{emulatorExe}"" @{emulatorName} >nul 2>&1
";

        // Open SaveFileDialog
        var dialog = new SaveFileDialog {
            Title = "Save Launcher Script",
            Filter = "Batch File (*.bat)|*.bat",
            FileName = $"{fileName}.bat",
            DefaultExt = ".bat"
        };

        if(dialog.ShowDialog() == true) {
            File.WriteAllText(dialog.FileName, batContent);
        }
    }
}
