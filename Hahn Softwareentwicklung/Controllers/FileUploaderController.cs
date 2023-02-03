using Microsoft.AspNetCore.Mvc;

/*
This code is the implementation of the "FileUploaderController" in a ASP.NET Core Web API. 
The class is marked with the [Route("api/[controller]")] and [ApiController] attributes to indicate that it is a controller in the API, and the endpoint for this controller will be "api/[controller]".
The class constructor takes in two parameters: IWebHostEnvironment and ILogger<FileUploaderController>.
IWebHostEnvironment provides information about the web hosting environment and ILogger<FileUploaderController> is used for logging purposes.
The UploadFile method is decorated with the [HttpPost] attribute, indicating that it can only be called using the HTTP POST method.
The method takes in a single parameter, IFormFile, which represents the file being uploaded.
If the file is empty or not provided, the method logs an error using the _logger instance and returns a BadRequest response with a message "File is empty or not provided".
Otherwise, the method creates a file path by combining the _hostingEnvironment.WebRootPath with the subfolder "files" and the name of the file being uploaded.
It then tries to copy the file to the specified path using a FileStream. If the file is uploaded successfully, it logs an information message using the _logger instance.
If there's an error during the file upload, it logs the error using the _logger instance and returns a StatusCode response with a status code of StatusCodes.Status500InternalServerError and a message "Error uploading file.".
If the file is uploaded successfully, it returns an Ok response.
 */

namespace Hahn_Softwareentwicklung.Controllers;

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
