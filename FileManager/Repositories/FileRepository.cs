using System;
using System.Threading.Tasks;
using FileManager.Context;
using FileManager.DomainModel;
using Microsoft.EntityFrameworkCore;

namespace FileManager.Repositories
{
    public class FileRepository : BaseRepository, IFileRepository
    {
        public FileRepository(AppDbContext context) : base(context) { }

        public async Task<bool> AddFileAsync(MyFile file)
        {
            await _context.AddAsync(file);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<MyFile> DownloadFileAsync(Guid id)
        {
            return await _context.Files.FirstOrDefaultAsync(q => q.Id == id);
        }

    }
}
