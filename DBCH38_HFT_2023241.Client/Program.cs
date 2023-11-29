using System;
namespace DBCH38_HFT_2023241.Client
{
    internal class Program
    {
        static void Create(string entity)
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

        static void ReadAll(string entity)
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

        static void Read(string entity)
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

        static void Update(string entity)
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
            RestService rest = new RestService("http://localhost:1542/");

            //TODO: 5 noncrud
            //TODO: menu
        }
    }
}
