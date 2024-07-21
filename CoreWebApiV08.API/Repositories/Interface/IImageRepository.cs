using CoreWebApiV08.API.Models.Classes;

namespace CoreWebApiV08.API.Repositories.Interface
{
    public interface IImageRepository
    {
        Task<Images> Upload(Images image);
    }
}
