using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace EddyCur
{
    class RedPitaya : IDisposable
    {
        private readonly TcpClient tcpClient;
        private NetworkStream stream;

        public RedPitaya(string hostname, int port)
        {
            tcpClient = new TcpClient(hostname, port);
            stream = tcpClient.GetStream();
        }

        public void SetGeneratorStateOutput(int channel, bool state)
        {
            var command = SignalGenerator.StateOutputCommand(channel, state);
            byte[] data = Encoding.ASCII.GetBytes(command);
            stream.Write(data);
        }

        public void SetGeneratorFrequency(int channel, double frequency)
        {
            var command = SignalGenerator.SetFrequencyCommand(channel, frequency);
            byte[] data = Encoding.ASCII.GetBytes(command);
            stream.Write(data);
        }

        public void GeneratorReset()
        {
            var command = SignalGenerator.ResetCommand();
            byte[] data = Encoding.ASCII.GetBytes(command);
            stream.Write(data);
        }

        public void SetLED(int number, bool state)
        {
            var command = DigitalPins.SetLEDCommand(number, state);
            byte[] data = Encoding.ASCII.GetBytes(command);
            stream.Write(data);
        }

        public void Dispose()
        {
            tcpClient.Close();
            //Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
            }
        }
    }
}
