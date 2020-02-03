using System;
using System.Collections.Generic;
using System.Text;

namespace EddyCur
{
    public static class DigitalPins
    {
        public static string SetLEDCommand(int number, bool state)
        {
            return $"DIG:PIN LED{number},{(state ? "1" : "0")}\r\n";
        }
    }
}
