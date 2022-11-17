var builder = WebApplication.CreateBuilder(args);

//output caching configurations
builder.Services.AddOutputCache(options =>
{
    options.AddPolicy("CustomCaching", _options =>
    {
        _options.Expire(TimeSpan.FromMinutes(1));
    });
});
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseOutputCache();//Output Caching middleware'ini ekliyoruz.

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
