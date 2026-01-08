using Microsoft.EntityFrameworkCore;

namespace DailyInventory.Models.Models;

public partial class DailyInventoryContext : DbContext
{
    public DailyInventoryContext()
    {
    }

    public DailyInventoryContext(DbContextOptions<DailyInventoryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<CreditCard> CreditCards { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=PREDATOR;Database=DailyInventory;Trusted_Connection=True;Integrated Security=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AS");

        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.RowId);

            entity.ToTable("Account");

            entity.Property(e => e.RowId).HasColumnName("RowID");
            entity.Property(e => e.AccountDescription)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.AccountHolderName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.AccountNo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.AccountType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.BankName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CustomerId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CustomerID");
        });

        modelBuilder.Entity<CreditCard>(entity =>
        {
            entity.HasKey(e => e.RowId);

            entity.ToTable("CreditCard");

            entity.Property(e => e.RowId).HasColumnName("RowID");
            entity.Property(e => e.BankName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CcunUsedAmount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("CCUnUsedAmount");
            entity.Property(e => e.CcusedAmount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("CCUsedAmount");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getdate())", "DF__CreditCar__Creat__2D27B809")
                .HasColumnType("datetime");
            entity.Property(e => e.CreditCardDescription)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreditCardHolderName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreditCardLimit).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CreditCardNo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreditCardType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CustomerId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CustomerID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}