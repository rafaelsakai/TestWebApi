
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// https://stackoverflow.com/questions/69074572/to-trim-an-string-before-model-validation-occurs-in-asp-net-core
builder.Services.AddControllers(opt =>
{
    opt.ModelBinderProviders.Insert(0, new StringTrimModelBinderProvider());
}).AddJsonOptions(opt =>
{
    opt.JsonSerializerOptions.Converters.Add(new StringTrimJsonConverter());
});

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