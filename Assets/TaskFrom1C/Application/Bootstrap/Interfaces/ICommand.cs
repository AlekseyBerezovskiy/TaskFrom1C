using System;

namespace TaskFrom1C.Application
{
    public interface ICommand
    {
        event Action OnDone;
        void Execute();
    }
}