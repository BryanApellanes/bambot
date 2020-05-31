using System;
using System.IO;
using System.Linq;

namespace Bambot.Deployment
{
    public class FileSet
    {
        public static implicit operator FileSet(FileSetDescriptor descriptor)
        {
            return FromDescriptor(descriptor);
        }

        public static FileSet FromDescriptor(FileSetDescriptor descriptor)
        {
            return new FileSet
            {
                Directories = descriptor.Directories.Select(path => new DirectoryInfo(path)).ToArray(),
                Files = descriptor.Files.Select(path => new FileInfo(path)).ToArray(),
            };
        }

        public DirectoryInfo[] Directories { get; set; }
        public FileInfo[] Files { get; set; }
    }
}