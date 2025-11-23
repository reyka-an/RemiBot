using Microsoft.EntityFrameworkCore;
using RemiQuest.Domain;

namespace RemiQuest.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    // Таблицы
    public DbSet<User> Users => Set<User>();
    public DbSet<TaskItem> Tasks => Set<TaskItem>();
    public DbSet<Reward> Rewards => Set<Reward>();
    public DbSet<RewardPurchase> RewardPurchases => Set<RewardPurchase>();
    public DbSet<Friend> Friends => Set<Friend>();
    public DbSet<DialogueState> DialogueStates => Set<DialogueState>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // User ↔ Friend связи (две навигации к одному типу)
        modelBuilder.Entity<Friend>()
            .HasOne(f => f.User)
            .WithMany(u => u.Friends)
            .HasForeignKey(f => f.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Friend>()
            .HasOne(f => f.FriendUser)
            .WithMany(u => u.FriendOf)
            .HasForeignKey(f => f.FriendUserId)
            .OnDelete(DeleteBehavior.Restrict);

        // Один пользователь — одно состояние диалога
        modelBuilder.Entity<DialogueState>()
            .HasOne(ds => ds.User)
            .WithOne(u => u.DialogueState)
            .HasForeignKey<DialogueState>(ds => ds.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        // Reward → FriendUser ссылка
        modelBuilder.Entity<Reward>()
            .HasOne(r => r.FriendUser)
            .WithMany()
            .HasForeignKey(r => r.FriendUserId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}