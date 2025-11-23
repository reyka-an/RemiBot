using Microsoft.EntityFrameworkCore;
using RemiQuest.Data;
using RemiQuest.Domain;

namespace RemiQuest.Services;

public class UserService
{
    private readonly AppDbContext _db;

    public UserService(AppDbContext db)
    {
        _db = db;
    }

    /// <summary>
    /// Возвращает пользователя по TelegramUserId или создаёт нового.
    /// </summary>
    public async Task<User> GetOrCreateUserAsync(long telegramUserId, string? username)
    {
        var user = await _db.Users
            .FirstOrDefaultAsync(x => x.TelegramUserId == telegramUserId);

        if (user != null)
        {
            // Обновляем username, если он изменился
            if (username != null && user.Username != username)
            {
                user.Username = username;
                await _db.SaveChangesAsync();
            }

            return user;
        }

        // Создаём пользователя впервые
        user = new User
        {
            TelegramUserId = telegramUserId,
            Username = username,
            DailySummaryTime = null,
            CurrentPoints = 0,
            CreatedAt = DateTime.UtcNow
        };

        _db.Users.Add(user);
        await _db.SaveChangesAsync();

        return user;
    }
}