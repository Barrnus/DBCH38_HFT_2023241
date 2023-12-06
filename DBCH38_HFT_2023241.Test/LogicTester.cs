using DBCH38_HFT_2023241.Logic;
using DBCH38_HFT_2023241.Models;
using DBCH38_HFT_2023241.Repository;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using System;
using System.Linq;
using System.Runtime.CompilerServices;

namespace DBCH38_HFT_2023241.Test
{
    [TestFixture]
    public class LogicTester
    {
        MockLogic logic;
        Mock<ITaskRepository<Models.Task>> mockTaskRepo;
        Mock<IWorkerRepository<Worker>> mockWorkerRepo;
        Mock<IPriorityRepository<Priority>> mockPrioRepo;


        [SetUp]
        public void Init()
        {

            Priority pri1 = new Priority() { Id = 1, Value = "Urgent" };
            Priority pri2 = new Priority() { Id = 2, Value = "Neutral" };
            Priority pri3 = new Priority() { Id = 3, Value = "Low" };

            Task task1 = new Task() { Id = 1, Description = "JanitorTaskTest", Type = "Janitor", PriorityId = 1, Priority = pri1 };
            Task task2 = new Task() { Id = 2, Description = "AccountantTaskTest", Type = "Accountant", PriorityId = 2, Priority = pri2 };
            Task task3 = new Task() { Id = 3, Description = "ITTaskTest", Type = "IT", PriorityId = 3, Priority = pri3 };
            Task task4 = new Task() { Id = 4, Description = "CEOTaskTest", Type = "CEO", PriorityId = 2, Priority = pri2 };

            pri1.Tasks = new List<Models.Task>() { task1 };
            pri2.Tasks = new List<Models.Task>() { task2, task4 };
            pri3.Tasks = new List<Models.Task>() { task3 };

            var workersList = new List<Worker>()
            {
                new Worker() { Id = 1, Age = 18, Name = "1. László", Position = "Janitor", TaskId = 1 ,Task = task1},
                new Worker() { Id = 2, Age = 23, Name = "2. László", Position = "IT", TaskId = 3 ,Task = task3},
                new Worker() { Id = 3, Age = 38, Name = "3. László", Position = "IT", TaskId = 3 ,Task = task3},
                new Worker() { Id = 4, Age = 24, Name = "4. László", Position = "Accountant", TaskId = 2 ,Task = task2},
                new Worker() { Id = 5, Age = 55, Name = "5. László", Position = "CEO", TaskId = 4 ,Task = task4},
                new Worker() { Id = 6, Age = 23, Name = "6. László", Position = "IT", TaskId = 3 ,Task = task3},
                new Worker() { Id = 7, Age = 38, Name = "7. László", Position = "IT", TaskId = 3 ,Task = task3},
                new Worker() { Id = 8, Age = 18, Name = "8. László", Position = "Janitor", TaskId = 1 ,Task = task1},
                new Worker() { Id = 9, Age = 18, Name = "9. László", Position = "Janitor", TaskId = 1 ,Task = task1},
                new Worker() { Id = 10, Age = 18, Name = "10. László", Position = "Janitor", TaskId = 1 ,Task = task1},
                new Worker() { Id = 11, Age = 18, Name = "11. László", Position = "Lazy Janitor"},
            };

            var prios = new List<Priority>()
            { pri1,pri2,pri3 }.AsQueryable();

            task1.Workers = new List<Worker>() { workersList[0], workersList[7], workersList[8], workersList[9] };
            task2.Workers = new List<Worker>() { workersList[3] };
            task3.Workers = new List<Worker>() { workersList[1], workersList[2], workersList[5], workersList[6] };
            task4.Workers = new List<Worker>() { workersList[4] };

            var tasks = new List<Task>()
            { task1, task2, task3 }.AsQueryable();
            var workers = workersList.AsQueryable();

            mockTaskRepo = new Mock<ITaskRepository<Task>>();
            mockTaskRepo.Setup(x => x.ReadAll()).Returns(tasks);
            mockTaskRepo.Setup(x => x.Read(2)).Returns(tasks.First(x => x.Id == 2));
            mockPrioRepo = new Mock<IPriorityRepository<Priority>>();
            mockPrioRepo.Setup(x => x.ReadAll()).Returns(prios);
            mockPrioRepo.Setup(x => x.Read(3)).Returns(prios.First(x => x.Id == 3));
            mockWorkerRepo = new Mock<IWorkerRepository<Worker>>();
            mockWorkerRepo.Setup(x => x.ReadAll()).Returns(workers);
            mockWorkerRepo.Setup(x => x.Read(1)).Returns(workers.First(x => x.Id == 1));
            //mockWorkerRepo.Setup(x => x.Read(It.IsAny<int>())).Returns<Worker>(x => x);
            logic = new MockLogic(mockTaskRepo.Object, mockWorkerRepo.Object, mockPrioRepo.Object);
        }

