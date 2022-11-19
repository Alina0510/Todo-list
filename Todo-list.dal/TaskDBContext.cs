using Microsoft.EntityFrameworkCore;
using Todo_list.dal.Entities;
namespace Todo_list.dal
{
    public class TaskDBContext : DbContext
    {
        public DbSet<MyTask> Tasks { get; set; }

        public TaskDBContext(DbContextOptions<TaskDBContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}