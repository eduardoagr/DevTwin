public static class IconHelper {

    public static async Task<BitmapSource?> GetExeIconAsync(string path) {
        if(!File.Exists(path))
            return null;

        return await Task.Run(() => {
            Icon icon = Icon.ExtractAssociatedIcon(path)!;
            var bitmap = System.Windows.Interop.Imaging.CreateBitmapSourceFromHIcon(
                icon.Handle,
                Int32Rect.Empty,
                BitmapSizeOptions.FromWidthAndHeight(16, 16));

            if(bitmap.CanFreeze)
                bitmap.Freeze(); // makes it thread-safe
            return bitmap;
        });
    }
}
