using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCH38_HFT_2023241.Repository
{
    public class TaskRepository : ITaskRepository<Task>
    {
        protected TaskDbContext ctx;

        public TaskRepository(TaskDbContext ctx)
        {
            this.ctx = ctx ?? throw new ArgumentNullException("the context is null");
        }
        public void Create(Task item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task Read(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Task> ReadAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Task item)
        {
            throw new NotImplementedException();
        }
    }
}
