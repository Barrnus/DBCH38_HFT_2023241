using DBCH38_HFT_2023241.Models;
using DBCH38_HFT_2023241.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCH38_HFT_2023241.Logic
{
    public interface IWorkerLogic
    {
        void Create(Worker worker);
        void Delete(int id);
        IEnumerable<Worker> ReadAll();
        Worker Read(int id);
        void Update(Worker worker);
        IEnumerable<string> GetWorkersWithUrgentTask();
        IEnumerable<string> GetWorkersWithNoTask();
    }
}
