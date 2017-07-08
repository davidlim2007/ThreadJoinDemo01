using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ThreadJoinDemo01
{
    class Program
    {
        private static void StartThread()
        {
            // The following code will initiate a new thread with 
            // WorkThreadFunction() as the entry point method.
            // Note that WorkThreadFunction() does not take any parameters
            // hence the use of the ThreadStart delegate.
            m_thread = new Thread(new ThreadStart(WorkThreadFunction));

            // Note that the above call can be simplified to :
            // Thread thread = new Thread(WorkThreadFunction);
            // This is because the compile is able to deduce that
            // WorkThreadFunction() does not take any parameter and so
            // the ThreadStart delegate type is implied.
            m_thread.Start();
        }

        // WorkThreadFunction() is the entry-point to a thread.
        // i.e. when the thread starts, it starts with WorkThreadFunction().
        private static void WorkThreadFunction()
        {
            Thread.Sleep(5000);
        }

        private static void WaitForThreadToEnd()
        {
            m_thread.Join();
        }

        static void Main(string[] args)
        {
            StartThread();
            WaitForThreadToEnd();
        }

        private static Thread m_thread = null;
    }
}