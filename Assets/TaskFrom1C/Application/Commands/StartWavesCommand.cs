using System;
using TaskFrom1C.Enemy;

namespace TaskFrom1C.Application.Commands
{
    public class StartWavesCommand : ICommand
    {
        private readonly IWaveController _waveController;
        public event Action OnDone;

        public StartWavesCommand(IWaveController waveController)
        {
            _waveController = waveController;
        }
        
        public void Execute()
        {
            _waveController.StartWave();
            
            OnDone?.Invoke();
        }
    }
}