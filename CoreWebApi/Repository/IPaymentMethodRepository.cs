using CoreWebApi.DL;
using CoreWebApi.Model;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApi.Repository
{
    public interface IPaymentMethodRepository
    {
        List<PaymentMethodModel> GetAllPaymentMethod();
        Task<List<PaymentMethodModel>> GetAllPaymentMethodAsync();

        PaymentMethodModel GetPaymentMethodById(int id);
        Task<PaymentMethodModel> GetPaymentMethodByIdAsync(int id);

        int AddPaymentMethod(PaymentMethodModel paymentMethodModel);
        Task<int> AddPaymentMethodAsync(PaymentMethodModel paymentMethodModel);

        void UpdatePaymentMethod(int id, PaymentMethodModel paymentMethodModel);
        Task UpdatePaymentMethodAsync(int id, PaymentMethodModel paymentMethodModel);

        void UpdatePaymentMethodPatch(int id, JsonPatchDocument paymentMethodModel);
        Task UpdatePaymentMethodPatchAsync(int id, JsonPatchDocument paymentMethodModel);

        void DeletePaymentMethod(int id);
        Task DeletePaymentMethodAsync(int id);
    }
}
