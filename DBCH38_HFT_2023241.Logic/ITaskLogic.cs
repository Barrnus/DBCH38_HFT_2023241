using DBCH38_HFT_2023241.Models;
using DBCH38_HFT_2023241.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCH38_HFT_2023241.Logic
{
    public interface ITaskLogic
    {
        void Repository(ITaskRepository<Models.Task> taskRepository);
        void Create(Models.Task task);
        void Delete(int id);
        IEnumerable<Models.Task> ReadAll();
        Models.Task Read(int id);
        void Update(Models.Task task);
    }
}
