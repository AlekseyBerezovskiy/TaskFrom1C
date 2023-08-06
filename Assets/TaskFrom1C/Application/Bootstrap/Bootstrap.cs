using System;
using System.Collections.Generic;

namespace TaskFrom1C.Application
{
    public class Bootstrap : IBootstrap
    {
        public event Action OnAllCommandsDone;

        private Queue<ICommand> _commands = new Queue<ICommand>();

        public void StartExecute()
        {
            ExecuteNextCommand();
        }

        public void AddCommand(ICommand command)
        {
            if (_commands.Contains(command))
            {
                return;
            }
            
            _commands.Enqueue(command);
        }

        private void ExecuteNextCommand()
        {
            if (_commands.Count > 0)
            {
                var command = _commands.Dequeue();
                command.OnDone += ExecuteNextCommand;
                command.Execute();
                return;
            }
            
            OnAllCommandsDone?.Invoke();
        }
    }
}   