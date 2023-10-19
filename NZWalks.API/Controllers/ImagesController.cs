using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.CustomActionFilters;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTOs;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageRepository imageRepository;

        public ImagesController(IImageRepository imageRepository)
        {
            this.imageRepository = imageRepository;
        }

        [HttpPost("Upload")]
        public async Task<IActionResult> Upload([FromForm] ImageUploadRequestDTO imageUploadRequestDTO)
        {
            ValidateFileUpload(imageUploadRequestDTO);
            if(ModelState.IsValid)
            {
                var imageDomainModel = new Image
                {
                    File = imageUploadRequestDTO.File,
                    FileExtension = Path.GetExtension(imageUploadRequestDTO.File.FileName),
                    FileSizeInBytes = imageUploadRequestDTO.File.Length,
                    FileName = imageUploadRequestDTO.FileName,
                };
                await imageRepository.Upload(imageDomainModel);
                return Ok(imageDomainModel);
            }
            return BadRequest(ModelState);
        }

        private void ValidateFileUpload(ImageUploadRequestDTO imageUploadRequestDTO)
        {
            var allowedExtensions = new string[] { ".jpg", ".jpeg", ".png" };
            if(allowedExtensions.Contains(Path.GetExtension(imageUploadRequestDTO.File.FileName)) == false)
            {
                ModelState.AddModelError("file", "Unsupported file extension");
            }

            if(imageUploadRequestDTO.File.Length > 10485760)
            {
                ModelState.AddModelError("file", "File size exceed 10MB, please upload a smaller file");
            }
        }
    }
}
