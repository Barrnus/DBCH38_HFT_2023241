using DBCH38_HFT_2023241.Models;
using DBCH38_HFT_2023241.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCH38_HFT_2023241.Logic
{
    public interface IPriorityLogic
    {
        void Create(Priority priority);
        void Delete(int id);
        IEnumerable<Priority> ReadAll();
        Priority Read(int id);
        void Update(Priority priority);
        IEnumerable<Priority> GetPriorityWithMostTasks();
    }
}
