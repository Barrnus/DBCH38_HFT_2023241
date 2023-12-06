using DBCH38_HFT_2023241.Logic;
using DBCH38_HFT_2023241.Models;
using DBCH38_HFT_2023241.Repository;
using Moq;
using NUnit.Framework;
using System;

namespace DBCH38_HFT_2023241.Test
{
    [TestFixture]
    public class LogicTester
    {
        MockLogic logic;
        Mock<ITaskRepository<Models.Task>> mockTaskRepo;
        Mock<IWorkerRepository<Worker>> mockWorkerRepo;
        Mock<IPriorityRepository<Priority>> mockPrioRepo;

    }
}
