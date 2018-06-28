using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp28
{

    
    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person() { FirstName = "xyz", Age = 21, Roll = 12 };

            //Xyz,21,12
            Console.WriteLine(p);
            Console.ReadLine();
        }

        private static void Thread()
        {
            var start = Stopwatch.StartNew();
            var hotelBooking = Task.Factory.StartNew(() =>
            {
                System.Threading.Thread.Sleep(3000);
                // Console.WriteLine("Hotel booked id 1");
            });


            var car = Task.Factory.StartNew(() =>
            {
                System.Threading.Thread.Sleep(1000);
                // Console.WriteLine("car booked id 1");
            });
            var fliggt = Task.Factory.StartNew(() =>
            {
                System.Threading.Thread.Sleep(4000);
                ///  Console.WriteLine("fligh     booked id 1");
            });


            // Task.WaitAll(new[] { hotelBooking, car, fliggt });

            fliggt.ContinueWith(x =>
            { 
                Console.WriteLine("Flight booked");
                hotelBooking.ContinueWith((z) =>
                {
                    Console.WriteLine("Car is booked");

                });
            });
            Console.WriteLine(start.ElapsedMilliseconds);
            Console.ReadLine();
        }

        private static void ThreadDemo()
        {
            //Main Thread
            Func<int, int, int> add = (x, y) => Sum(x, y);

            IAsyncResult r = add.BeginInvoke(1, 2, null, null);
            Console.WriteLine(" Main Thread id={0}", System.Threading.Thread.CurrentThread.ManagedThreadId);
            int result = add.EndInvoke(r);


            Console.WriteLine(result);
            Console.ReadLine();
        }

        public static int Sum(int a, int b)
        {
            Console.WriteLine(" Sum Thread id={0}", System.Threading.Thread.CurrentThread.ManagedThreadId);
            return a + b;
        }

        private static void DoingSomething()
        {
            Console.WriteLine(" Worker Thread id={0}", System.Threading.Thread.CurrentThread.ManagedThreadId);
            System.Threading.Thread.Sleep(5000);
            Console.WriteLine("Done");
        }
    }
}
