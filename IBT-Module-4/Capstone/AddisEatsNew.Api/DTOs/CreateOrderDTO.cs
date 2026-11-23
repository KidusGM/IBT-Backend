using AddisEatsNew.Api.Validation;
using System.ComponentModel.DataAnnotations;
namespace AddisEatsNew.Api.DTOs
{
    public record CreateOrderDTO
    (
        [Range(1, int.MaxValue, ErrorMessage = "Restaurant ID must be positive")]
        int RestaurantId,
        int MenuItemId,
        [Required(ErrorMessage ="Customer Name is required.")]
        string CustomerName,
        [StringLength(60, MinimumLength =1, ErrorMessage ="Delivery address is Wrong")]
        string DeliveryAddress,
        [Required(ErrorMessage ="Customer is required")]
       [EthiopianMobile]
        string CustomerPhone,
        [Range(1,50, ErrorMessage ="Quantity must be between 1 and 50.")]
        int Quantity,
        [ETBAmount]
         decimal TotalAmount

    //int RestaurantId,
    //    int MenuItemId,
    //    string CustomerName,
    //    string DeliveryAddress,
    //     string CustomerPhone,
    //    int Quantity,
    //    decimal TotalAmount

    );
}
