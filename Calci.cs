using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<string> toDoList = new List<string>();
        int choice;

        do
        {
            Console.Clear();
            Console.WriteLine("Simple To-Do List");
            Console.WriteLine("=================\n");
            Console.WriteLine("1. View Tasks");
            Console.WriteLine("2. Add Task");
            Console.WriteLine("3. Remove Task");
            Console.WriteLine("4. Exit");
            Console.Write("\nEnter your choice: ");

            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        ViewTasks(toDoList);
                        break;
                    case 2:
                        AddTask(toDoList);
                        break;
                    case 3:
                        RemoveTask(toDoList);
                        break;
                    case 4:
                        Console.WriteLine("\nGoodbye!");
                        break;
                    default:
                        Console.WriteLine("\nInvalid choice. Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("\nPlease enter a valid number.");
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();

        } while (choice != 4);
    }

    static void ViewTasks(List<string> toDoList)
    {
        Console.Clear();
        Console.WriteLine("To-Do List");
        Console.WriteLine("==========");

        if (toDoList.Count == 0)
        {
            Console.WriteLine("\nNo tasks available.");
        }
        else
        {
            for (int i = 0; i < toDoList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {toDoList[i]}");
            }
        }
    }

    static void AddTask(List<string> toDoList)
    {
        Console.Clear();
        Console.WriteLine("Add a Task");
        Console.WriteLine("==========");
        Console.Write("\nEnter the task: ");
        string task = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(task))
        {
            toDoList.Add(task);
            Console.WriteLine("\nTask added successfully!");
        }
        else
        {
            Console.WriteLine("\nTask cannot be empty.");
        }
    }

    static void RemoveTask(List<string> toDoList)
    {
        Console.Clear();
        Console.WriteLine("Remove a Task");
        Console.WriteLine("=============");

        if (toDoList.Count == 0)
        {
            Console.WriteLine("\nNo tasks to remove.");
            return;
        }

        ViewTasks(toDoList);
        Console.Write("\nEnter the task number to remove: ");

        if (int.TryParse(Console.ReadLine(), out int taskNumber) && taskNumber > 0 && taskNumber <= toDoList.Count)
        {
            string removedTask = toDoList[taskNumber - 1];
            toDoList.RemoveAt(taskNumber - 1);
            Console.WriteLine($"\nTask '{removedTask}' removed successfully!");
        }
        else
        {
            Console.WriteLine("\nInvalid task number. Please try again.");
        }
    }
}
