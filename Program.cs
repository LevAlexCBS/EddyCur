using System;
using System.Net.Sockets;
using System.Threading;

namespace EddyCur
{
    class Program
    {
        static void Main(string[] args)
        {
            var rp = new RedPitaya("192.168.31.247", 5000);
            
            rp.GeneratorReset();
            rp.SetGeneratorFrequency(2, 5000);
            rp.SetGeneratorStateOutput(2, true);
            rp.SetGeneratorFrequency(2, 5000);

            for (int i = 0; i < 9; i++)
            {
                rp.SetLED(i, true);
                Thread.Sleep(1000);
                rp.SetLED(i, false);
            }
            Console.WriteLine("Hello World!");
            rp.SetGeneratorStateOutput(2, false);
        }
    }
}
