//using AddisEats.Api.Services.ResturantService;





//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.

//builder.Services.AddCors(options =>
//    options.AddPolicy("frontend", policy =>
//        policy.WithOrigins("http://localhost:5173")   // Vite
//              .AllowAnyHeader()
//              .AllowAnyMethod()));


//builder.Services.AddControllers();
//// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
////builder.Services.AddOpenApi();
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
//builder.Services.AddScoped<ResturantService, ResturantService>();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI(); //we are setting middleware like swager and postman  for that we use "Use"
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.UseAuthorization();
//app.UseCors("frontend");     // BEFORE MapControllers



//app.MapControllers();

//app.Run();

using AddisEats.Api.Models;


MenuItem menuItem = new MenuItem(1, "Burger", "Food", 5.99m);
Console.WriteLine($"Item 1: {menuItem.Name}, Category: {menuItem.Category}, Price: {menuItem.Price}");

//List<string> x = new List<string> { "Abebe", "Kebede", "Almaz" };
List<MenuItem> myMenuItems = new List<MenuItem>
 {
     new MenuItem(1, "Burger", "Food", 10.5m),
       new MenuItem(2, "Piza", "Food", 15.5m),
         new MenuItem(3, "Coke", "Drink", 2.5m),
          new MenuItem(3, "Water", "Drink", 1.5m),
           new MenuItem(3, "Salad", "Food", 8.5m),
            new MenuItem(3, "Fruit", "Food", 6.5m),
             new MenuItem(3, "Fries", "Food", 3.3m),
              new MenuItem(3, "IceCream", "Dessert", 7.5m),
 };



// lINQ

// 1. Where Clause


var foodItems = myMenuItems.Where(i => i.Category == "Food");

foreach (var item in foodItems)
{
   Console.WriteLine($"Food Items Name: {item.Name}");
}

var kfoodItems = myMenuItems.Where(i => i.Price > 8.0m);

foreach (var item in kfoodItems)
{
    Console.WriteLine($"Food Items Name: {item.Name}");
}


// 2 Select


var prices = myMenuItems.Select(i => i.Price).ToList();

foreach (var price in prices)
{
    Console.WriteLine($"Price: {price:C}");
}


//3 ANY Clause  


bool hasExpensiveItems = myMenuItems.Any(i => i.Price > 10.0m);
Console.WriteLine($"Has Expensive Items: {hasExpensiveItems}");


//4 ALL Clause
bool allExpensiveItems = myMenuItems.All(i => i.Price > 10.0m);
Console.WriteLine($"Has Expensive Items: {allExpensiveItems}");


//5 First and FIRSTorDEFAULT Clause

//  This is safe FIRSTorDEFAULT Clause

//var item = myMenuItems.First(i => i.Price > 10.0m);
var item1 = myMenuItems.FirstOrDefault(i => i.Price > 10.0m)

??
throw new InvalidOperationException("new new item was found greater than 10.0m");

if (item1 != null)

{
    Console.WriteLine($"First Items with price Greater than: {item1.Name}");

}

else {

    Console.WriteLine($"No Items with price Greater than");
}



//6 ORDERBY  and ORDERBYDESENDING

var orderByPrice = myMenuItems.OrderBy(i => i.Price).ToList();

foreach (var item in orderByPrice)
{
    Console.WriteLine($"Price:{item.Name} {item.Price:C}");
}


var orderByDescending = myMenuItems.OrderByDescending(i => i.Price).ToList();

foreach (var item in orderByDescending)
{
    Console.WriteLine($"Price:{item.Name} {item.Price:C}");
}


//7 SKIP and TAKE

var thelastfouritems = myMenuItems.Skip(3).Take(4).ToList();

Console.WriteLine(thelastfouritems.Count);


//8 SUM and AVERAGE Clause


var sumofprices = myMenuItems.Sum(i => i.Price);
var averageofprices = myMenuItems.Average(i => i.Price);

Console.WriteLine($"Sum of Prices {sumofprices:C} Average of Prices {averageofprices:C}");
