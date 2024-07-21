using CoreWebApiV08.API.Data;
using CoreWebApiV08.API.Models.Classes;
using CoreWebApiV08.API.Repositories.Interface;

namespace CoreWebApiV08.API.Repositories.Implementation
{
    public class LocalImageRepository : IImageRepository
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly DatabaseContext dbContext;

        public LocalImageRepository(
            IWebHostEnvironment webHostEnvironment,
            IHttpContextAccessor httpContextAccessor,
            DatabaseContext dbContext)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.httpContextAccessor = httpContextAccessor;
            this.dbContext = dbContext;
        }
        public async Task<Images> Upload(Images image)
        {
            var localFilePath = Path.Combine(webHostEnvironment.ContentRootPath, "StudentImage",
              $"{image.filename}{image.fileextension}");

            //upload image to local path

            using var stream = new FileStream(localFilePath, FileMode.Create);
            await image.file.CopyToAsync(stream);

            // https://localhost:1234/Images/image.jpg

            var urlFilePath = $"{httpContextAccessor.HttpContext.Request.Scheme}://{httpContextAccessor.HttpContext.Request.Host}{httpContextAccessor.HttpContext.Request.PathBase}/StudentImage/{image.filename}{image.fileextension}";

            image.filepath = urlFilePath;

            //Add the image into image table
            await dbContext.TblStudentDocs.AddAsync(image);
            await dbContext.SaveChangesAsync();
            return image;
        }
    }
}
