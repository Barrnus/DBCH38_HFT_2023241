using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using DBCH38_HFT_2023241.Models;
using DBCH38_HFT_2023241.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DBCH38_HFT_2023241.Logic
{
    public class TaskLogic : ITaskLogic
    {
        ITaskRepository<Models.Task> repo;

        public TaskLogic(ITaskRepository<Models.Task> repo)
        {
            this.repo = repo;
        }
        public void Create(Models.Task task)
        {
            repo.Create(task);
        }

        public void Delete(int id)
        {
            repo.Delete(id);
        }

        public Models.Task Read(int id)
        {
            Models.Task task = repo.Read(id);
            if (task == null)
            {
                throw new ArgumentException("task with given id does not exist");
            }
            return task;
        }

        public IEnumerable<Models.Task> ReadAll()
        {
            return repo.ReadAll();
        }

        public void Update(Models.Task task)
        {
            repo.Update(task);
        }

        public IEnumerable<Models.Task> GetTaskWithManyWorkers()
        {
            return repo.ReadAll().Where(x => x.Workers.Count() > 3);

        }

        public IEnumerable<Models.Task> GetTaskWithManyWorkersUrgent()
        {
            return repo.ReadAll().Where(x => x.Workers.Where(y => y.Task.Priority.Value == "Urgent").Count() > 3);

        }

    }
}
