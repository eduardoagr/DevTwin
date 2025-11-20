namespace DevTwin.Interfaces {
    public interface IRegistryScanner {

        Task<IEnumerable<FileData>> GetVisualStudioInstallsAsync();

    }
}
