using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern
{
    class Command
    {
        public Command()
        {
            Game game = new Game();
            PingPong pingpong = new PingPong();
            IPingPongCommand ping = new PingCommand(pingpong);
            IPingPongCommand pong = new PongCommand(pingpong);

            game.StoreAndExec(ping);
            game.StoreAndExec(ping);
            game.StoreAndExec(pong);
            game.StoreAndExec(ping);
            game.StoreAndExec(pong);

        }
    }

    interface IPingPongCommand
    {
        void Execute();
    }

    /// <summary>
    /// Reciever class. 
    /// </summary>
    class PingPong
    {
        public void Ping()
        {
            Console.WriteLine("PING");
        }
        public void Pong()
        {
            Console.WriteLine("PONG");
        }
    }

    class PingCommand : IPingPongCommand
    {
        private PingPong _pingpong;

        public PingCommand(PingPong pingpong)
        {
            _pingpong = pingpong;
        }

        public void Execute()
        {
            _pingpong.Ping();
        }
    }

    class PongCommand : IPingPongCommand
    {
        private PingPong _pingpong;

        public PongCommand(PingPong pingpong)
        {
            _pingpong = pingpong;
        }

        public void Execute()
        {
            _pingpong.Pong();
        }
    }

    class Game
    {
        private List<IPingPongCommand> _commands = new List<IPingPongCommand>();

        public void StoreAndExec(IPingPongCommand command)
        {
            _commands.Add(command);
            command.Execute();
        }
    }


}
