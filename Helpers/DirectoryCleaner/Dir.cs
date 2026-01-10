using System;
using System.Collections.Generic;
using System.IO;

namespace Helpers.DirectoryCleaner
{
    public static class Dir
    {
        /// <summary>
        /// Empties a directory but preserves specific filenames
        /// (e.g. ".gitignore").
        /// </summary>
        public static void Empty(
            string rootPath,
            params string[] preserveFiles)
        {
            if (!Directory.Exists(rootPath))
                return;

            var preserveSet = new HashSet<string>(
                preserveFiles,
                StringComparer.OrdinalIgnoreCase
            );

            // Delete files
            foreach (var file in Directory.GetFiles(rootPath))
            {
                var fileName = Path.GetFileName(file);
                if (preserveSet.Contains(fileName))
                    continue;

                File.Delete(file);
            }

            // Delete subdirectories
            foreach (var dir in Directory.GetDirectories(rootPath))
            {
                Directory.Delete(dir, recursive: true);
            }
        }

        /// <summary>
        /// Empties the runtime Storage directory
        /// (bin/.../Storage).
        /// </summary>
        public static void EmptyRuntimeStorage(
            params string[] preserveFiles)
        {
            var storagePath = Path.Combine(
                AppContext.BaseDirectory,
                "Storage"
            );

            Empty(storagePath, preserveFiles);
        }

        /// <summary>
        /// Empties a specific subfolder inside runtime Storage
        /// (e.g. "Vehicles", "DriversLicenses").
        /// </summary>
        public static void EmptyRuntimeStorageFolder(
            string subFolder,
            params string[] preserveFiles)
        {
            if (string.IsNullOrWhiteSpace(subFolder))
                throw new ArgumentException(
                    "Subfolder name is required.",
                    nameof(subFolder));

            var path = Path.Combine(
                AppContext.BaseDirectory,
                "Storage",
                subFolder
            );

            Empty(path, preserveFiles);
        }
    }
}
