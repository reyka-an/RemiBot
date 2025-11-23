namespace RemiQuest.Domain;

public class RewardPurchase
{
    public int Id { get; set; }

    public int UserId { get; set; }
    public User User { get; set; } = default!;

    public int RewardId { get; set; }
    public Reward Reward { get; set; } = default!;

    /// <summary>
    /// Сколько баллов было списано за покупку награды.
    /// </summary>
    public int SpentPoints { get; set; }

    /// <summary>
    /// Когда награда была куплена.
    /// </summary>
    public DateTime PurchasedAt { get; set; }
}