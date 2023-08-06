using System;

namespace TaskFrom1C.Application
{
    public interface IBootstrap
    {
         event Action OnAllCommandsDone;
         void StartExecute();
         void AddCommand(ICommand command);
    }
}