
using basic_project.Authentication;
using basic_project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace basic_project.Controllers
{
    public class FilesController : Controller
    {
        
        public readonly ApplicationDbContext _context;
        public FilesController(ApplicationDbContext context)
        {
            
            _context = context;
           
        }
      

        [HttpPost]
        [Route("UploadToFileSystem")]
        public async Task<IActionResult> UploadToFileSystem([FromForm]List<IFormFile> files,[FromForm] string description)
        {
            
            var fileModel = new FileModel();
            foreach (var file in files)
            {
                var basePath = Path.Combine(Directory.GetCurrentDirectory() + "\\Uploads\\");
                bool basePathExists = System.IO.Directory.Exists(basePath);
                if (!basePathExists) Directory.CreateDirectory(basePath);
                var fileName = Path.GetFileNameWithoutExtension(file.FileName);
                var filePath = Path.Combine(basePath, file.FileName);
                var extension = Path.GetExtension(file.FileName);
                var fileProvider = new FileExtensionContentTypeProvider();

                if (!fileProvider.TryGetContentType(file.FileName, out string contentType))
                {
                    return Ok("No matching contenttype found for file " + fileName);
                }
                //only photo with png ang jpeg allowed
                if (contentType != "image/png" || contentType != "image/jpeg")
                {
                    return Ok("file type not allowed");
                }
                    if (!System.IO.File.Exists(filePath))
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        // Upload the file if less than 2 MB
                        if (file.Length < 2097152)
                        {

                            fileModel = new FileModel
                            {
                                CreatedOn = DateTime.UtcNow,
                                FileType = file.ContentType,
                                Extension = extension,
                                Name = fileName,
                                Description = description,
                                FilePath = filePath,
                                size=file.Length ,
                                mimeType = contentType,
                            };
                            _context.Add(fileModel);
                            _context.SaveChanges();
                        }
                        else
                        {
                            return Ok("File size is bigger than 2MB.");
                        }
                    }
                }
                else
                {
                    return Ok("this file already exist");
                }
            }

            return Ok(fileModel);
        }

     
    }
}
