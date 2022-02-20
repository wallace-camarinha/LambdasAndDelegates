using System;

namespace LambdasAndDelegates
{
    public delegate int BizRulesDelegate(int x, int y);

    class Program
    {
        static void Main(string[] args)
        {
            // You can use it as a lambda
            //BizRulesDelegate addDel = (x, y) => x + y;
            //BizRulesDelegate multiplyDel = (x, y) => x * y;

            // Or you can use as a local function (Recommended)
            // It works with the delegate because it has the same signature
            int addDel(int x, int y) => x + y;
            int multiplyDel(int x, int y) => x * y;

            var data = new ProcessData();
            data.Process(2, 3, multiplyDel);

            var worker = new Worker();

            // Using a lambda instead of a stand-alone method as EventHandler
            worker.WorkPerformed += (s, e) => Console.WriteLine($"Worked {e.Hours} hour(s).\nDoing: {e.WorkType}\n");
            worker.WorkCompleted += (s, e) => Console.WriteLine("Work is completed!");

            worker.DoWork(8, WorkType.GenerateReports);

            Console.Read();
        }

        //static void Worker_WorkPerformed(object sender, WorkPerformedEventArgs e)
        //{
        //    Console.WriteLine("Worked: " + e.Hours + " hour(s) doing: " + e.WorkType);
        //}

        //static void Worker_WorkCompleted(object sender, EventArgs e)
        //{
        //    Console.WriteLine("Work is complete!");
        //}
    }
}
