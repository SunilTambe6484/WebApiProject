using AutoMapper;
using CoreWebApi.DL;
using CoreWebApi.Model;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApi.Repository
{
    public class PaymentMethodRepository : IPaymentMethodRepository
    {
        private readonly ECommerceDbContext _ecommerceDbContext = null; 
        private readonly IMapper _mapper = null;

        public PaymentMethodRepository(ECommerceDbContext commerceDbContext, IMapper mapper)
        {
            _ecommerceDbContext = commerceDbContext;
            _mapper = mapper;
        }

        public int AddPaymentMethod(PaymentMethodModel paymentMethodModel)
        {
            var paymentMethod = _mapper.Map<PaymentMethodModel, PaymentMethod>(paymentMethodModel);

            _ecommerceDbContext.Add(paymentMethod);
            _ecommerceDbContext.SaveChanges();

            return paymentMethod.Id;
        }

        public async Task<int> AddPaymentMethodAsync(PaymentMethodModel paymentMethodModel)
        {
            var paymentMethod = _mapper.Map<PaymentMethodModel, PaymentMethod>(paymentMethodModel);

            _ecommerceDbContext.Add(paymentMethod);
            await _ecommerceDbContext.SaveChangesAsync();

            return paymentMethod.Id;
        }

        public void DeletePaymentMethod(int id)
        {
            var paymentMethods = _ecommerceDbContext.PaymentMethods.Find(id);

            _ecommerceDbContext.PaymentMethods.Remove(paymentMethods);

            _ecommerceDbContext.SaveChanges();
        }

        public async Task DeletePaymentMethodAsync(int id)
        {
            var paymentMethods = await _ecommerceDbContext.PaymentMethods.FindAsync(id);

            _ecommerceDbContext.PaymentMethods.Remove(paymentMethods);

            await _ecommerceDbContext.SaveChangesAsync();
        }

        public List<PaymentMethodModel> GetAllPaymentMethod()
        {
            var paymentMethodsList = _ecommerceDbContext.PaymentMethods.ToList();
            return _mapper.Map<List<PaymentMethodModel>>(paymentMethodsList);
        }

        public async Task<List<PaymentMethodModel>> GetAllPaymentMethodAsync()
        {
            var paymentMethodsList = await _ecommerceDbContext.PaymentMethods.ToListAsync();
            return _mapper.Map<List<PaymentMethodModel>>(paymentMethodsList);
        }

        public PaymentMethodModel GetPaymentMethodById(int id)
        {
            var paymentMethods = _ecommerceDbContext.PaymentMethods.Find(id);
            return _mapper.Map<PaymentMethodModel>(paymentMethods);
        }

        public async Task<PaymentMethodModel> GetPaymentMethodByIdAsync(int id)
        {
            var paymentMethods = await _ecommerceDbContext.PaymentMethods.Where(a => a.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<PaymentMethodModel>(paymentMethods);
        }

        public void UpdatePaymentMethod(int id, PaymentMethodModel paymentMethodModel)
        {
            var paymentMethod = _mapper.Map<PaymentMethodModel, PaymentMethod>(paymentMethodModel);
            paymentMethod.Id = id;

            _ecommerceDbContext.Entry(paymentMethod).State = EntityState.Modified;
            _ecommerceDbContext.Entry(paymentMethod).Property(x => x.CreationDate).IsModified = false;
            _ecommerceDbContext.Entry(paymentMethod).Property(x => x.CreatedBy).IsModified = false;
            _ecommerceDbContext.SaveChanges();
        }

        public async Task UpdatePaymentMethodAsync(int id, PaymentMethodModel paymentMethodModel)
        {
            var paymentMethod = _mapper.Map<PaymentMethodModel, PaymentMethod>(paymentMethodModel);
            paymentMethod.Id = id;

            _ecommerceDbContext.Entry(paymentMethod).State = EntityState.Modified;
            _ecommerceDbContext.Entry(paymentMethod).Property(x => x.CreationDate).IsModified = false;
            _ecommerceDbContext.Entry(paymentMethod).Property(x => x.CreatedBy).IsModified = false;
            await _ecommerceDbContext.SaveChangesAsync();
        }

        public void UpdatePaymentMethodPatch(int id, JsonPatchDocument paymentMethodModel)
        {
            var paymentMethods = _ecommerceDbContext.PaymentMethods.Find(id);
            if (paymentMethods != null)
            {
                paymentMethodModel.ApplyTo(paymentMethods);
                _ecommerceDbContext.SaveChanges();
            }
        }

        public async Task UpdatePaymentMethodPatchAsync(int id, JsonPatchDocument paymentMethodModel)
        {
            var paymentMethod = await _ecommerceDbContext.PaymentMethods.FindAsync(id);
            if (paymentMethod != null)
            {
                paymentMethodModel.ApplyTo(paymentMethod);
                await _ecommerceDbContext.SaveChangesAsync();
            }
        }
    }
}
