using AddisEatsNew.Api.DTOs;
using AddisEatsNew.Api.Models;
namespace AddisEatsNew.Api.Services.OrderServices
{
    public interface IOrderServices
    {
        Order? GetById(int id);
        Order CreateOrder(CreateOrderDTO createDTO);
    }
}
