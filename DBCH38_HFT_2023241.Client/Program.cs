﻿using ConsoleTools;
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

                default:
                    ConsoleMenu.Close();
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

                default:
                    ConsoleMenu.Close();
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
                    Console.WriteLine($"\nDesc.: {task.Description} || Type: {task.Type}");

                    Console.ReadLine();
                    break;
                case "Priority":
                    Console.Write("Enter Priority ID: ");
                    Priority prio = rest.Get<Priority>(int.Parse(Console.ReadLine()), "priority");
                    Console.WriteLine($"\nValue: {prio.Value}");

                    Console.ReadLine();
                    break;
                case "Worker":
                    Console.Write("Enter Worker ID: ");
                    Worker worker = rest.Get<Worker>(int.Parse(Console.ReadLine()), "worker");
                    Console.WriteLine($"\nName: {worker.Name} || Pos.: {worker.Position} || Age: {worker.Age}");

                    Console.ReadLine();
                    break;

                default:
                    ConsoleMenu.Close();
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
                    Console.WriteLine($"\nSelected Task: (Desc.: {task.Description} || Type: {task.Type})");
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
                    Console.WriteLine($"\nSelected Priority: (Value: {prio.Value})");
                    Console.WriteLine("Enter New Value (Leave Empty If Unchanged): ");
                    string newVal = Console.ReadLine();
                    prio.Value= (newVal==string.Empty)?prio.Value:newVal;

                    rest.Put(prio, "priority");
                    break;
                case "Worker":
                    Console.Write("Enter Worker ID: ");
                    Worker worker = rest.Get<Worker>(int.Parse(Console.ReadLine()), "worker");
                    Console.WriteLine($"\nSelected Worker: (Name: {worker.Name} || Pos.: {worker.Position} || Age: {worker.Age})");
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

                default:
                    ConsoleMenu.Close();
                    break;
            }
        }

        static void Delete (string entity) 
        {
            int id = 0;
            switch (entity)
            {
                case "Task":
                    Console.Write("Enter Task ID: ");
                    id = int.Parse(Console.ReadLine());

                    rest.Delete(id, "task");
                    break;
                case "Priority":
                    Console.Write("Enter Priority ID: ");
                    id = int.Parse(Console.ReadLine());

                    rest.Delete(id, "task");
                    break;
                case "Worker":
                    Console.Write("Enter Worker ID: ");
                    id = int.Parse(Console.ReadLine());

                    rest.Delete(id, "task");
                    break;

                default:
                    ConsoleMenu.Close();
                    break;
            }
        }

        static void Main(string[] args)
        {
            rest = new RestService("http://localhost:1542/");

            //TODO: test + add more dbseed
            

            var taskSub = new ConsoleMenu(args, level: 1)
                .Add("Create", ()=>Create("Task"))
                .Add("Read", () => Read("Task"))
                .Add("ReadAll", () => ReadAll("Task"))
                .Add("Update", () => Update("Task"))
                .Add("Delete", () => Delete("Task"))
                .Add("Exit", () => Environment.Exit(0));

            var prioSub = new ConsoleMenu(args, level: 1)
                .Add("Create", () => Create("Priority"))
                .Add("Read", () => Read("Priority"))
                .Add("ReadAll", () => ReadAll("Priority"))
                .Add("Update", () => Update("Priority"))
                .Add("Delete", () => Delete("Priority"))
                .Add("Exit", ()=> Environment.Exit(0));

            var workerSub = new ConsoleMenu(args, level: 1)
                .Add("Create", () => Create("Worker"))
                .Add("Read", () => Read("Worker"))
                .Add("ReadAll", () => ReadAll("Worker"))
                .Add("Update", () => Update("Worker"))
                .Add("Delete", () => Delete("Worker"))
                .Add("Exit", () => Environment.Exit(0)) ;

            var menu = new ConsoleMenu(args, level: 0)
                .Add("Tasks", () => taskSub.Show())
                .Add("Priorities", () => prioSub.Show())
                .Add("Workers", () => workerSub.Show())
                .Add("Exit", () => Environment.Exit(0));

            menu.Show();

            //TODO: 5 noncrud
            //TODO: logic exc handle
        }
    }
}
