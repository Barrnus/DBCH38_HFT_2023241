using DBCH38_HFT_2023241.Models;
using DBCH38_HFT_2023241.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCH38_HFT_2023241.Logic
{
    public class MockLogic
    {
        ITaskRepository<Models.Task> taskRepo;
        IWorkerRepository<Worker> workerRepo;
        IPriorityRepository<Priority> prioRepo;
        public MockLogic(ITaskRepository<Models.Task> taskRepo,IWorkerRepository<Worker> workerRepo,IPriorityRepository<Priority> prioRepo)
        {
            TaskRepo = taskRepo;
            WorkerRepo = workerRepo;
            PrioRepo = prioRepo;
        }

        public ITaskRepository<Models.Task> TaskRepo { get => taskRepo; private set => taskRepo = value; }
        public IWorkerRepository<Worker> WorkerRepo { get => workerRepo; private set => workerRepo = value; }
        public IPriorityRepository<Priority> PrioRepo { get => prioRepo; private set => prioRepo = value; }
    }
}
