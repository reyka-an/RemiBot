# RemiQuest

ASP.NET Core проект с Telegram Bot Webhook.

## Описание

Проект содержит webhook контроллер для обработки обновлений от Telegram Bot API.

## Функциональность

- Webhook endpoint для получения обновлений от Telegram
- Обработка текстовых сообщений
- Ответы на приветствия и другие сообщения

## Требования

- .NET 10.0 или выше
- Telegram Bot Token

## Настройка

1. Клонируйте репозиторий
2. Настройте `appsettings.json` с вашим Telegram Bot Token
3. Запустите приложение

## API Endpoints

- `GET /webhook` - Проверка работы webhook (возвращает "Hello World")
- `POST /webhook` - Принимает обновления от Telegram Bot API

## Разработка

```bash
dotnet restore
dotnet build
dotnet run
```

