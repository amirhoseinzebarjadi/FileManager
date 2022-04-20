using System;
using System.ComponentModel.DataAnnotations;

namespace FileManager.DomainModel
{
    public class MyFile
    { 
        [Key]
        public Guid Id { get; set; }

        public string Path { get; set; }

        public string Name { get; set; }
    }
}
