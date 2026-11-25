
using AddisEatsNew.Api.Middleware;
using AddisEatsNew.Api.Services.MenuItemServices;
using AddisEatsNew.Api.Services.OrderServices;
using AddisEatsNew.Api.Services.RestaurantServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IMenuItemServices, MenuItemServices>();
builder.Services.AddScoped <IRestaurantService, RestaurantService>();
builder.Services.AddScoped<IOrderServices, OrderServices>();


//builder.Services.Configure<JwtBearerOptions>(
// builder.Configuration.GetSection("Jwt"));

//var jwt = builder.Configuration.GetSection("Jwt").Get<JwtOptions>()!;

//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme);




/////////////


//var thePhoneNumber = builder.Configuration.GetValue<string>("data:Conatct:Phone");
//Console.WriteLine(thePhoneNumber);


//////////////
///

builder.Services.AddCors(options =>
options.AddPolicy("frontend", Policy =>
Policy.WithOrigins("http://localhost:3000")
.AllowAnyHeader()
.AllowAnyMethod()));


var app = builder.Build();


//Custom Middleware
app.Use(async(context, next) => 
{
    Console.WriteLine("The Requests is comming in");
    await next(context);

    Console.WriteLine("The Requests is going out");

});

//Custom Middleware


app.Use(async (context, next) =>
{
    Console.WriteLine("The Requests is still comming in");
    await next(context);

    Console.WriteLine("The Requests is still going out");

});


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("frontend");
app.UseMiddleware<CorrelationMiddleware>();
app.UseMiddleware<RequestTimingMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
