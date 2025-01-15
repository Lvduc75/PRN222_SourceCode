namespace TaskDemostration01
{
    class Program
    {
        static void PrintNumber(string message)
        {
            for (int i = 0; i <= 5; i++)
            {
                Console.WriteLine($"{message}:{i}");
                Thread.Sleep(1000);
            }
        }
        static void Main()
        {
            Thread.CurrentThread.Name = "Main";
            // Create a task by using lamda expression
            Task task01 = new Task(() => PrintNumber("Task01"));
            task01.Start();
            // Create a task by using delegate and run the task
            Task task02 = Task.Run(delegate { PrintNumber("Task02"); });
            // Create a task by using a Action delegate
            Task task03 = new Task(new Action(() => { PrintNumber("Task03"); }));
            task03.Start();
            Console.WriteLine($"Thread '{Thread.CurrentThread.Name}'");
            Console.ReadKey();
        }
    }
}
