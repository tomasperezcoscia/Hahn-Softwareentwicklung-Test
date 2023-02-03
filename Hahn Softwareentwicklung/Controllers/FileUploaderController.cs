using Microsoft.AspNetCore.Mvc;

namespace Hahn_Softwareentwicklung;

[Route("api/[controller]")]
[ApiController]

public class FileUploaderController : ControllerBase
{
    private readonly IWebHostEnvironment _hostingEnvironment;
    private readonly ILogger<FileUploaderController> _logger;

    public FileUploaderController(IWebHostEnvironment hostingEnvironment, ILogger<FileUploaderController> logger)
    {
        _hostingEnvironment = hostingEnvironment;
        _logger = logger;
    }

    [HttpPost]
    public async Task<IActionResult> UploadFile(IFormFile file)
    {
        if (file == null || file.Length == 0)
        {
            _logger.LogError("File is empty or not provided");
            return BadRequest("File is empty or not provided");
        }

        string fileName = Path.GetFileName(file.FileName);
        string filePath = Path.Combine(_hostingEnvironment.WebRootPath, "files", fileName);

        try
        {
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            _logger.LogInformation($"File {fileName} uploaded successfully.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error uploading file {fileName}.");
            return StatusCode(StatusCodes.Status500InternalServerError, "Error uploading file.");
        }

        return Ok();
    }
}
