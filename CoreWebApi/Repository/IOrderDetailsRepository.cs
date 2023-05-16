using CoreWebApi.DL;
using CoreWebApi.Model;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApi.Repository
{
    public interface IOrderDetailsRepository
    {
        List<OrderDetailsModel> GetAllOrderDetails();
        Task<List<OrderDetailsModel>> GetAllOrderDetailsAsync();

        OrderDetailsModel GetOrderDetailsById(int id);
        Task<OrderDetailsModel> GetOrderDetailsByIdAsync(int id);

        int AddOrderDetails(OrderDetailsModel orderDetailsModel);
        Task<int> AddOrderDetailsAsync(OrderDetailsModel orderDetailsModel);

        void UpdateOrderDetails(int id, OrderDetailsModel orderDetailsModel);
        Task UpdateOrderDetailsAsync(int id, OrderDetailsModel orderDetailsModel);

        void UpdateOrderDetailsPatch(int id, JsonPatchDocument orderDetailsModel);
        Task UpdateOrderDetailsPatchAsync(int id, JsonPatchDocument orderDetailsModel);

        void DeleteOrderDetails(int id);
        Task DeleteOrderDetailsAsync(int id);
    }
}