        [Test]
        public void GetTaskWithManyWorkersTest()
        {
            var result = logic.TaskLogic.GetTaskWithManyWorkers();
            string janitorExpected = "JanitorTaskTest";
            string ITExpected = "ITTaskTest";


            Assert.That(result.ToList()[0].Description, Is.EqualTo(janitorExpected));
            Assert.That(result.ToList()[1].Description, Is.EqualTo(ITExpected));
        }

        [Test]
        public void GetTaskWithManyWorkersUrgentTest()
        {
            var result = logic.TaskLogic.GetTaskWithManyWorkersUrgent().ToList();
            string expected = "JanitorTaskTest";

            Assert.That(result.ToList()[0].Description, Is.EqualTo(expected));
        }

        [Test]
        public void GetWorkersWithUrgentTaskTest()
        {
            var result = logic.WorkerLogic.GetWorkersWithUrgentTask();

            Assert.Contains("1. László", result.ToList());
            Assert.Contains("8. László", result.ToList());
            Assert.Contains("9. László", result.ToList());
            Assert.Contains("10. László", result.ToList());
        }

        [Test]
        public void GetWorkersWithNoTaskTest()
        {
            var result = logic.WorkerLogic.GetWorkersWithNoTask().ToList();

            Assert.That(result.Contains("11. László"));
        }

        [Test]
        public void GetPriorityWithMostTasksTest()
        {
            var result = logic.PriorityLogic.GetPriorityWithMostTasks().ToList();
            int expected = 2;
            Assert.That(result[0].Tasks.Count == expected);
        }


        [Test]
        public void ReadWorkerTest()
        {
            var result = logic.WorkerLogic.Read(1);

            string expected = "1. László";

            mockWorkerRepo.Verify(x => x.Read(It.IsAny<int>()), Times.Once);
            Assert.That(result.Name, Is.EqualTo(expected));
        }

        [Test]
        public void ReadTaskTest()
        {
            var result = logic.TaskLogic.Read(2);

            string expected = "AccountantTaskTest";

            mockTaskRepo.Verify(x => x.Read(It.IsAny<int>()), Times.Once);
            Assert.That(result.Description, Is.EqualTo(expected));
        }

        [Test]
        public void ReadPriorityTest()
        {
            var result = logic.PriorityLogic.Read(3);

            string expected = "Low";

            mockPrioRepo.Verify(x => x.Read(It.IsAny<int>()), Times.Once);
            Assert.That(result.Value, Is.EqualTo(expected));
        }

        [Test]
        public void DeleteTest()
        {
            logic.WorkerLogic.Delete(1);

            mockWorkerRepo.Verify(x=>x.Delete(It.IsAny<int>()), Times.Once);
        }

        [Test]
        public void CreateTest()
        {
            Task task = new Task() { Id = 5, Description = "CreatedTask" };
            logic.TaskLogic.Create(task);

            mockTaskRepo.Verify(x => x.Create(task), Times.Once);
        }
    }
}
