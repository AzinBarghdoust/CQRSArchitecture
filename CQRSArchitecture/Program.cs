using CQRSArchitecture.Features.Customers.Commands.Create;
using CQRSArchitecture.Features.Orders.Commands.Create;
using CQRSArchitecture.Features.Orders.Commands.Delete;
using CQRSArchitecture.Features.Orders.Queries.Get;
using CQRSArchitecture.Features.Products.Commands.Create;
using CQRSArchitecture.Features.Products.Commands.Delete;
using CQRSArchitecture.Features.Products.Notifications;
using CQRSArchitecture.Features.Products.Queries.Get;
using CQRSArchitecture.Features.Products.Queries.List;
using CQRSArchitecture.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
//Registering DataBase
builder.Services.AddDbContext<AppDbContext>(options =>
                    options.UseSqlServer(builder.Configuration.GetConnectionString("CQRSContext")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.MapGet("/products/{id:guid}", async (Guid id, ISender mediatr) =>
{
    var product = await mediatr.Send(new GetProductQuery(id));
    if (product == null) return Results.NotFound();
    return Results.Ok(product);
});

app.MapGet("/products", async (ISender mediatr) =>
{
    var products = await mediatr.Send(new ListProductsQuery());
    return Results.Ok(products);
});

app.MapPost("/products", async (CreateProductCommand command, IMediator mediatr) =>
{
    var productId = await mediatr.Send(command);
    if (Guid.Empty == productId) return Results.BadRequest();
    await mediatr.Publish(new ProductCreatedNotification(productId));
    return Results.Created($"/products/{productId}", new { id = productId });
});

app.MapDelete("/products/{id:guid}", async (Guid id, ISender mediatr) =>
{
    await mediatr.Send(new DeleteProductCommand(id));
    return Results.NoContent();
});

app.MapPost("/orders", async (CreateOrderCommand command, IMediator mediatr) =>
{
    var orderId = await mediatr.Send(command);
    if (Guid.Empty == orderId) return Results.BadRequest();
    return Results.Created($"/orders/{orderId}", new { id = orderId });
});
app.MapPost("/customers", async (CreateCustomerCommand command, IMediator mediator) =>
{    var customerId = await mediator.Send(command);
    return Results.Created($"/customers/{customerId}", new { id = customerId });
});
app.MapGet("/orders/{orderId:guid}", async (Guid orderId, IMediator mediator) =>
{
    var order = await mediator.Send(new GetOrderQuery(orderId));
    if (order == null)
    {
        return Results.NotFound("Order not found.");
    }

    return Results.Ok(order);
});
app.MapDelete("/orders/{id:guid}", async (Guid id, ISender mediatr) =>
{
    await mediatr.Send(new DeleteOrderCommand(id));
    return Results.NoContent();
});
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
