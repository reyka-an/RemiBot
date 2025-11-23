using Microsoft.AspNetCore.Mvc;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using RemiQuest.Services;
using RemiQuest.Telegram;

namespace RemiQuest.Controllers;

[ApiController]
[Route("/webhook")]
public class WebhookController : ControllerBase
{
    private readonly TelegramUpdateHandler _updateHandler;

    public WebhookController(TelegramUpdateHandler updateHandler)
    {
        _updateHandler = updateHandler;
    }

    [HttpPost]
    public async Task<IActionResult> HandleWebhook([FromBody] Update update)
    {
        await _updateHandler.HandleAsync(update);
        return Ok();
    }
}
