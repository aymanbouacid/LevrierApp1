using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevrierApp1
{
    internal class Levrier
    {
        private ConsoleColor clr;
        private Mutex mutex;
        private Thread thread;
        private Random random;
        private int numero;


        public void Run()
        {
            random = new Random();
            mutex = new Mutex();
            clr = new ConsoleColor();
            numero = 0;

            for (int i = 0; i < 100; i++) 
            {
                Thread.Sleep(random.Next(50));
                mutex.WaitOne();
                Console.ForegroundColor = clr;
                Console.WriteLine("Levrier" + numero);
                mutex.ReleaseMutex();

            }

            mutex.WaitOne();
            Console.ForegroundColor= clr;
            Console.WriteLine("Levrier" + numero.ToString());
            mutex.ReleaseMutex();
        }
    }

    /*
     namespace Thread1
{
    internal class Work
    {
        private ConsoleColor clr;
        private Mutex mutex;
        private Thread thread;
        private int id;


        public Work(ConsoleColor c,Mutex m, int i)
        {
            clr = c;
            mutex = m;
            id = i;
        }

        public void Run()
        {
            thread = new Thread(new ThreadStart(Run));
            thread.Start();
        }

        private void ptEntree()
        {
            for (int i = 0; i < 50; i++)
            { 
                mutex.WaitOne();
                Console.ForegroundColor = this.clr;
                Console.WriteLine("Bonjour tout le monde!" +id);
                mutex.ReleaseMutex();

            }
        }
    }
}
     */
}
