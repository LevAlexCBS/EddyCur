using System;
using System.Collections.Generic;
using System.Text;

namespace EddyCur
{
    public static class SignalGenerator
    {
        private static string terminator = "\r\n";

        private static string Channel1 => "OUTPUT1:";

        private static string Channel2 => "OUTPUT2:";

        private static string State => "STATE";

        private static string Space => " ";

        private static string ON => "ON";

        private static string OFF => "OFF";

        public static string SetFrequencyCommand(int channel, double frequency)
        {
            return $"SOUR{channel}:FREQ: FIX {frequency}" + terminator;
        }

        public static string StateOutputCommand(int channel, bool state)
        {
            string command = string.Empty;
            if (channel == 1)
            {
                command = Channel1;
            }
            else if (channel == 2)
            {
                command = Channel2;
            }

            command += State + Space;

            if (state)
            {
                command += ON;
            }
            else
            {
                command += OFF;
            }

            command += terminator;

            return command;
        }

        public static string ResetCommand()
        {
            return "GEN:RST" + terminator;
        }
    }
}
