namespace RemiQuest.Domain;

public class TaskItem
{
    public int Id { get; set; }

    public int UserId { get; set; }
    public User User { get; set; } = default!;

    /// <summary>
    /// Название задачи.
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Описание задачи
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Сложность от 1 до 10.
    /// </summary>
    public int Difficulty { get; set; }

    /// <summary>
    /// Дедлайн задачи
    /// </summary>
    public DateTime? Deadline { get; set; }

    /// <summary>
    /// Включено ли напоминание по этой задаче.
    /// </summary>
    public bool HasReminder { get; set; }

    /// <summary>
    /// Время напоминания по задаче
    /// </summary>
    public DateTime? ReminderDateTime { get; set; }

    /// <summary>
    /// Статус задачи: активна или выполнена.
    /// </summary>
    public TaskStatus Status { get; set; }

    /// <summary>
    /// Когда задача была создана.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Когда задача была выполнена
    /// </summary>
    public DateTime? CompletedAt { get; set; }

    /// <summary>
    /// Отправляли ли уже уведомление о прошедшем дедлайне.
    /// </summary>
    public bool IsDeadlineNotified { get; set; }
}

public enum TaskStatus
{
    Active = 0,
    Completed = 1
}