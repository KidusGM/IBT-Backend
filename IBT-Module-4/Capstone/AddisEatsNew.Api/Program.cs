
using AddisEatsNew.Api.Services.MenuItemServices;
using AddisEatsNew.Api.Services.RestaurantServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IMenuItemServices, MenuItemServices>();
builder.Services.AddScoped <IRestaurantService, RestaurantService>();




/////////////


//var thePhoneNumber = builder.Configuration.GetValue<string>("data:Conatct:Phone");
//Console.WriteLine(thePhoneNumber);


//////////////
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
