using System;
using ManicDigger;
using ManicDiggerServer;
using System.Threading;

namespace GameModeFortress
{
    public class ServerConsole
    {
        private Server server;
        public IGameExit Exit;

        public ServerConsole(Server server, IGameExit exit)
        {
            this.server = server;
            this.Exit = exit;

            // run command line reader as seperate thread
            Thread consoleInterpreterThread = new Thread(new ThreadStart(this.CommandLineReader));
            consoleInterpreterThread.Start();
        }

        public void CommandLineReader()
        {
            string input = "";
            while(!Exit.exit)
            {
                input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    continue;
                }
                input = input.Trim();
                server.ReceiveServerConsole(input);
            }
        }

        public void Receive(string message)
        {
            Console.WriteLine(message);
        }
    }
}

