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
        void Repository(IWorkerRepository<Worker> workerRepository);
        void Create(Worker worker);
        void Delete(int id);
        IEnumerable<Worker> ReadAll();
        Models.Task Read(int id);
        void Update(Worker worker);
    }
}
