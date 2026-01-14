namespace VRMS.Helpers;

public static class FileStorageHelper
{
    private static readonly string StorageRoot =
        Path.Combine(AppContext.BaseDirectory, "Storage");

    public static string SaveSingleFile(
        Stream fileStream,
        string originalFileName,
        string relativeDirectory,
        string fileNameWithoutExtension,
        bool clearDirectoryFirst = false
    )
    {
        if (fileStream.CanSeek)
            fileStream.Position = 0;

        var extension = Path.GetExtension(originalFileName);
        if (string.IsNullOrWhiteSpace(extension))
            throw new InvalidOperationException(
                "Invalid file extension.");

        var fullDirectory =
            Path.Combine(StorageRoot, relativeDirectory);

        Directory.CreateDirectory(fullDirectory);

        if (clearDirectoryFirst)
        {
            foreach (var file in Directory.GetFiles(fullDirectory))
                File.Delete(file);
        }

        var relativePath = Path.Combine(
            relativeDirectory,
            $"{fileNameWithoutExtension}{extension}");

        var fullPath =
            Path.Combine(StorageRoot, relativePath);

        using var fs =
            new FileStream(fullPath, FileMode.Create, FileAccess.Write);

        fileStream.CopyTo(fs);

        return relativePath;
    }

    public static string SaveWithGeneratedName(
        Stream fileStream,
        string originalFileName,
        string relativeDirectory
    )
    {
        if (fileStream.CanSeek)
            fileStream.Position = 0;

        var extension = Path.GetExtension(originalFileName);
        if (string.IsNullOrWhiteSpace(extension))
            throw new InvalidOperationException(
                "Invalid file extension.");

        Directory.CreateDirectory(
            Path.Combine(StorageRoot, relativeDirectory));

        var fileName =
            $"{Guid.NewGuid()}{extension}";

        var relativePath =
            Path.Combine(relativeDirectory, fileName);

        var fullPath =
            Path.Combine(StorageRoot, relativePath);

        using var fs =
            new FileStream(fullPath, FileMode.Create, FileAccess.Write);

        fileStream.CopyTo(fs);

        return relativePath;
    }

    public static void DeleteDirectory(string relativeDirectory)
    {
        var fullPath =
            Path.Combine(StorageRoot, relativeDirectory);

        if (Directory.Exists(fullPath))
            Directory.Delete(fullPath, true);
    }

    public static void DeleteFile(string relativePath)
    {
        var fullPath =
            Path.Combine(StorageRoot, relativePath);

        if (File.Exists(fullPath))
            File.Delete(fullPath);
    }
}
