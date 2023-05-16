using CoreWebApi.DL;
using CoreWebApi.Model;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApi.Repository
{
    public interface IOrderHistoryRepository
    {
        List<OrderHistoryModel> GetAllOrderHistories();
        Task<List<OrderHistoryModel>> GetAllOrderHistoriesAsync();

        OrderHistoryModel GetOrderHistoryById(int id);
        Task<OrderHistoryModel> GetOrderHistoryByIdAsync(int id);

        int AddOrderHistory(OrderHistoryModel orderHistoryModel);
        Task<int> AddOrderHistoryAsync(OrderHistoryModel orderHistoryModel);

        void UpdateOrderHistory(int id, OrderHistoryModel orderHistoryModel);
        Task UpdateOrderHistoryAsync(int id, OrderHistoryModel orderHistoryModel);

        void UpdateOrderHistoryPatch(int id, JsonPatchDocument orderHistoryModel);
        Task UpdateOrderHistoryPatchAsync(int id, JsonPatchDocument orderHistoryModel);

        void DeleteOrderHistory(int id);
        Task DeleteOrderHistoryAsync(int id);
    }
}
