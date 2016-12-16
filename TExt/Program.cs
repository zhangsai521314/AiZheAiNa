using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static DuiLiYanCeShi.MyQueue;

namespace DuiLiYanCeShi
{
    class Program
    {
        private static object lockObject = new Object();
        static void Main(string[] args)
        {
            Thread threads = new Thread(s);
            threads.IsBackground = true;
            threads.Start();

            Thread threadg = new Thread(g);
            threadg.IsBackground = true;
            threadg.Start();
            Console.ReadKey();
        }
        public static void s()
        {
            int i = 1;
            while (true)
            {
                Console.WriteLine("加入了:" + i);
                MyQueue.Instance.AddQueue(i.ToString(), (i + 1).ToString(), (i + 2).ToString(), (i + 3).ToString(), (i + 4).ToString());
                Console.WriteLine("加入结束了:" + i);
                i++;
            }
        }

        public static void g()
        {
            while (true)
            {
                ConcurrentQueue<QueueInfo> q = MyQueue.Instance.ListQueue;
                if (q.Count > 0)
                {
                    lock (lockObject)
                    {
                        QueueInfo queueinfo = null;
                        Console.WriteLine("队列数量：" + q.Count);
                        q.TryDequeue(out queueinfo);
                        Console.WriteLine("队列数量减少后：" + q.Count);
                    }
                }
            }
        }

    }

















}
