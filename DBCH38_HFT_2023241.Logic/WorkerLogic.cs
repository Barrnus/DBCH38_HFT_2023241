using DBCH38_HFT_2023241.Models;
using DBCH38_HFT_2023241.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCH38_HFT_2023241.Logic
{
    public class WorkerLogic : IWorkerLogic
    {
        IWorkerRepository<Worker> repo;

        public WorkerLogic(IWorkerRepository<Worker> repo)
        {
            this.repo = repo;
        }

        public void Create(Worker worker)
        {
            repo.Create(worker);
        }

        public void Delete(int id)
        {
            repo.Delete(id);
        }

        public Worker Read(int id)
        {
            Worker task = repo.Read(id);
            if (task == null)
            {
                throw new ArgumentException("task with given id does not exist");
            }
            return task;

        }

        public IEnumerable<Worker> ReadAll()
        {
            return repo.ReadAll();
        }

        public void Update(Worker worker)
        {
            repo.Update(worker);
        }
    }
}
