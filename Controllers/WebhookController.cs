using Microsoft.AspNetCore.Mvc;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using RemiQuest.Services;

namespace RemiQuest.Controllers;

[ApiController]
[Route("/webhook")]
public class WebhookController : ControllerBase
{
    private readonly ITelegramBotClient _bot;
    private readonly UserService _userService;

    public WebhookController(ITelegramBotClient bot, UserService userService)
    {
        _bot = bot;
        _userService = userService;
    }

    [HttpPost]
    public async Task<IActionResult> HandleWebhook([FromBody] Update update)
    {
        if (update.Message?.Text is { } text)
        {
            var message = update.Message;
            var chatId = message.Chat.Id;
            var from = message.From;

            // На будущее: здесь можно будет вызвать GetOrCreateUserAsync
            if (from != null)
            {
                await _userService.GetOrCreateUserAsync(from.Id, from.Username);
            }

            if (text.Equals("Привет", StringComparison.OrdinalIgnoreCase))
            {
                await _bot.SendMessage(
                    chatId: chatId,
                    text: "Привет! Как дела?"
                );
            }
            else
            {
                await _bot.SendMessage(
                    chatId: chatId,
                    text: "Как дела?"
                );
            }
        }

        return Ok();
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok("Hello World");
    }
}