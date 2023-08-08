using TaskFrom1C.Application.Commands;
using UnityEngine;
using Zenject;

namespace TaskFrom1C.Application
{
    public class ApplicationLauncher
    {
        private readonly IInstantiator _instantiator;

        public ApplicationLauncher(IInstantiator instantiator)
        {
            _instantiator = instantiator;
            
            LaunchApplication();
        }

        private void LaunchApplication()
        {
            var bootstrap = new Bootstrap();
            bootstrap.OnAllCommandsDone += OnEndBootstrap;
            
            bootstrap.AddCommand(_instantiator.Instantiate<SetupSceneCommand>());
            bootstrap.AddCommand(_instantiator.Instantiate<SetupUICommand>());
            bootstrap.AddCommand(_instantiator.Instantiate<SetupCharacterCommand>());
            bootstrap.AddCommand(_instantiator.Instantiate<StartWavesCommand>());
            
            bootstrap.StartExecute();
        }

        private void OnEndBootstrap()
        {
            Debug.Log("All commands done!");
        }
    }
}