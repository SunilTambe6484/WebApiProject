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
    public class OrderDetailsRepository : IOrderDetailsRepository
    {
        private readonly ECommerceDbContext _ecommerceDbContext = null;
        private readonly IMapper _mapper = null;

        public OrderDetailsRepository(ECommerceDbContext commerceDbContext, IMapper mapper)
        {
            _ecommerceDbContext = commerceDbContext;
            _mapper = mapper;
        }

        public int AddOrderDetails(OrderDetailsModel orderDetailsModel)
        {
            var orderDetails = _mapper.Map<OrderDetailsModel, OrderDetails>(orderDetailsModel);

            _ecommerceDbContext.Add(orderDetails);
            _ecommerceDbContext.SaveChanges();

            return orderDetails.Id;
        }

        public async Task<int> AddOrderDetailsAsync(OrderDetailsModel orderDetailsModel)
        {
            var orderDetails = _mapper.Map<OrderDetailsModel, OrderDetails>(orderDetailsModel);

            _ecommerceDbContext.Add(orderDetails);
            await _ecommerceDbContext.SaveChangesAsync();

            return orderDetails.Id;
        }

        public void DeleteOrderDetails(int id)
        {
            var orderDetails = _ecommerceDbContext.OrderDetails.Find(id);

            _ecommerceDbContext.OrderDetails.Remove(orderDetails);

            _ecommerceDbContext.SaveChanges();
        }

        public async Task DeleteOrderDetailsAsync(int id)
        {
            var orderDetails = await _ecommerceDbContext.OrderDetails.FindAsync(id);

            _ecommerceDbContext.OrderDetails.Remove(orderDetails);

            await _ecommerceDbContext.SaveChangesAsync();
        }

        public List<OrderDetailsModel> GetAllOrderDetails()
        {
            var orderDetailsList = _ecommerceDbContext.OrderDetails.ToList();
            return _mapper.Map<List<OrderDetailsModel>>(orderDetailsList);
        }

        public async Task<List<OrderDetailsModel>> GetAllOrderDetailsAsync()
        {
            var OrderDetailsList = await _ecommerceDbContext.OrderDetails.ToListAsync();
            return _mapper.Map<List<OrderDetailsModel>>(OrderDetailsList);
        }

        public OrderDetailsModel GetOrderDetailsById(int id)
        {
            var orderDetails = _ecommerceDbContext.OrderDetails.Find(id);
            return _mapper.Map<OrderDetailsModel>(orderDetails);
        }

        public async Task<OrderDetailsModel> GetOrderDetailsByIdAsync(int id)
        {
            var orderDetails = await _ecommerceDbContext.OrderDetails.Where(a => a.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<OrderDetailsModel>(orderDetails);
        }

        public void UpdateOrderDetails(int id, OrderDetailsModel orderDetailsModel)
        {
            var orderDetails = _mapper.Map<OrderDetailsModel, OrderDetails>(orderDetailsModel);
            orderDetails.Id = id;

            _ecommerceDbContext.Entry(orderDetails).State = EntityState.Modified;
            _ecommerceDbContext.SaveChanges();
        }

        public async Task UpdateOrderDetailsAsync(int id, OrderDetailsModel orderDetailsModel)
        {
            var orderDetails = _mapper.Map<OrderDetailsModel, OrderDetails>(orderDetailsModel);
            orderDetails.Id = id;

            _ecommerceDbContext.Entry(orderDetails).State = EntityState.Modified;
            await _ecommerceDbContext.SaveChangesAsync();
        }

        public void UpdateOrderDetailsPatch(int id, JsonPatchDocument orderDetailsModel)
        {
            var orderDetails = _ecommerceDbContext.OrderDetails.Find(id);
            if (orderDetails != null)
            {
                orderDetailsModel.ApplyTo(orderDetails);
                _ecommerceDbContext.SaveChanges();
            }
        }

        public async Task UpdateOrderDetailsPatchAsync(int id, JsonPatchDocument orderDetailsModel)
        {
            var orderDetails = await _ecommerceDbContext.OrderDetails.FindAsync(id);
            if (orderDetails != null)
            {
                orderDetailsModel.ApplyTo(orderDetails);
                await _ecommerceDbContext.SaveChangesAsync();
            }
        }
    }
}
