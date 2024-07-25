using CoreWebApiV08.API.Models.Course;
using CoreWebApiV08.API.Models.FeesHead;

namespace CoreWebApiV08.API.Repositories.Interface
{
    public interface IFeesHead
    {
        Task<List<FeesHeadModel>> GetAllAsync();

        Task<FeesHeadModel?> GetByIdAsync(int id);

        Task<FeesHeadModel> CreateAsync(FeesHeadModel model);

        Task<FeesHeadModel> UpdateAsync(int id, FeesHeadModel model);

        Task<FeesHeadModel?> DeleteAsync(int id);
    }
}
