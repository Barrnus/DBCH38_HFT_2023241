using DBCH38_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCH38_HFT_2023241.Repository
{
    public class WorkerRepository : IWorkerRepository<Worker>
    {
        protected TaskDbContext ctx;

        public WorkerRepository(TaskDbContext ctx)
        {
            this.ctx = ctx ?? throw new ArgumentNullException("the context is null");
        }
        public void Create(Worker item)
        {
            ctx.Set<Worker>().Add(item);
            ctx.SaveChanges();

        }

        public void Delete(int id)
        {
            ctx.Set<Worker>().Remove(Read(id));
            ctx.SaveChanges();

        }

        public IEnumerable<string> GetWorkersWithNoTask()
        {
            return ctx.Set<Worker>().Where(x => x.Task == null).Select(x => x.Name).ToList();
        }

        public IEnumerable<string> GetWorkersWithUrgentTask()
        {
            return ctx.Set<Worker>().Where(x => x.Task != null && x.Task.Priority.Value == "Urgent").Select(x => x.Name).ToList();
        }

        public Worker Read(int id)
        {
            return ctx.Set<Worker>().FirstOrDefault(item => item.Id.Equals(id));
        }

        public IQueryable<Worker> ReadAll()
        {
            return ctx.Set<Worker>();
        }

        public void Update(Worker item)
        {
            Worker old = Read(item.Id);
            foreach (var property in item.GetType().GetProperties())
            {
                property.SetValue(old, property.GetValue(item));
            }
            ctx.SaveChanges();

        }
    }
}
