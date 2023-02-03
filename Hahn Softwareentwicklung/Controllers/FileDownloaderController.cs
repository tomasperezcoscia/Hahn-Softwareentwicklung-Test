using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hahn_Softwareentwicklung.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileDownloaderController : ControllerBase
    {

        [HttpGet("download/{fileName}")]
        public IActionResult DownloadFile(string fileName)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Files", fileName);

            if (!System.IO.File.Exists(filePath))
            {
                return NotFound();
            }

            var fileBytes = System.IO.File.ReadAllBytes(filePath);
            return File(fileBytes, "application/octet-stream", fileName);
        }

    }
}
