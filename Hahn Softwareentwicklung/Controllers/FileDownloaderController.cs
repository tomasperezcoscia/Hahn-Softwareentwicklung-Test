/*
 This code implements the FileDownloaderController in the Hahn_Softwareentwicklung.Controllers namespace.
It defines an endpoint for downloading files, accessible through the /api/filedownloader route.
The controller accepts the name of the file to be downloaded as a parameter in the GET request.
The file's location is determined by combining the web root path with a subdirectory named "files" and the file name.
The code checks if the file exists, and if it does, it loads the file into memory and returns it as a binary stream in the response.
The content type of the file is set to "application/octet-stream".
 */


using Hahn_Softwareentwicklung.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Hahn_Softwareentwicklung.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileDownloaderController : ControllerBase
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly ILogger<FileDownloaderController> _logger;
        private readonly FileContext _context;

        public FileDownloaderController(IWebHostEnvironment hostingEnvironment, ILogger<FileDownloaderController> logger, FileContext context)
        {
            _hostingEnvironment = hostingEnvironment;
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IActionResult DownloadFile(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                _logger.LogError("File name is empty or not provided");
                return BadRequest("File name is empty or not provided");
            }

            string filePath = Path.Combine(_hostingEnvironment.WebRootPath, "files", fileName);

            if (!System.IO.File.Exists(filePath))
            {
                _logger.LogError($"File {fileName} not found");
                return NotFound("File not found");
            }
            else
            {
                // Agrego informacion de descarga y carga de datos
                _context.Files.Add(new FileTrafic
                {
                    FileName = fileName,
                    UploadTime = DateTime.Now,
                    UploadedBy = "Username",
                    isUpload = true,
                });
                _context.SaveChangesAsync();
            }

            var memory = new MemoryStream();
            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                stream.CopyTo(memory);
            }
            memory.Position = 0;

            _logger.LogInformation($"File {fileName} downloaded successfully.");

            return File(memory, GetContentType(fileName), fileName);
        }

        private string GetContentType(string fileName)
        {
            return "application/octet-stream";
        }
    }
}