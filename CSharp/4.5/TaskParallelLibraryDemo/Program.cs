using System;
using System.Threading;
using System.Threading.Tasks;

namespace TaskParallelLibraryDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //CreateTask();

            TaskMethod2("Main Thread Task");
            Task<int> task = CreateTask("Task 1");
            task.Start();
            int result = task.Result;
            Console.WriteLine("Result is: {0}", result);

            task = CreateTask("Task 2");
            task.RunSynchronously();
            result = task.Result;
            Console.WriteLine("Result is: {0}", result);

            task = CreateTask("Task 3");
            task.Start();
            while (!task.IsCompleted)
            {
                Console.WriteLine(task.Status);
                Thread.Sleep(TimeSpan.FromSeconds(0.5));
            }
            Console.WriteLine(task.Status);
            result = task.Result;
            Console.WriteLine("Result is: {0}", result);

            Console.Read();
        }

        private static void CreateTask()
        {
            // Method 1: Create a task and start it
            var t1 = new Task(() => TaskMethod1("Task 1"));
            var t2 = new Task(() => TaskMethod1("Task 2"));
            t2.Start();
            t1.Start();

            // Method 2: Using Task.Run()
            Task.Run(() => TaskMethod1("Task 3"));

            // Method 3: Using Task.Factory.StartNew()
            Task.Factory.StartNew(() => TaskMethod1("Task 4"));

            // Method 4: Same as 3 but the task is marked as "long-running", and as a result,
            // the task will be run on a separate thread instead of using a thread pool like those
            // above
            Task.Factory.StartNew(() => TaskMethod1("Task 5"), TaskCreationOptions.LongRunning);

            Thread.Sleep(TimeSpan.FromSeconds(1));
        }

        static void TaskMethod1(string name)
        {
            Console.WriteLine("Task {0} is running on a thread id {1}. Is thread pool thread: {2}", 
                              name, 
                              Thread.CurrentThread.ManagedThreadId, 
                              Thread.CurrentThread.IsThreadPoolThread);
        }

        static Task<int> CreateTask(string name)
        {
            return new Task<int>(() => TaskMethod2(name));
        }

        static int TaskMethod2(string name)
        {
            Console.WriteLine("Task {0} is running on a thread id {1}. Is thread pool thread: {2}",
                              name, 
                              Thread.CurrentThread.ManagedThreadId, 
                              Thread.CurrentThread.IsThreadPoolThread);

            Thread.Sleep(TimeSpan.FromSeconds(2));
            return 42;
        }
    }
}
