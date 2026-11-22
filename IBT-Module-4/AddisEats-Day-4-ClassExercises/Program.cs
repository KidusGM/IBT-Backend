using AddisEats_Day_4_ClassExercises.Models;
using AddisEats_Day_4_ClassExercises.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Exercise 3: Register the clock service.
// Exercise 4: Change this line to test different lifetimes.
builder.Services.AddTransient<IClock, ClockService>();

// To test scoped, use:
// builder.Services.AddScoped<IClock, ClockService>();

// To test singleton, use:
// builder.Services.AddSingleton<IClock, ClockService>();

// Exercise 5: Payment provider.
// Change exactly this line to switch providers.
builder.Services.AddScoped<IPaymentProvider, TeleBirrProvider>();

// To switch to CBE Birr, use:
// builder.Services.AddScoped<IPaymentProvider, CbeBirrProvider>();

builder.Services.AddScoped<PaymentService>();

// Exercise 6: Delivery options
builder.Services.Configure<DeliveryOptions>(
    builder.Configuration.GetSection("Delivery"));
builder.Services.AddTransient<IClock, ClockService>();

builder.Services.AddScoped<IPaymentProvider, TeleBirrProvider>();

builder.Services.AddScoped<PaymentService>();

builder.Services.Configure<DeliveryOptions>(
    builder.Configuration.GetSection("Delivery"));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();