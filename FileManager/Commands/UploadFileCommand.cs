using System;

namespace FileManager.Commands
{
    public class UploadFileCommand
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Path { get; set; }
    }
}
