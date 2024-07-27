using CoreWebApiV08.API.Data;
using CoreWebApiV08.API.Models.FeesHead;
using CoreWebApiV08.API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace CoreWebApiV08.API.Repositories.Implementation
{
    public class SQLPayment : IPayment
    {
        private readonly DatabaseContext databaseContext;

        public SQLPayment(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
        public async Task<PaymentModels> CreateAsync(PaymentModels model)
        {
            await databaseContext.TblPayments.AddAsync(model);
            await databaseContext.SaveChangesAsync();
            return model;
        }

        public async Task<PaymentModels?> DeleteAsync(int id)
        {
            var isexists = await databaseContext.TblPayments.FirstOrDefaultAsync(x => x.id == id);

            if (isexists == null)
            {
                return null;
            }
            databaseContext.TblPayments.Remove(isexists);
            databaseContext.SaveChanges();
            return isexists;
        }

        public async Task<List<PaymentModels>> GetAllAsync()
        {
            return await databaseContext.TblPayments.ToListAsync();
        }

        public async Task<PaymentModels?> GetByIdAsync(int id)
        {
            return await databaseContext.TblPayments.FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task<PaymentModels> UpdateAsync(int id, PaymentModels model)
        {
            var isexists = await databaseContext.TblPayments.FirstOrDefaultAsync(x => x.id == id);

            if (isexists == null)
            {
                return null;
            }

            isexists.duration = model.duration;

            isexists.collectiondate = model.collectiondate;

            isexists.paymenttype = model.paymenttype;

            isexists.invoiceno = model.invoiceno;

            isexists.status = model.status;

            isexists.admissionfees = model.admissionfees;

            isexists.discount = model.discount;

            isexists.discountamount = model.discountamount;

            isexists.finalamount = model.finalamount;

            isexists.description = model.description;

            isexists.islocked = model.islocked;

            isexists.isstatus = model.isstatus;

            isexists.isdeleted = model.isdeleted;

            isexists.updateddate = model.updateddate;  
            
            isexists.studentid = model.studentid;

            isexists.classid = model.classid;

            await databaseContext.SaveChangesAsync();

            return isexists;
        }
    }
}
