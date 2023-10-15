using BusinessObject.Service;
using BusinessObject.Service.IService;
using DataAccess.IRepositories;
using DataAccess.Models;
using DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData;
using Microsoft.AspNetCore.OData.Batch;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddOData(op =>
{
	op.Select().Expand().Filter().OrderBy().SetMaxTop(null).Count();
	op.AddRouteComponents("api", GetEdmModel());
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Repository
builder.Services.AddScoped<IProductRepository,ProductRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
builder.Services.AddScoped<IMemberRepository, MemberRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IUnitRepository, UnitRepository>();
//Service
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IMemberService, MemberService>();
builder.Services.AddScoped<IOrderDetailService, OrderDetailService>();
builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.AddDbContext<FStoreDBContext>(option =>
	option.UseSqlServer(builder.Configuration.GetConnectionString("FStoreDB")));
// Mapper
builder.Services.AddAutoMapper(typeof(Program).Assembly);

var app = builder.Build();
app.UseRouting();
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

static IEdmModel GetEdmModel()
{
	ODataConventionModelBuilder builder = new();
	builder.EntitySet<Member>("Member");
   builder.EntitySet<Product>("Product");
    return builder.GetEdmModel();
}