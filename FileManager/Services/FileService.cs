using System;
using System.Threading.Tasks;
using FileManager.DomainModel;
using FileManager.Repositories;

namespace FileManager.Services
{
    public class FileService : IFileService
    {
        private readonly IFileRepository _fileRepository;
        public FileService(IFileRepository fileRepository)
        {
            _fileRepository = fileRepository;
        }

        public async Task<bool> AddFileAsync(MyFile myFile)
        {
            return await _fileRepository.AddFileAsync(myFile);
        }

        public async Task<MyFile> GetFileAsync(Guid id)
        {
            return await _fileRepository.DownloadFileAsync(id);
        }


    }
}
