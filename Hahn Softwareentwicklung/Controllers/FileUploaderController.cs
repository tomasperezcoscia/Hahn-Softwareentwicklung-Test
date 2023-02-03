using Microsoft.AspNetCore.Mvc;

namespace Hahn_Softwareentwicklung;

[Route("api/[controller]")]
[ApiController]

public class FileUploaderController : ControllerBase
{
    private readonly IWebHostEnvironment _hostingEnvironment;

    public FileUploaderController(IWebHostEnvironment hostingEnvironment)
    {
        _hostingEnvironment = hostingEnvironment;
    }

    [HttpPost]
    public async Task<IActionResult> UploadFile(IFormFile file)
    {
        if (file == null || file.Length == 0)
        {
            return BadRequest("File is empty or not provided");
        }

        string fileName = Path.GetFileName(file.FileName);
        string filePath = Path.Combine(_hostingEnvironment.WebRootPath, "files", fileName);

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        return Ok();
    }
}
