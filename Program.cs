using System;
using static System.Console;
using FishFeedingTask.Models;
using System.Threading;
using FishFeedingTask.Data;
using System.Linq;
using System.Collections.Generic;

namespace FishFeedingTask
{
    class Program
    {

        static FishFeedingContext Context = new FishFeedingContext();
        // context este o instanta-obiect al clasei FishFeedingContext

        static void Main(string[] args)
        {

            CursorVisible = false;

            bool appliationRunning = true;

            do
            {
                WriteLine("1. Add task");
                WriteLine("2. List tasks");
                WriteLine("3. Exit");

                ConsoleKeyInfo input = ReadKey(true);

                Clear();

                switch (input.Key)
                {
                    case ConsoleKey.D1:

                        AddTask();

                        break;

                    case ConsoleKey.D2:

                        SearchTask();

                        break;

                    case ConsoleKey.D3:

                        appliationRunning = false;

                        break;
                }
                Clear();

            } while (appliationRunning);
        }

        private static void SearchTask()
        {
            CursorVisible = false;
            Clear();

            List<Task> tasks = Context.Tasks.ToList();

            WriteLine($"{"Task",-30 }{"Due Date",-40}");
            WriteLine("================================================================");

            foreach (Task task in tasks)
            {
                WriteLine($"{task.Name,-30 }{task.DueDate.ToString(),-40} ");
            }

            ReadKey();
            Clear();
        }

        private static void AddTask()
        {
            WriteLine("Name:  ");
            WriteLine("Due date:  ");
            SetCursorPosition(6, 0);
            string name = ReadLine();
            SetCursorPosition(10, 1);
            DateTime dueDate = DateTime.Parse(ReadLine());
            var task = new Task(name, dueDate);
            SaveTask(task);
            Clear();
            WriteLine("Task registered");
            Thread.Sleep(2000);
            Clear();
        }

        private static void SaveTask(Task  task)
        {
            Context.Tasks.Add(task);

            Context.SaveChanges();
        }

        private static Task FindTasks(string name) 
        {
            return   Context.Tasks.FirstOrDefault(x => x.Name == name);
        }
    }
}
