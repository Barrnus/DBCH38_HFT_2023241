using DBCH38_HFT_2023241.Models;
using System;
using System.Collections.Generic;

namespace DBCH38_HFT_2023241.Client
{
    internal class Program
    {
        static RestService rest;
        static void Create(string entity)
        {
            switch (entity)
            {
                case "Task":
                    Console.Write("Enter Task Description: ");
                    string desc = Console.ReadLine();
                    Console.Write("\nEnter Task Type: ");
                    string type = Console.ReadLine();
                    rest.Post(new Models.Task() {Description=desc, Type=type },"task");
                    break;
                case "Priority":
                    Console.Write("Enter Priority Value: ");
                    string val = Console.ReadLine();
                    rest.Post(new Priority() { Value=val}, "priority");
                    break;
                case "Worker":
                    Console.Write("Enter Worker Name: ");
                    string name = Console.ReadLine();
                    Console.Write("\nEnter Worker Position: ");
                    string pos = Console.ReadLine();
                    Console.Write("\nEnter Worker Age: ");
                    int age = int.Parse(Console.ReadLine());
                    rest.Post(new Worker() { Name=name, Age=age, Position=pos }, "worker");
                    break;
            }
        }

        static void ReadAll(string entity)
        {
            switch (entity)
            {
                case "Task":
                    List<Models.Task> tasks = rest.Get<Models.Task>("task");
                    foreach (var item in tasks)
                    {
                        Console.WriteLine($"Desc.: {item.Description} || Type: {item.Type}");
                    }
                    Console.ReadLine();
                    break;
                case "Priority":
                    List<Priority> prio = rest.Get<Priority>("priority");
                    foreach (var item in prio)
                    {
                        Console.WriteLine($"Value: {item.Value}");
                    }
                    Console.ReadLine();
                    break;
                case "Worker":
                    List<Worker> workers = rest.Get<Worker>("worker");
                    foreach (var item in workers)
                    {
                        Console.WriteLine($"Name: {item.Name} || Pos.: {item.Position} || Age: {item.Age}");
                    }
                    Console.ReadLine();
                    break;
            }
        }

        static void Read(string entity)
        {
            switch (entity)
            {
                case "Task":
                    Console.Write("Enter Task ID: ");
                    Models.Task task = rest.Get<Models.Task>(int.Parse(Console.ReadLine()), "task");
                    Console.WriteLine($"Desc.: {task.Description} || Type: {task.Type}");

                    Console.ReadLine();
                    break;
                case "Priority":
                    Console.Write("Enter Priority ID: ");
                    Priority prio = rest.Get<Priority>(int.Parse(Console.ReadLine()), "priority");
                    Console.WriteLine($"Value: {prio.Value}");

                    Console.ReadLine();
                    break;
                case "Worker":
                    Console.Write("Enter Worker ID: ");
                    Worker worker = rest.Get<Worker>(int.Parse(Console.ReadLine()), "worker");
                    Console.WriteLine($"Name: {worker.Name} || Pos.: {worker.Position} || Age: {worker.Age}");

                    Console.ReadLine();
                    break;
            }
        }

        static void Update(string entity)
        {
            switch (entity)
            {
                case "Task":
                    Console.Write("Enter Task ID: ");
                    Models.Task task = rest.Get<Models.Task>(int.Parse(Console.ReadLine()), "task");
                    Console.WriteLine($"Selected Task: (Desc.: {task.Description} || Type: {task.Type})");
                    Console.WriteLine("Enter New Desc (Leave Empty If Unchanged): ");
                    string newDesc = Console.ReadLine();
                    task.Description = (newDesc == string.Empty) ? task.Description:newDesc;
                    Console.WriteLine("Enter New Type (Leave Empty If Unchanged): ");
                    string newType = Console.ReadLine();
                    task.Type = (newType == string.Empty) ? task.Type : newType;

                    rest.Put(task, "task");
                    break;
                case "Priority":
                    Console.Write("Enter Priority ID: ");
                    Priority prio = rest.Get<Priority>(int.Parse(Console.ReadLine()), "priority");
                    Console.WriteLine($"Selected Priority: (Value: {prio.Value})");
                    Console.WriteLine("Enter New Value (Leave Empty If Unchanged): ");
                    string newVal = Console.ReadLine();
                    prio.Value= (newVal==string.Empty)?prio.Value:newVal;

                    rest.Put(prio, "priority");
                    break;
                case "Worker":
                    Console.Write("Enter Worker ID: ");
                    Worker worker = rest.Get<Worker>(int.Parse(Console.ReadLine()), "worker");
                    Console.WriteLine($"Selected Worker: (Name: {worker.Name} || Pos.: {worker.Position} || Age: {worker.Age})");
                    Console.WriteLine("Enter New Name (Leave Empty If Unchanged): ");
                    string newName = Console.ReadLine();
                    worker.Name = (newName == string.Empty)?worker.Name:newName;
                    Console.WriteLine("Enter New Position (Leave Empty If Unchanged): ");
                    string newPos = Console.ReadLine();
                    worker.Position = (newPos == string.Empty) ? worker.Position : newName;
                    Console.WriteLine("Enter New Age (Leave Empty If Unchanged): ");
                    string newAge = Console.ReadLine();
                    worker.Age = (newAge == string.Empty) ? worker.Age : int.Parse(newAge);

                    rest.Put(worker, "worker");
                    break;
            }
        }

        static void Delete (string entity) 
        {
            switch (entity)
            {
                case "Task":
                    break;
                case "Priority":
                    break;
                case "Worker":
                    break;
            }
        }

        static void Main(string[] args)
        {
            rest = new RestService("http://localhost:1542/");

            //TODO: 5 noncrud
            //TODO: menu
        }
    }
}
