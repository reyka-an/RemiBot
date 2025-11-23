using System;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using RemiQuest.Services;

namespace RemiQuest.Telegram;

public class TelegramUpdateHandler
{
    private readonly ITelegramBotClient _bot;
    private readonly UserService _userService;

    public TelegramUpdateHandler(ITelegramBotClient bot, UserService userService)
    {
        _bot = bot;
        _userService = userService;
    }

    /// <summary>
    /// Главная точка входа для обработки всех апдейтов от Telegram.
    /// </summary>
    public async Task HandleAsync(Update update)
    {
        try
        {
            if (update.Message is { } message)
            {
                await HandleMessageAsync(message);
            }
            else if (update.CallbackQuery is { } callback)
            {
                await HandleCallbackQueryAsync(callback);
            }
        }
        catch (Exception ex)
        {
            // На будущее: сюда можно добавить логирование
            Console.WriteLine($"[TelegramUpdateHandler] Error: {ex}");
        }
    }

    private async Task HandleMessageAsync(Message message)
    {
        if (message.Text is not { } text)
            return;

        var chatId = message.Chat.Id;
        var from = message.From;

        // Всегда стараемся иметь пользователя в базе
        if (from != null)
        {
            await _userService.GetOrCreateUserAsync(from.Id, from.Username);
        }

        // Обработка команд
        if (text == "/start")
        {
            await HandleStartCommandAsync(chatId, from);
            return;
        }

        // Простой пример: реакция на "Привет"
        if (text.Equals("Привет", StringComparison.OrdinalIgnoreCase))
        {
            await _bot.SendMessage(
                chatId: chatId,
                text: "Привет! 😊 Как ты себя чувствуешь сегодня?"
            );
            return;
        }

        // Для всего остального пока простой ответ-заглушка
        await _bot.SendMessage(
            chatId: chatId,
            text: "Я пока только учусь. Скоро здесь будет полноценный планер с задачами и наградами 🌱"
        );
    }

    private async Task HandleStartCommandAsync(long chatId, User? from)
    {
        var usernamePart = from?.Username != null
            ? $"@{from.Username}"
            : "Давай познакомимся";

        var welcome = $"{usernamePart}, привет! Я мягкий планер с геймификацией 💛\n\n" +
                      "Я помогу тебе разрулить отложенные дела без чувства вины и перегруза.\n\n" +
                      "Для начала выберем время ежедневной сводки.\n" +
                      "Напиши его в формате *09:00* — когда тебе удобно получать список дел на день.";

        await _bot.SendMessage(
            chatId: chatId,
            text: welcome,
            parseMode: ParseMode.Markdown
        );
    }

    private Task HandleCallbackQueryAsync(CallbackQuery callbackQuery)
    {
        return Task.CompletedTask;
    }
}
