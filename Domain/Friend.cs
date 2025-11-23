namespace RemiQuest.Domain;

public class Friend
{
    public int Id { get; set; }

    /// <summary>
    /// Владелец данной записи (тот, у кого в списке друзей отображается FriendUser).
    /// </summary>
    public int UserId { get; set; }
    public User User { get; set; } = default!;

    /// <summary>
    /// Друг пользователя.
    /// </summary>
    public int FriendUserId { get; set; }
    public User FriendUser { get; set; } = default!;

    public DateTime CreatedAt { get; set; }
}