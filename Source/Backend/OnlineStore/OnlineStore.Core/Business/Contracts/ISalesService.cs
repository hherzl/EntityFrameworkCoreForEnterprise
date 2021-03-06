﻿using System;
using System.Threading.Tasks;
using OnlineStore.Core.Business.Requests;
using OnlineStore.Core.Business.Responses;
using OnlineStore.Core.Domain.Dbo;
using OnlineStore.Core.Domain.Sales;

namespace OnlineStore.Core.Business.Contracts
{
    public interface ISalesService : IService
    {
        Task<IPagedResponse<Customer>> GetCustomersAsync(int pageSize = 10, int pageNumber = 1);

        Task<IPagedResponse<Shipper>> GetShippersAsync(int pageSize = 10, int pageNumber = 1);

        Task<IPagedResponse<Currency>> GetCurrenciesAsync(int pageSize = 10, int pageNumber = 1);

        Task<IPagedResponse<PaymentMethod>> GetPaymentMethodsAsync(int pageSize = 10, int pageNumber = 1);

        Task<IPagedResponse<OrderInfo>> GetOrdersAsync(int? pageSize, int? pageNumber, short? orderStatusID, int? customerID, int? employeeID, int? shipperID, string currencyID, Guid? paymentMethodID);

        Task<ISingleResponse<OrderHeader>> GetOrderAsync(long id);

        Task<ISingleResponse<CreateOrderRequest>> GetCreateOrderRequestAsync();

        Task<ISingleResponse<OrderHeader>> CreateOrderAsync(OrderHeader header, OrderDetail[] details);

        Task<ISingleResponse<OrderHeader>> CloneOrderAsync(long id);

        Task<IResponse> CancelOrderAsync(long id);
    }
}
