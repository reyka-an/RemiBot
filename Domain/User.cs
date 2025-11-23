namespace RemiQuest.Domain;

public class User
{
    public int Id { get; set; }

    /// <summary>
    /// Telegram user id 
    /// </summary>
    public long TelegramUserId { get; set; }

    /// <summary>
    /// Telegram username 
    /// </summary>
    public string? Username { get; set; }

    /// <summary>
    /// Время ежедневной сводки в формате "HH:mm", например "09:00".
    /// Может быть null, если пользователь ещё не выбрал.
    /// </summary>
    public string? DailySummaryTime { get; set; }

    /// <summary>
    /// Текущий баланс баллов.
    /// </summary>
    public int CurrentPoints { get; set; }

    /// <summary>
    /// Дата и время регистрации пользователя в боте
    /// </summary>
    public DateTime CreatedAt { get; set; }

    // Навигационные свойства
    public ICollection<TaskItem> Tasks { get; set; } = new List<TaskItem>();
    public ICollection<Reward> Rewards { get; set; } = new List<Reward>();
    public ICollection<RewardPurchase> RewardPurchases { get; set; } = new List<RewardPurchase>();

    public ICollection<Friend> Friends { get; set; } = new List<Friend>();
    public ICollection<Friend> FriendOf { get; set; } = new List<Friend>();

    public DialogueState? DialogueState { get; set; }
}