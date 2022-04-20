using System;
using System.Threading.Tasks;
using FileManager.Commands;
using FileManager.DomainModel;

namespace FileManager.Services
{
    public interface IFileService
    {
        /// <summary>
        /// بارگزاری فایل 
        /// </summary>
        /// <returns></returns>
        Task<bool> AddFileAsync(MyFile myFile);

        /// <summary>
        /// یافتن فایل مورد نظر برای دانلود
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<MyFile> GetFileAsync(Guid id);
        
    }
}