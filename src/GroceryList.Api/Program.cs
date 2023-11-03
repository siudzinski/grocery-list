var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

//register ShoppingListRepository as a singleton scope
//register GetShoppingListByIdHandler as a transient scope

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.UseRouting();
app.MapControllers();

app.Run();
