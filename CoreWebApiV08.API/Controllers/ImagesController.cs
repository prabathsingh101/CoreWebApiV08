using CoreWebApiV08.API.Models.Classes;
using CoreWebApiV08.API.Models.DTO.Image;
using CoreWebApiV08.API.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreWebApiV08.API.Controllers
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

        //HTTP POST:/api/Images/Upload
        [HttpPost]
        [Route("Upload")]
        [Produces("application/json")]
        public async Task<IActionResult> Upload([FromForm] ImageUploadRequestDto request)
        {
            ValidateFileUpload(request);

            if (ModelState.IsValid)
            {
                //convert dto to domain model

                var imageDomainModel = new Images
                {
                    file = request.file,
                    fileextension = Path.GetExtension(request.file.FileName),
                    filesizebytes = request.file.Length,
                    filename = request.filename,
                    filedescription = request.filedescription,
                    registrationno = request.registrationno,    
                };

                //user repository to upload image
                await imageRepository.Upload(imageDomainModel);
                return Ok(imageDomainModel);

            }
            return BadRequest(ModelState);
        }
        private void ValidateFileUpload(ImageUploadRequestDto request)
        {
            var allowedExtensions = new string[] { ".jpg", ".jpeg", ".png" };

            if (!allowedExtensions.Contains(Path.GetExtension(request.file.FileName)))
            {
                ModelState.AddModelError("file", "Unsupported file extension");
            }

            if (request.file.Length > 10485760)
            {
                ModelState.AddModelError("file", "file size is more than 10MB, please upload a smaller size");
            }
        }
    }
}
