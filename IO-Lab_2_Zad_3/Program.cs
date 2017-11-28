using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IO_Lab_2_Zad_3
{
    class Program
    {
        delegate int DelegateType(object arguments);
        static DelegateType delegateSilnia;
        static DelegateType delegateSilniaRek;
        static DelegateType delegateFib;
        static int silnia(object argument)
        {
            int pom = 1;
            for (int i = 1; i <= (int)argument; i++)
                pom *= i;
            return pom;
        }
        static int silniaRek(object arguments)
        {
            if ((int)arguments < 1)
                return 1;
            else
                return (int)arguments * silniaRek((int)arguments - 1);
        }
        static int fib(object arguments)
        {
            if ((int)arguments == 1 || (int)arguments == 2)
                return 1;
            else
                return (fib((int)arguments - 1) + fib((int)arguments - 2));
        }
        static void SCallback(IAsyncResult result)
        {
            Console.WriteLine("Silnia iteracyjnie wykonala sie!");
        }

        static void SRekCallback(IAsyncResult result)
        {
            Console.WriteLine("Silnia rekurencyjnie wykonala sie!");
        }

        static void FibCallback(IAsyncResult result)
        {
            Console.WriteLine("Fibonacci wykonal sie!");
        }
        static void Main(string[] args)
        {
            delegateSilnia = new DelegateType(silnia);
            IAsyncResult ar = delegateSilnia.BeginInvoke(5, new AsyncCallback(SCallback), null);
            int result = delegateSilnia.EndInvoke(ar);

            delegateSilniaRek = new DelegateType(silniaRek);
            IAsyncResult arRek = delegateSilniaRek.BeginInvoke(5, new AsyncCallback(SRekCallback), null);
            int resultRek = delegateSilniaRek.EndInvoke(arRek);

            delegateFib = new DelegateType(fib);
            IAsyncResult arFib = delegateFib.BeginInvoke(5, new AsyncCallback(FibCallback), null);
            int resultFib = delegateFib.EndInvoke(arFib);

            Console.WriteLine("Silnia iteracyjnie: " + result);
            Console.WriteLine("Silnia rekurencyjnie: " + resultRek);
            Console.WriteLine("Fibonacci: " + resultFib);
        }
    }
}
