using Telegram.Bot;

var builder = WebApplication.CreateBuilder(args);

var botToken = builder.Configuration["TelegramBot:Token"];

if (string.IsNullOrEmpty(botToken))
{
    throw new InvalidOperationException("Не задан TelegramBot:Token в appsettings.json");
}

// Регистрируем Telegram Bot клиента в DI
builder.Services.AddSingleton<ITelegramBotClient>(_ =>
{
    return new TelegramBotClient(botToken);
});

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();