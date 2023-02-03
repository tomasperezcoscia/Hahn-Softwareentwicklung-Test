using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hahn_Softwareentwicklung.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileDownloaderController : ControllerBase
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        public FileDownloaderController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public IActionResult DownloadFile(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                return BadRequest("File name is empty or not provided");
            }

            string filePath = Path.Combine(_hostingEnvironment.WebRootPath, "files", fileName);

            if (!System.IO.File.Exists(filePath))
            {
                return NotFound("File not found");
            }

            var memory = new MemoryStream();
            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                stream.CopyTo(memory);
            }
            memory.Position = 0;

            return File(memory, GetContentType(fileName), fileName);
        }

        private string GetContentType(string fileName)
        {
            return "application/octet-stream";
        }
    }
}
