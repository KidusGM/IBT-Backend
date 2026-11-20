namespace AddisEatsNew.Api.DTOs
{
    public record RestaurantDTO
        (
        int Id,
        string Name,
        string Address,
        string Phone,
        bool IsActive
        
        );
   
}
