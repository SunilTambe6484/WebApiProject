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
    public class OrderHistoryRepository : IOrderHistoryRepository
    {
        private readonly ECommerceDbContext _ecommerceDbContext = null;
        private readonly IMapper _mapper = null;

        public OrderHistoryRepository(ECommerceDbContext commerceDbContext, IMapper mapper)
        {
            _ecommerceDbContext = commerceDbContext;
            _mapper = mapper;
        }

        public int AddOrderHistory(OrderHistoryModel orderHistoryModel)
        {
            var orderHistory = _mapper.Map<OrderHistoryModel, OrderHistory>(orderHistoryModel);

            _ecommerceDbContext.Add(orderHistory);
            _ecommerceDbContext.SaveChanges();

            return orderHistory.Id;
        }

        public async Task<int> AddOrderHistoryAsync(OrderHistoryModel orderHistoryModel)
        {
            var orderHistory = _mapper.Map<OrderHistoryModel, OrderHistory>(orderHistoryModel);

            _ecommerceDbContext.Add(orderHistory);
            await _ecommerceDbContext.SaveChangesAsync();

            return orderHistory.Id;
        }

        public void DeleteOrderHistory(int id)
        {
            var orderHistory = _ecommerceDbContext.OrderHistories.Find(id);

            _ecommerceDbContext.OrderHistories.Remove(orderHistory);

            _ecommerceDbContext.SaveChanges();
        }

        public async Task DeleteOrderHistoryAsync(int id)
        {
            var orderHistory = await _ecommerceDbContext.OrderHistories.FindAsync(id);

            _ecommerceDbContext.OrderHistories.Remove(orderHistory);

            await _ecommerceDbContext.SaveChangesAsync();
        }

        public List<OrderHistoryModel> GetAllOrderHistories()
        {
            var orderHistoryList = _ecommerceDbContext.OrderHistories.ToList();
            return _mapper.Map<List<OrderHistoryModel>>(orderHistoryList);
        }

        public async Task<List<OrderHistoryModel>> GetAllOrderHistoriesAsync()
        {
            var orderHistoryList = await _ecommerceDbContext.OrderHistories.ToListAsync();
            return _mapper.Map<List<OrderHistoryModel>>(orderHistoryList);
        }

        public OrderHistoryModel GetOrderHistoryById(int id)
        {
            var orderHistory = _ecommerceDbContext.OrderHistories.Find(id);
            return _mapper.Map<OrderHistoryModel>(orderHistory);
        }

        public async Task<OrderHistoryModel> GetOrderHistoryByIdAsync(int id)
        {
            var orderHistory = await _ecommerceDbContext.OrderHistories.Where(a => a.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<OrderHistoryModel>(orderHistory);
        }

        public void UpdateOrderHistory(int id, OrderHistoryModel orderHistoryModel)
        {
            var orderHistory = _mapper.Map<OrderHistoryModel, OrderHistory>(orderHistoryModel);
            orderHistory.Id = id;

            _ecommerceDbContext.Entry(orderHistory).State = EntityState.Modified;
            _ecommerceDbContext.SaveChanges();
        }

        public async Task UpdateOrderHistoryAsync(int id, OrderHistoryModel orderHistoryModel)
        {
            var orderHistory = _mapper.Map<OrderHistoryModel, OrderHistory>(orderHistoryModel);
            orderHistory.Id = id;

            _ecommerceDbContext.Entry(orderHistory).State = EntityState.Modified;
            await _ecommerceDbContext.SaveChangesAsync();
        }

        public void UpdateOrderHistoryPatch(int id, JsonPatchDocument orderHistoryModel)
        {
            var orderHistory = _ecommerceDbContext.OrderHistories.Find(id);
            if (orderHistory != null)
            {
                orderHistoryModel.ApplyTo(orderHistory);
                _ecommerceDbContext.SaveChanges();
            }
        }

        public async Task UpdateOrderHistoryPatchAsync(int id, JsonPatchDocument orderHistoryModel)
        {
            var orderHistory = await _ecommerceDbContext.OrderHistories.FindAsync(id);
            if (orderHistory != null)
            {
                orderHistoryModel.ApplyTo(orderHistory);
                await _ecommerceDbContext.SaveChangesAsync();
            }
        }
    }
}
