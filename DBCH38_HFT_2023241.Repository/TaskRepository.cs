using DBCH38_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCH38_HFT_2023241.Repository
{
    public class TaskRepository : ITaskRepository<Models.Task>
    {
        protected TaskDbContext ctx;

        public TaskRepository(TaskDbContext ctx)
        {
            this.ctx = ctx ?? throw new ArgumentNullException("the context is null");
        }
        public void Create(Models.Task item)
        {
            ctx.Set<Models.Task>().Add(item);
        }

        public void Delete(int id)
        {
            ctx.Set<Models.Task>().Remove(Read(id));
        }

        public Models.Task Read(int id)
        {
            return ctx.Set<Models.Task>().First(x => x.Id == id);
        }

        public IQueryable<Models.Task> ReadAll()
        {
            return ctx.Set<Models.Task>();
        }

        public void Update(Models.Task item)
        {
            Models.Task old = Read(item.Id);
            foreach (var property in item.GetType().GetProperties())
            {
                property.SetValue(old, property.GetValue(item));
            }
        }
    }
}
