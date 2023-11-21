using DBCH38_HFT_2023241.Models;
using DBCH38_HFT_2023241.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCH38_HFT_2023241.Logic
{
    public class PriorityLogic : IPriorityLogic
    {
        IPriorityRepository<Priority> repo;

        public PriorityLogic(IPriorityRepository<Priority> repo)
        {
            this.repo = repo;
        }

        public void Create(Priority priority)
        {
            repo.Create(priority);
        }

        public void Delete(int id)
        {
            repo.Delete(id);
        }

        public Priority Read(int id)
        {
            Priority task = repo.Read(id);
            if (task == null)
            {
                throw new ArgumentException("priority with given id does not exist");
            }
            return task;
        }

        public IEnumerable<Priority> ReadAll()
        {
            return repo.ReadAll();  
        }

        public void Update(Priority priority)
        {
            repo.Update(priority);
        }
    }
}
