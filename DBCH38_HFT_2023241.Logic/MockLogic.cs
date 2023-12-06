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
        TaskLogic taskLogic;
        PriorityLogic priorityLogic;
        WorkerLogic workerLogic;
        public MockLogic(ITaskRepository<Models.Task> taskRepo,IWorkerRepository<Worker> workerRepo,IPriorityRepository<Priority> prioRepo)
        {
            TaskLogic = new TaskLogic(taskRepo);
            WorkerLogic = new WorkerLogic(workerRepo);
            PriorityLogic = new PriorityLogic(prioRepo);
        }

        public TaskLogic TaskLogic { get => taskLogic; private set => taskLogic = value; }
        public PriorityLogic PriorityLogic { get => priorityLogic; private set => priorityLogic = value; }
        public WorkerLogic WorkerLogic { get => workerLogic; private set => workerLogic = value; }
    }
}
