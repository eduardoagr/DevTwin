🍕 Buy Me a Pizza
If this saved you time or frustration, consider buying me a slice 🍕

<a href="https://www.buymeacoffee.com/EdGomez" target="_blank"><img src="https://cdn.buymeacoffee.com/buttons/v2/default-yellow.png" alt="Buy Me A Coffee" style="height: 60px !important;width: 217px !important;" ></a>


🖥️ Mini WPF Launcher App
This is a lightweight WPF utility that launches Visual Studio and your preferred Android Emulator together — perfect for developers who want to skip the boot-time hassle and jump straight into testing.

⚙️ What It Does
- Launches Visual Studio from a user-defined path
- Launches a specific Android Emulator AVD
- Silently suppresses emulator logs
- Supports optional scaling and window sizing
- Saves the launcher as a .bat file via SaveFileDialog
- Built for speed, simplicity, and automation

📦 Why I Built It
Sometimes we just want to test something quickly on an emulator — but they take forever to boot. This tool eliminates friction by launching everything in one click, with no terminal noise and optional window scaling.

🧪 How It Works
start ""Visual Studio"" "C:\Path\To\devenv.exe"
start ""Android Emulator"" /B "C:\Path\To\emulator.exe" @Pixel_8_Pro -scale 0.75 -window-size 720,1280 >nul 2>&1


This command is generated and saved via a WPF interface, allowing users to choose where to store the .bat file.
