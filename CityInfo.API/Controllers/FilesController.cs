namespace CityInfo.API.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.StaticFiles;

    [ApiController]
    [Route("api/files")]
    public class FilesController : ControllerBase
    {
        private readonly FileExtensionContentTypeProvider _fileExtensionContentTypeProvider;

        public FilesController(FileExtensionContentTypeProvider fileExtensionContentTypeProvider)
        {
            _fileExtensionContentTypeProvider =
                fileExtensionContentTypeProvider ?? throw new System.ArgumentNullException(nameof(fileExtensionContentTypeProvider));
        }

        [HttpGet("{fileId}")]
        public ActionResult GetFile(string fileId)
        {
            var pathToFile = "oldfile.pdf";
            if (!System.IO.File.Exists(pathToFile))
            {
                return this.NotFound();
            }

            if (!_fileExtensionContentTypeProvider.TryGetContentType(pathToFile, out string contentType))
            {
                contentType = "application/octet-stream";
            }

            var bytes = System.IO.File.ReadAllBytes(pathToFile);
            return File(bytes, contentType, Path.GetFileName(pathToFile));
        }

        [HttpPost]
        public ActionResult UploadFile(IFormFile file)
        {
            // Check if the file is null or empty
            if (file == null || file.Length == 0)
            {
                // Return a bad request response if the file is not valid
                return BadRequest("File cannot be null or empty.");
            }

            // Validate the file size (e.g., maximum 5 MB)
            const long maxFileSize = 5 * 1024 * 1024; // 5 MB
            if (file.Length > maxFileSize)
            {
                // Return a bad request response if the file size exceeds the maximum limit
                return BadRequest($"File size cannot exceed {maxFileSize / (1024 * 1024)} MB.");
            }

            // Validate the file extension/type
            var allowedExtensions = new List<string> {".pdf"};
            // var allowedExtensions = new List<string> {".jpg", ".jpeg", ".png", ".pdf"};
            var fileExtension = Path.GetExtension(file.FileName).ToLowerInvariant();
            if (!allowedExtensions.Contains(fileExtension))
            {
                // Return a bad request response if the file extension/type is not allowed
                return BadRequest("File type is not allowed.");
            }

            // At this point, the file validation has passed. Proceed with saving the file.
// You can specify the path where you want to save the uploaded file
            var filePath = Path.Combine("uploads", file.FileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                // Copy the file data to the specified path
                file.CopyTo(stream);
            }

            // Return a success response
            return Ok("File uploaded successfully.");
        }
    }
}