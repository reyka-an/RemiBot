using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace RemiQuest.Controllers;

[ApiController]
[Route("/webhook")]

public class WebhookController(ITelegramBotClient bot) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> HandelWebhook([FromBody] Update update)
    {
        if (update.Message?.Text != null)
        {
            var message = update.Message;
            var chatId = message.Chat.Id;
            var text = message.Text;

            if (text.Equals("Привет", StringComparison.OrdinalIgnoreCase))
            {
                await bot.SendMessage(chatId, "Привет! Как дела?");
            }
            else
            {
                await bot.SendMessage(chatId, "Как дела?");
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