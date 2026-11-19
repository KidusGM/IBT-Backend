using AddisEatsNew.Api.Models;
using Microsoft.AspNetCore.Mvc;
namespace AddisEatsNew.Api.Services.MenuItemServices
{
    public interface IMenuItemServices
    {
        List<MenuItem> GetAll(string? category);
        MenuItem? GetById(int id);


    }
}
