
namespace AddisEatsNew.Api.DTOs
{
    public class PaginatedResultDTO
    {
        public int TotalCount { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }

        public List<RestaurantDTO> Data { get; set; } = new List<RestaurantDTO>();
    }
}
