using GroceryList.Application.Commands;
using GroceryList.Application.Queries;
using GroceryList.Core.Repositories;
using GroceryList.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddSingleton<IShoppingListRepository, ShoppingListRepository>();
builder.Services.AddTransient<GetShoppingListByIdHandler>();
builder.Services.AddScoped<CreateShoppingListHandler>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.UseRouting();
app.MapControllers();

app.Run();