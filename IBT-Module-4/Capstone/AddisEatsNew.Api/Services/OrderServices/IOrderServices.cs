using AddisEatsNew.Api.DTOs;
using AddisEatsNew.Api.Models;
using AddisEatsNew.Api.Common;
namespace AddisEatsNew.Api.Services.OrderServices
{
    public interface IOrderServices
    {
        Order? GetById(int id);
       Result<Order> CreateOrder(CreateOrderDTO createDTO);
    }
}
