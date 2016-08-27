using System;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelProgrammingDemo
{
    /// <summary>
    /// This demonstrates several ways to create a basic task. 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //CreateBasicTasks();
                //Console.WriteLine("============================================");
                //CreateBasicTasksWithOneParameter();
                //Console.WriteLine("============================================");

                //CreateTasksAndGetResults();
                //CreateTaskAndGetResultWithTaskFactory();

                //MonitorCancellationByPolling();
                //MonitorCancellationWithDelegate();
                //MonitorCancellationWithWaitHandle();

                //CancelMultipleTasks();

                //CreateCompositeCancellationToken();

                //DetermineIfTaskWasCancelled();

                //PutTaskToSleepUsingCancellationTokenWaitHandle();

                // create the cancellation token source 
                var tokenSource = new CancellationTokenSource();
                // create the cancellation token 
                var token = tokenSource.Token;

                // create and start the first task, which we will let run fully 
                var task = CreateTask(token);
                task.Start();

                // wait for the task 
                Console.WriteLine("Waiting for task to complete.");
                task.Wait();
                Console.WriteLine("Task Completed.");

                // create and start another task 
                task = CreateTask(token);
                task.Start();

                Console.WriteLine("Waiting 2 secs for task to complete.");
                bool completed = task.Wait(2000);
                Console.WriteLine("Wait ended - task completed: {0}", completed);

                // create and start another task 
                task = CreateTask(token);
                task.Start();

                Console.WriteLine("Waiting 2 secs for task to complete.");
                completed = task.Wait(2000, token);
                Console.WriteLine("Wait ended - task completed: {0} task cancelled {1}",
                    completed, task.IsCanceled); 

                // wait for input before exiting 
                Console.WriteLine("Main method complete. Press enter to finish.");
                Console.ReadLine(); 
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        /// <summary>
        /// This is the best way to put a Task to sleep
        /// </summary>
        private static void PutTaskToSleepUsingCancellationTokenWaitHandle()
        {
            // create the cancellation token source 
            var tokenSource = new CancellationTokenSource();
            // create the cancellation token 
            var token = tokenSource.Token;

            // create the first task, which we will let run fully 
            var task1 = new Task(() =>
                                     {
                                         for (int i = 0; i < Int32.MaxValue; i++)
                                         {
                                             // put the task to sleep for 10 seconds 
                                             // We can call Thread.Sleep here but it won't cancel immediately.
                                             // SpinWait won't give its turn on the CPU. Shouldn't use it ever!
                                             bool cancelled = token.WaitHandle.WaitOne(10000);
                                             // print out a message 
                                             Console.WriteLine("Task 1 - Int value {0}. Cancelled? {1}",
                                                               i, cancelled);
                                             // check to see if we have been cancelled 
                                             if (cancelled)
                                             {
                                                 throw new OperationCanceledException(token);
                                             }
                                         }
                                     }, token);

            // start task 
            task1.Start();

            // wait for input before exiting 
            Console.WriteLine("Press enter to cancel token.");
            Console.ReadLine();

            // cancel the token 
            tokenSource.Cancel();
        }

        private static void DetermineIfTaskWasCancelled()
        {
            // create the cancellation token source 
            var tokenSource1 = new CancellationTokenSource();
            // create the cancellation token 
            var token1 = tokenSource1.Token;

            // create the first task, which we will let run fully 
            var task1 = new Task(() =>
                                     {
                                         for (int i = 0; i < int.MaxValue; i++)
                                         {
                                             token1.ThrowIfCancellationRequested();
                                             Console.WriteLine("Task 1 - Int value {0}", i);
                                         }
                                     }, token1);

            // create the second cancellation token source 
            var tokenSource2 = new CancellationTokenSource();
            // create the cancellation token 
            var token2 = tokenSource2.Token;

            // create the second task, which we will cancel 
            var task2 = new Task(() =>
                                     {
                                         for (int i = 0; i < int.MaxValue; i++)
                                         {
                                             token2.ThrowIfCancellationRequested();
                                             Console.WriteLine("Task 2 - Int value {0}", i);
                                         }
                                     }, token2);

            // start all of the tasks 
            task1.Start();
            task2.Start();

            Console.ReadLine();
            // cancel the second token source 
            tokenSource2.Cancel();

            // write out the cancellation detail of each task 
            // Note: Doesn't work very well if I have the ReadLine statement before Cancel.
            Console.WriteLine("Task 1 cancelled? {0}", task1.IsCanceled);
            Console.WriteLine("Task 2 cancelled? {0}", task2.IsCanceled);
        }

        private static void CreateCompositeCancellationToken()
        {
            // create the cancellation token sources 
            var tokenSource1 = new CancellationTokenSource();
            var tokenSource2 = new CancellationTokenSource();
            var tokenSource3 = new CancellationTokenSource();

            // create a composite token source using multiple tokens 
            var compositeSource = CancellationTokenSource.CreateLinkedTokenSource(tokenSource1.Token, tokenSource2.Token,
                                                                                  tokenSource3.Token);

            // create a cancellable task using the composite token 
            var task = new Task(() =>
                                    {
                                        Console.WriteLine("Task started!");

                                        // wait until the token has been cancelled 
                                        compositeSource.Token.WaitHandle.WaitOne();
                                        // throw a cancellation exception  
                                        throw new OperationCanceledException(compositeSource.Token);
                                    }, compositeSource.Token);

            // start the task 
            Console.WriteLine("Press enter to start task");
            Console.WriteLine("Press enter again to cancel task");
            Console.ReadLine();
            task.Start();

            Console.ReadLine();
            // cancel one of the original tokens 
            tokenSource2.Cancel();
        }

        private static void CancelMultipleTasks()
        {
            // create the cancellation token source 
            var tokenSource = new CancellationTokenSource();
            // create the cancellation token 
            var token = tokenSource.Token;

            // create the tasks 
            var task1 = new Task(() =>
                                     {
                                         for (int i = 0; i < int.MaxValue; i++)
                                         {
                                             token.ThrowIfCancellationRequested();
                                             Console.WriteLine("Task 1 - Int value {0}", i);
                                         }
                                     }, token);

            var task2 = new Task(() =>
                                     {
                                         for (int i = 0; i < int.MaxValue; i++)
                                         {
                                             token.ThrowIfCancellationRequested();
                                             Console.WriteLine("Task 2 - Int value {0}", i);
                                         }
                                     }, token);

            // wait for input before we start the tasks 
            Console.WriteLine("Press enter to start tasks");
            Console.WriteLine("Press enter again to cancel tasks");
            Console.ReadLine();

            // start the tasks 
            task1.Start();
            task2.Start();

            // read a line from the console. 
            Console.ReadLine();
            // cancel the task 
            Console.WriteLine("Cancelling tasks");
            tokenSource.Cancel();
        }

        private static void MonitorCancellationWithWaitHandle()
        {
            // create the cancellation token source 
            var tokenSource = new CancellationTokenSource();

            // create the cancellation token 
            var token = tokenSource.Token;

            // create the task 
            var task1 = new Task(() =>
                                     {
                                         for (int i = 0; i < int.MaxValue; i++)
                                         {
                                             if (token.IsCancellationRequested)
                                             {
                                                 Console.WriteLine("Task cancel detected");
                                                 throw new OperationCanceledException(token);
                                             }
                                             Console.WriteLine("Int value {0}", i);
                                         }
                                     }, token);

            // create a second task that will use the wait handle 
            var task2 = new Task(() =>
                                     {
                                         // wait on the handle 
                                         token.WaitHandle.WaitOne();
                                         // write out a message 
                                         Console.WriteLine(">>>>> Wait handle released");
                                     });


            // wait for input before we start the task 
            Console.WriteLine("Press enter to start task [Wait Handle]");
            Console.WriteLine("Press enter again to cancel task");
            Console.ReadLine();

            // start the tasks 
            task1.Start();
            task2.Start();

            // read a line from the console. 
            Console.ReadLine();

            // cancel the task 
            Console.WriteLine("Cancelling task");
            tokenSource.Cancel();
        }

        private static void MonitorCancellationWithDelegate()
        {
            // create the cancellation token source 
            var tokenSource = new CancellationTokenSource();

            // create the cancellation token 
            var token = tokenSource.Token;

            // create the task 
            var task = new Task(() =>
                                    {
                                        for (int i = 0; i < int.MaxValue; i++)
                                        {
                                            if (token.IsCancellationRequested)
                                            {
                                                Console.WriteLine("Task cancel detected");
                                                throw new OperationCanceledException(token);
                                            }
                                            Console.WriteLine("Int value {0}", i);
                                        }
                                    }, token);

            // register a cancellation delegate 
            token.Register(() => Console.WriteLine("Cancel delegate invoked!\n"));

            // wait for input before we start the task 
            Console.WriteLine("Press enter to start task [Delegate]");
            Console.WriteLine("Press enter again to cancel task");
            Console.ReadLine();

            // start the task 
            task.Start();

            // read a line from the console. 
            Console.ReadLine();

            // cancel the task 
            Console.WriteLine("Cancelling task");
            tokenSource.Cancel();
        }

        private static void MonitorCancellationByPolling()
        {
            // create the cancellation token source 
            var tokenSource = new CancellationTokenSource();

            // create the cancellation token 
            var token = tokenSource.Token;

            // create the task 
            var task = new Task(() =>
                                    {
                                        for (int i = 0; i < int.MaxValue; i++)
                                        {
                                            // Poll the IsCancellationRequested property.
                                            if (token.IsCancellationRequested)
                                            {
                                                Console.WriteLine("Task cancel detected");
                                                throw new OperationCanceledException(token);
                                            }
                                            Console.WriteLine("Int value {0}", i);
                                        }
                                    }, token);

            // wait for input before we start the task 
            Console.WriteLine("Press enter to start task [Polling]");
            Console.WriteLine("Press enter again to cancel task");
            Console.ReadLine();

            // start the task 
            task.Start();

            // read a line from the console. 
            Console.ReadLine();

            // cancel the task 
            Console.WriteLine("Cancelling task");
            tokenSource.Cancel();
        }

        private static void CreateTaskAndGetResultWithTaskFactory()
        {
            // Create the task 
            var task1 = Task.Factory.StartNew<int>(() =>
                                                       {
                                                           int sum = 0;
                                                           for (int i = 0; i < 200; i++)
                                                           {
                                                               sum += i;
                                                           }
                                                           return sum;
                                                       });

            // Write out the result 
            Console.WriteLine("Result 1: Sum of 1 to 200 is {0}", task1.Result);
        }

        private static void CreateTasksAndGetResults()
        {
            // Create the task without using state
            var task1 = new Task<int>(() =>
                                          {
                                              int sum = 0;
                                              for (int i = 0; i < 100; i++)
                                              {
                                                  sum += i;
                                              }
                                              return sum;
                                          });

            // Start the task 
            task1.Start();

            // Write out the result 
            Console.WriteLine("Result 1: Sum of 1 to 100 is {0}", task1.Result);

            // Create the task using state, obj = 100
            var task2 = new Task<int>(obj =>
                                          {
                                              int sum = 0;
                                              int max = (int) obj;
                                              for (int i = 0; i < max; i++)
                                              {
                                                  sum += i;
                                              }
                                              return sum;
                                          }, 100);

            // Start the task 
            task2.Start();

            // Write out the result 
            Console.WriteLine("Result 2: Sum of 1 to 100 is {0}", task2.Result);
        }

        private static void CreateBasicTasksWithOneParameter()
        {
            // Use an Action delegate and a named method 
            var task1 = new Task(new Action<object>(PrintMessage), "First task");

            // Anonymous delegate 
            var task2 = new Task(delegate(object obj) { PrintMessage(obj); }, "Second task");

            // Lambda expression and a named method 
            // note that parameters to a lambda don’t need  
            // to be quoted if there is only one parameter 
            var task3 = new Task((obj) => PrintMessage(obj), "Third task");

            // Lambda expression and an anonymous method 
            var task4 = new Task((obj) => { PrintMessage(obj); }, "Fourth task");

            // Method group
            var task5 = new Task(PrintMessage, "Fifth task");

            task1.Start();
            task2.Start();
            task3.Start();
            task4.Start();
            task5.Start();
        }

        private static void CreateBasicTasks()
        {
            // Use an Action delegate and a named method 
            var task1 = new Task(new Action(PrintMessage));

            // Use a anonymous delegate 
            var task2 = new Task(delegate { PrintMessage(); });

            // Use a lambda expression and a named method 
            var task3 = new Task(() => PrintMessage());

            // Use a lambda expression and an anonymous method 
            var task4 = new Task(() => { PrintMessage(); });

            // Method group
            var task5 = new Task(PrintMessage);

            task1.Start();
            task2.Start();
            task3.Start();
            task4.Start();
            task5.Start();
        }

        static void PrintMessage()
        {
            Console.WriteLine("Hello World");
        }

        static void PrintMessage(object message)
        {
            Console.WriteLine("Message: {0}", message);
        }

        static Task CreateTask(CancellationToken token)
        {
            return new Task(() =>
            {
                for (int i = 0; i < 5; i++)
                {
                    // check for task cancellation 
                    token.ThrowIfCancellationRequested();
                    // print out a message 
                    Console.WriteLine("Task - Int value {0}", i);
                    // put the task to sleep for 1 second 
                    token.WaitHandle.WaitOne(1000);
                }
            }, token);
        } 
    }
}
