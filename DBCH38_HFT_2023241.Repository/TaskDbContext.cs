using Microsoft.EntityFrameworkCore;
using DBCH38_HFT_2023241.Models;
using System;

namespace DBCH38_HFT_2023241.Repository
{
    public class TaskDbContext : DbContext
    {
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<Priority> Priorities { get; set; }
        public virtual DbSet<Worker> Workers { get; set; }

        public TaskDbContext()
        {
            this.Database.EnsureCreated();

        }

        public TaskDbContext(DbContextOptions options) : base(options)
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseInMemoryDatabase("HFTDb").UseLazyLoadingProxies();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Task>().HasOne(p=>p.Priority).WithMany(t=>t.Tasks).OnDelete(DeleteBehavior.ClientSetNull);
            modelBuilder.Entity<Worker>().HasOne(t=>t.Task).WithMany(w=>w.Workers).OnDelete(DeleteBehavior.ClientSetNull);

            Priority pri1 = new Priority() { Id = 1, Value="Urgent" };
            Priority pri2 = new Priority() { Id = 2, Value ="Neutral" };
            Priority pri3 = new Priority() { Id = 3, Value ="Low" };

            Worker worker1 = new Worker() {Id = 1, Age = 18, Name="A. László", Position = "Janitor",TaskId=1 };
            Worker worker2 = new Worker() {Id = 2, Age = 23, Name="B. László", Position = "IT" ,TaskId=3};
            Worker worker3 = new Worker() {Id = 3, Age = 38, Name="C. László", Position = "IT" ,TaskId = 3 };
            Worker worker6 = new Worker() { Id = 6, Age = 23, Name = "X. László", Position = "IT", TaskId = 3 };
            Worker worker7 = new Worker() { Id = 7, Age = 38, Name = "Y. László", Position = "IT", TaskId = 3 };
            Worker worker4 = new Worker() {Id = 4, Age = 24, Name="D. László", Position = "Accountant" ,TaskId = 2 };
            Worker worker5 = new Worker() {Id = 5, Age = 55, Name="E. László", Position = "CEO",TaskId=4};

            Task task1 = new Task() { Id=1, Description="Office Cleanup", Type = "Janitor", PriorityId=1};
            Task task2 = new Task() { Id=2, Description="Yearly Tax Declaration", Type = "Accountant", PriorityId=2};
            Task task3 = new Task() { Id=3, Description="Implementing Scalability", Type = "IT", PriorityId=3};
            Task task4 = new Task() { Id=4, Description="End Of Year Speech", Type = "CEO", PriorityId=2};

            modelBuilder.Entity<Priority>().HasData(pri1,pri2,pri3);
            modelBuilder.Entity<Worker>().HasData(worker1, worker2, worker3,worker4,worker5,worker6,worker7);
            modelBuilder.Entity<Task>().HasData(task1,task2,task3,task4);

            base.OnModelCreating(modelBuilder);
        }
    }
}
