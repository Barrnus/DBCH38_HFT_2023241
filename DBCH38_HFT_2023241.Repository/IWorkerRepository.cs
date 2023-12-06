using DBCH38_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCH38_HFT_2023241.Repository
{
    public interface IWorkerRepository<T> where T:Worker
    {
        IQueryable<T> ReadAll();
        T Read(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
        public IEnumerable<string> GetWorkersWithUrgentTask();
        public IEnumerable<string> GetWorkersWithNoTask();
    }
}
