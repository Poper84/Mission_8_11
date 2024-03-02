using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Mission_8_11.Models;

public partial class CoolDataContext : DbContext
{
    // Set up the context file
    public CoolDataContext()
    {
    }

    // set up the options
    public CoolDataContext(DbContextOptions<CoolDataContext> options)
        : base(options)
    {
    }

    // Have a table called Categories
    public virtual DbSet<Category> Categories { get; set; }

    // Have a table called Stats
    public virtual DbSet<Stat> Stats { get; set; }

    // the rest was built for us with the scaffold command.
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=CoolData3.sqlite");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Stat>(entity =>
        {
            entity.HasKey(e => e.TaskId);

            entity.Property(e => e.TaskId).HasColumnName("task_id");
            entity.Property(e => e.CategoryId).HasColumnName("Category_id");
            entity.Property(e => e.Completed)
                .HasColumnName("completed");
            entity.Property(e => e.DueDate).HasColumnName("due_date");
            entity.Property(e => e.Quadrant).HasColumnName("quadrant");
            entity.Property(e => e.TaskName).HasColumnName("task_name");

            entity.HasOne(d => d.Category).WithMany(p => p.Stats).HasForeignKey(d => d.CategoryId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
