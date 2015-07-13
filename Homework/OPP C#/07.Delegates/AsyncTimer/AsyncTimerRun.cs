using System;

namespace AsyncTimer
{
    class AsyncTimerRun
    {
        public static void PrintRandNumber(int i)
        {
            Console.Write(i);
        }

        public static void PrintRandomSymbol(int i)
        {
            Console.Write("{0}",(char)i);
        }

        static void Main()
        {
            
            AsyncTimer timer1 = new AsyncTimer(PrintRandNumber,10,400);
            timer1.Execute();
            AsyncTimer timer2 = new AsyncTimer(PrintRandomSymbol, 8, 600);
            timer2.Execute();
        }
    }
}
