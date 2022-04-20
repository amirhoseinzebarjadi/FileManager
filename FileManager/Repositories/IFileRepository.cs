using System;
using System.Threading.Tasks;
using FileManager.DomainModel;

namespace FileManager.Repositories
{
    public interface IFileRepository
    {
        /// <summary>
        /// بارگزاری فایل 
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        Task<bool> AddFileAsync(MyFile file);

        /// <summary>
        /// دریافت فایل
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<MyFile> DownloadFileAsync(Guid id);

    }
}
