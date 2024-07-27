using CoreWebApiV08.API.Models.Course;
using CoreWebApiV08.API.Models.FeesHead;

namespace CoreWebApiV08.API.Repositories.Interface
{
    public interface IPayment
    {
        Task<List<PaymentModels>> GetAllAsync();

        Task<PaymentModels?> GetByIdAsync(int id);

        Task<PaymentModels> CreateAsync(PaymentModels model);

        Task<PaymentModels> UpdateAsync(int id, PaymentModels model);

        Task<PaymentModels?> DeleteAsync(int id);
    }
}
