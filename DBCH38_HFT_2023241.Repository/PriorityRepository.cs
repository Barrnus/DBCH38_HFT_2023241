using DBCH38_HFT_2023241.Models;
using DBCH38_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCH38_HFT_2023241.Repository
{
    public class PriorityRepository : IPriorityRepository<Priority>
    {
        protected TaskDbContext ctx;
        public PriorityRepository(TaskDbContext ctx)
        {
            this.ctx = ctx ?? throw new ArgumentNullException("the context is null");
        }

        public void Create(Priority item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Priority Read(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Priority> ReadAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Priority item)
        {
            throw new NotImplementedException();
        }
    }
}
