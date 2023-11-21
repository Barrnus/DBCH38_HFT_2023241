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
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Worker Read(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Worker> ReadAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Worker item)
        {
            throw new NotImplementedException();
        }
    }
}
