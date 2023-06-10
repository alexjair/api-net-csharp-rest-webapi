using api_net_csharp_rest_webapi;
using api_net_csharp_rest_webapi.Middlewares;
using api_net_csharp_rest_webapi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//conex sql
builder.Services.AddSqlServer<TareasContext>("Data Source=DESKTOP-FGI8UOO;Initial Catalog=EntityFkDBmemoria;user id=sa;password=12345");
//builder.Services.AddSqlServer<TareasContext>(builder.Configuration.GetConnectionString("cnTareas"));

//Injection Dependencias
builder.Services.AddScoped<IHelloWorldService, HelloWorldService>();
builder.Services.AddScoped<IHelloWorldService>(p => new HelloWorldService());

builder.Services.AddScoped<ITareaService, TareaService>();
builder.Services.AddScoped<ICategoriaService, CategoriaService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//agreago middlewares
app.UseHttpsRedirection();

app.UseAuthorization();

//agreago middlewares
//app.UseWelcomePage(); //se puede applicar 

//Middlewares extension
//Example: http://localhost:5185/api/ListaData/lista?time
app.UseTimeMiddleware();

app.MapControllers();

app.Run();
