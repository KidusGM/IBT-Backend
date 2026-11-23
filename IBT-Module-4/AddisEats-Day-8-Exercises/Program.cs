using AddisEats_Day_5_RestaurantService.Middleware;
using AddisEats_Day_5_RestaurantService.Models;
using AddisEats_Day_5_RestaurantService.Services;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.InvalidModelStateResponseFactory = context =>
    {
        var errors = context.ModelState
            .SelectMany(pair => pair.Value?.Errors.Select(error => (
                Field: pair.Key,
                Message: string.IsNullOrWhiteSpace(error.ErrorMessage)
                    ? "The submitted value is invalid."
                    : error.ErrorMessage)) ?? Enumerable.Empty<(string Field, string Message)>())
            .ToList();

        var fieldNames = string.Join(" ", errors.Select(e => e.Field));
        var messages = string.Join(" ", errors.Select(e => e.Message));

        Error error;
        if (context.HttpContext.Request.Path.StartsWithSegments("/api/v1/validation/amount"))
            error = ErrorCatalogue.InvalidAmount;
        else if (fieldNames.Contains("MobileNumber", StringComparison.OrdinalIgnoreCase))
            error = ErrorCatalogue.InvalidMobile;
        else if (fieldNames.Contains("DeliveryAddress", StringComparison.OrdinalIgnoreCase))
            error = ErrorCatalogue.DeliveryAddressRequired;
        else if (fieldNames.Contains("OrderType", StringComparison.OrdinalIgnoreCase))
            error = ErrorCatalogue.InvalidOrderType;
        else if (fieldNames.Contains("Items", StringComparison.OrdinalIgnoreCase) &&
                 messages.Contains("at least one item", StringComparison.OrdinalIgnoreCase))
            error = ErrorCatalogue.EmptyOrder;
        else if (fieldNames.Contains("Quantity", StringComparison.OrdinalIgnoreCase))
            error = ErrorCatalogue.InvalidQuantity;
        else
            error = new Error("VAL-400", "One or more request fields are invalid.");

        return new BadRequestObjectResult(new { Error = new { error.Code, error.Message } });
    };
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IRestaurantService, RestaurantService>();
builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("ReactFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:5173")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("ReactFrontend");
app.UseAuthorization();
app.MapControllers();
app.Run();
