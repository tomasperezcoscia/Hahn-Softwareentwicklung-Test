using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hahn_Softwareentwicklung.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploaderController : ControllerBase
    {

        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("File is empty or not found");
            }

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Files", file.FileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return Ok();
        }

    }
}
