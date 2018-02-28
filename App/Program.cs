using System;
using Camouflage.Common;
using Camouflage.Common.ThreadManager;

namespace YizhiboZan.App
{
    class Program
    {
        public static ThreadManager threadManager1 = new ThreadManager();
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            
            System.Threading.Thread t = new System.Threading.Thread(threadManagerStart);

            for (int i=0;i<=2000;i++)
            {
                threadManager1.addURL(new Do("http://m.yizhibo.com/l/3pItUFXnmt8IKVvR.html", i)
                {
                    EndEventHandler= EndEventHandler
                });
            }
          
            t.Start();
            Console.ReadKey();
        }

        public static void threadManagerStart()
        {
            threadManager1.Start(8);
            //threadManager2.Start(8);
        }

        public static void EndEventHandler(object sender,EventArgs e)
        {
            Console.WriteLine(sender.ToString());
        }

        
    }
}
