using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace SimpleMultiThreadApp
{
    class Printer
    {
        public void PrintNumbers()
        {
            // Вывести информацию о потоке.
            Console.WriteLine("-> {0} is.executing PrintNumbers()",
            Thread.CurrentThread.Name);
            // Вывести числа.
            Console.Write("Your numbers: ");
            for (int i = 0; i < 10; i++)
            {
                Console.Write("{0}, ", i);
                Thread.Sleep(2000);
            }
            Console.WriteLine();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** The Amazing Thread App *****\n");
            Console.Write("Do you want [1] or [2] threads? ");
            string threadCount = Console.ReadLine();
            // Назначить имя текущему потоку.
            Thread primaryThread = Thread.CurrentThread;
            primaryThread.Name = "Primary";
            // Вывести информацию о потоке.
            Console.WriteLine("-> {0} is executingMain()",
            Thread.CurrentThread.Name);
            // Создать рабочий класс.
            Printer p = new Printer();
            switch (threadCount)
            {
                case "2":
                    // Создать поток.
                    Thread backgroundThread = new Thread(new ThreadStart(p.PrintNumbers));
                    backgroundThread.Name = "Secondary";
                    backgroundThread.Start();
                    break;
                case "1": p.PrintNumbers();
                    break;
                default:
                    Console.WriteLine("I don't know what you want...you get 1 thread.");
                    goto case "1"; // Для всех остальных вариантов ввода принимается один поток.
            }
            // Выполнить некоторую дополнительную работу.
            MessageBox.Show("I'm busy!", "Work on main thread...");
            Console.ReadLine();

        }
    }
}
