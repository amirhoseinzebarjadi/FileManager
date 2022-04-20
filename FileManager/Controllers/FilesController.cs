using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Threading.Tasks;
using FileManager.Commands;
using FileManager.DomainModel;
using FileManager.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FileManager.Controllers
{
    [Route("api/[Controller]")]
    public class FilesController : ControllerBase
    {
        private readonly IFileService _folderService;

        public FilesController(IFileService folderService)
        {
            _folderService = folderService;
        }

        /// <summary>
        /// بارگزاری فایل 
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost("Upload")]
        public async Task<IActionResult> AddFileAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest(new { Message = "ایراد در بارگزاری فایل.مجدد بارگزاری نمایید." });


            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", Guid.NewGuid()+ "_" + file.FileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var responseId = Guid.NewGuid();

            var myFile = new MyFile
            {
                Id = responseId,
                Name = file.FileName,
                Path = path,
            };

            var result = await _folderService.AddFileAsync(myFile);

            return Ok(new { Message = "با موفقیت انجام شد", FileId = responseId, Result = result });
        }


        /// <summary>
        /// دانلود فایل
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpGet("Download")]
        public async Task<IActionResult> DawnloadFileAsync([FromBody] DownloadFileCommand command)
        {
            if (command.Id.ToString().Length == 0)
                return BadRequest(new { Message = "شناسه وارد نشده است." });

            var file = await _folderService.GetFileAsync(command.Id);

            var memory = new MemoryStream();

            using (var stream = new FileStream(file.Path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }

            memory.Position = 0;

            return File(memory, GetContentType(file.Path), Path.GetFileName(file.Path));
        }

        #region PrivateMethod
        private string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }

        private Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"}
            };
        }

        #endregion
    }
}