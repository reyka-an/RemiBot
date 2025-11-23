namespace RemiQuest.Domain;

public class DialogueState
{
    public int Id { get; set; }

    public int UserId { get; set; }
    public User User { get; set; } = default!;

    /// <summary>
    /// Текущее состояние диалога с пользователем.
    /// </summary>
    public DialogueStateType State { get; set; }

    /// <summary>
    /// Временные данные в формате JSON.
    /// </summary>
    public string? TempData { get; set; }

    public DateTime UpdatedAt { get; set; }
}

public enum DialogueStateType
{
    Idle = 0,

    // Добавление задачи
    AddTask_Title = 10,
    AddTask_Description = 11,
    AddTask_Difficulty = 12,
    AddTask_Deadline = 13,
    AddTask_Reminder = 14,

    // Добавление награды
    AddReward_Title = 20,
    AddReward_Description = 21,
    AddReward_Cost = 22
}