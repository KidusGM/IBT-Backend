using AddisEats_Day_3_MenuServices.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddScoped<DeliveryFeeService>();
builder.Services.AddScoped<DescriptionService>();
builder.Services.AddScoped<ModelDemoService>();
builder.Services.AddScoped<OrderService>();
builder.Services.AddScoped<DiscountService>();
builder.Services.AddScoped<AmountValidationService>();
builder.Services.AddScoped<TenPercentDiscountPolicy>();
builder.Services.AddScoped<FiftyBirrDiscountPolicy>();
builder.Services.AddScoped<TwentyBirrDiscountPolicy>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
