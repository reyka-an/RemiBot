namespace RemiQuest.Domain;

public class Reward
{
    public int Id { get; set; }

    public int UserId { get; set; }
    public User User { get; set; } = default!;

    /// <summary>
    /// Название награды.
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Описание награды (опционально).
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Стоимость награды в баллах.
    /// </summary>
    public int Cost { get; set; }

    /// <summary>
    /// Награда была добавлена другом.
    /// </summary>
    public bool IsFromFriend { get; set; }

    /// <summary>
    /// Пользователь-друг, который добавил награду (если есть).
    /// </summary>
    public int? FriendUserId { get; set; }
    public User? FriendUser { get; set; }

    public DateTime CreatedAt { get; set; }

    public ICollection<RewardPurchase> Purchases { get; set; } = new List<RewardPurchase>();
}