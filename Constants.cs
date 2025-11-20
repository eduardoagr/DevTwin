namespace DevTwin {
    public static class VisualStudioConstants {

        public const string SxSRegistryKey = @"SOFTWARE\Microsoft\VisualStudio\SxS\VS7";

        public static readonly string[] InstallRoots =
        {
            @"C:\Program VisualStudioFiles\Microsoft Visual Studio",
            @"C:\Program VisualStudioFiles (x86)\Microsoft Visual Studio"
        };

        public const string DevenvRelativePath = @"Common7\IDE\devenv.exe";

        public static string MapVersionToYear(string version) {

            return version switch {
                "10" => "2010",
                "11" => "2012",
                "12" => "2013",
                "14" => "2015",
                "15" => "2017",
                "16" => "2019",
                "17" => "2022",
                "18" => "2026",
                _ => version
            };
        }
    }
}
